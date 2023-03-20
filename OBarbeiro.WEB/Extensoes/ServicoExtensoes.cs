using Microsoft.AspNetCore.Authentication.Cookies;
using OBarbeiro.Comum.Modelos;
using OBarbeiro.Comum.Servico;

namespace OBarbeiro.Front.Extensoes;
public static class ServicoExtensoes
{
    public static void ConfigurarServicos(this IServiceCollection services)
    {
        //Adicionar Scoped
        services.AddSingleton<IApiToken, ApiToken>();
        services.AddSingleton<LoginResposta>();

        services.AddHttpClient();
    }

    public static void ConfigurarAPI(this IServiceCollection services) { }

    public static void ConfigurarCookiesPolicy(this IServiceCollection services)
    {
        services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });
    }

    public static void ConfigurarAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = new PathString("/Login/Index");
            });
    }

}
