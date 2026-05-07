using Microsoft.AspNetCore.Mvc;

namespace BoardGameClub.Api.Controllers
{
    public class SyncController : Controller
    {
        //private readonly HttpClient _httpClient;

        //public BoardGameController(IHttpClientFactory factory)
        //{
        //    _httpClient = factory.CreateClient("bgg");
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetBoardGame(int id)
        //{
        //    var url = $"https://boardgamegeek.com/xmlapi2/thing?id={id}&stats=1";

        //    var response = await _httpClient.GetAsync(url);
        //    var body = await response.Content.ReadAsStringAsync();

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        return StatusCode((int)response.StatusCode, new
        //        {
        //            error = "BGG request failed",
        //            status = response.StatusCode,
        //            body
        //        });
        //    }

        //    return Content(body, "application/xml");
        //}
    }
}
