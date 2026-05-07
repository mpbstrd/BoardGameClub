using BoardGameClub.Application.Features.Members.CreateMember;
using BoardGameClub.Application.Interfaces;
using BoardGameClub.Infrastructure.Persistence;
using BoardGameClub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BoardGameClub.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("bgcdb")));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateMemberCommand).Assembly));

            AddBggClient(services);
            AddRepositories(services);

            return services;
        }

        private static void AddBggClient(IServiceCollection services)
        {
            services.AddHttpClient("bgg", client =>
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation(
                    "User-Agent",
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

                client.DefaultRequestHeaders.TryAddWithoutValidation(
                    "Accept",
                    "application/xml");
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IMemberRepository, MemberRepository>();
        }
    }
}