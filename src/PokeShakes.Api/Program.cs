var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("poke", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["PokeApi:BaseUrl"] ?? "https://pokeapi.co/api/v2/");
    c.Timeout = TimeSpan.FromSeconds(builder.Configuration.GetValue("PokeApi:TimeoutSeconds", 5));
});
builder.Services.AddHttpClient("shake", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ShakeApi:BaseUrl"] ?? "https://api.funtranslations.com");
    c.Timeout = TimeSpan.FromSeconds(builder.Configuration.GetValue("ShakeApi:TimeoutSeconds", 5));
});


builder.Services.AddSingleton<PokeShakes.Api.Services.IPokeShakeService,
    PokeShakes.Api.Services.PokeShakeService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();