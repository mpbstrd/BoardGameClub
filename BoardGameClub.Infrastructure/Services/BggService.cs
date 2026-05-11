using BoardGameClub.Application.DTOs;
using BoardGameClub.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;

namespace BoardGameClub.Infrastructure.Services
{
    public class BggService : IBggService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string? _baseUrl;

        public BggService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = _configuration["ApiSettings:BggXmlApiBaseUrl"] ?? throw new InvalidOperationException("BGG base URL is not configured.");
        }

        public async Task<BggGameDto?> GetGameAsync(int id)
        {

            var token = _configuration["ApiSettings:BggXmlApiToken"] ?? throw new InvalidOperationException("BGG token is not configured.");
            var url = $"{_baseUrl}thing?id={id}&stats=1";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return null;

            string xml = await response.Content.ReadAsStringAsync();

            XDocument doc = XDocument.Parse(xml);
            XElement? item = doc.Descendants("item").FirstOrDefault();

            if(item == null) return null;


            var links = item.Elements("link");

            var categories = links.Where(x => x.Attribute("type")?.Value == "boardgamecategory")
                .Select(x => new CategoryDto
                {
                    Id = (int)ParseInt(x.Attribute("id")?.Value),
                    Name = x.Attribute("value")?.Value ?? ""
                })
                .ToList();

            var mechanics = links.Where(x => x.Attribute("type")?.Value == "boardgamemechanic")
                .Select(x => new MechanicsDto
                {
                    Id = (int)ParseInt(x.Attribute("id")?.Value),
                    Name = x.Attribute("value")?.Value ?? ""
                })
                .ToList();

            return new BggGameDto
            {
                Id = id,
                Name = item.Elements("name")
                    .FirstOrDefault(x =>
                        x.Attribute("type")?.Value == "primary")
                    ?.Attribute("value")
                    ?.Value ?? "",
                YearPublished = ParseInt(item.Element("yearpublished")?.Attribute("value")?.Value),
                Description = item.Element("description")?.Value ?? "",
                MinPlayers = ParseInt(item.Element("minplayers")?.Attribute("value")?.Value),
                MaxPlayers = ParseInt(item.Element("maxplayers")?.Attribute("value")?.Value),
                MinPlayTime = ParseInt(item.Element("minplaytime")?.Attribute("value")?.Value),
                MaxPlayTime = ParseInt(item.Element("maxplaytime")?.Attribute("value")?.Value),
                PlayingTime = ParseInt(item.Element("playingtime")?.Attribute("value")?.Value),
                Mechanics = mechanics,
                Category = categories
            };
        }

        private static int? ParseInt(string? value)
        {
            return int.TryParse(value, out int result)
                ? result
                : null;
        }
    }
}
