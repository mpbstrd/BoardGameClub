using BoardGameClub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();
builder.Services.AddHttpClient("bgg", client =>
{
    //client.DefaultRequestHeaders.UserAgent.ParseAdd(
    //    "BoardGameClubApi/1.0 (matthewperrybustarde@gmail.com)"
    //);

    client.DefaultRequestHeaders.TryAddWithoutValidation(
       "User-Agent",
       "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0 Safari/537.36"
   );

    client.DefaultRequestHeaders.TryAddWithoutValidation(
        "Accept",
        "application/xml"
    );
});

// Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "BoardGameClub API",
        Version = "v1"
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("fbgcdb")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Enable Swagger only in development (recommended)
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();