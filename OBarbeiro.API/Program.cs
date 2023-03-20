using OBarbeiro.API.Extensoes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigurarServicos(builder.Configuration);
builder.Services.ConfigurarJWT();
builder.Services.ConfigurarSwagger();

builder.Services.AddMemoryCache();
builder.Services.ConfigureRateLimitingOptions();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
