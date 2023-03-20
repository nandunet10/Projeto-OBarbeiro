using OBarbeiro.Comum.Modelos;
using OBarbeiro.Comum.Servico;
using OBarbeiro.Front.Extensoes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DadosBase>(builder.Configuration.GetSection("DadosBase"));

builder.Services.AddScoped<IApiToken, ApiToken>();

builder.Services.AddHttpClient();

builder.Services.ConfigurarCookiesPolicy();
builder.Services.ConfigurarAuthentication();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCookiePolicy();
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
