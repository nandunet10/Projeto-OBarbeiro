﻿using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OBarbeiro.Infra.Contexts;
using OBarbeiro.Negocio.Agendamento;
using OBarbeiro.Negocio.AgendamentoStatus;
using OBarbeiro.Negocio.AgendaProfissional;
using OBarbeiro.Negocio.Cadastro;
using OBarbeiro.Negocio.Cliente;
using OBarbeiro.Negocio.Empresa;
using OBarbeiro.Negocio.NegocioBase;
using OBarbeiro.Negocio.PerfilUsuario;
using OBarbeiro.Negocio.Pesquisa;
using OBarbeiro.Negocio.Profissional;
using OBarbeiro.Negocio.Servico;
using OBarbeiro.Negocio.Usuario;
using System.Security.Cryptography;

namespace OBarbeiro.API.Extensoes;

public static class ServicoExtensoes
{

    public static void ConfigurarSwagger(this IServiceCollection services) =>
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "API - Dev:Prática",
                Version = "v1",
                Description = "Api de agendamentos para barbearias"
            });

            c.EnableAnnotations();

            var securityscheme = new OpenApiSecurityScheme
            {
                Name = "autenticação jwt",
                Description = "informe o token jwt beare **_somente_**",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            c.AddSecurityDefinition(securityscheme.Reference.Id, securityscheme);
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        { securityscheme, Array.Empty<string>() }
                    });
        });
    public static void ConfigurarJWT(this IServiceCollection services)
    {
        Environment.SetEnvironmentVariable("JWT_SECRETO",
         Convert.ToBase64String(new HMACSHA256().Key), EnvironmentVariableTarget.Process);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                RequireExpirationTime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = "EmitenteDoJWT",
                ValidAudience = "DestinatarioDoJWT",
                IssuerSigningKey = new SymmetricSecurityKey(
                    Convert.FromBase64String(Environment.GetEnvironmentVariable("JWT_SECRETO"))),

            };

        });

    }
    public static void ConfigureRateLimitingOptions(this IServiceCollection services)
    {
        var rateLimitRules = new List<RateLimitRule>
        {
            new RateLimitRule
            {
                Endpoint = "post:/api/Login",
                Limit = 10,
                Period = "10m",
            },
        };

        services.Configure<IpRateLimitOptions>(opt =>
        {
            opt.EnableEndpointRateLimiting = true;
            opt.StackBlockedRequests = false;
            opt.GeneralRules = rateLimitRules;
        });

        services.AddInMemoryRateLimiting();

        services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
        services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
    }
    public static void ConfigurarServicos(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OBarbeiroDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        //Adicionar Scoped
        //services.AddScoped<IAgendamentoNegocio, AgendamentoNegocio>();
        //services.AddScoped<IAgendamentoStatusNegocio, AgendamentoStatusNegocio>();
        //services.AddScoped<IAgendaProfissionalNegocio, AgendaProfissionalNegocio>();
        //services.AddScoped<IClienteNegocio, ClienteNegocio>();
        //services.AddScoped<IEmpresaNegocio, EmpresaNegocio>();
        //services.AddScoped<ICadastroNegocio, CadastroNegocio>();
        //services.AddScoped<IUsuarioNegocio, UsuarioNegocio>();
        //services.AddScoped<IPerfilUsuariosNegocio, PerfilUsuariosNegocio>();
        //services.AddScoped<IProfissionalNegocio, ProfissionalNegocio>();
        //services.AddScoped<IServicoNegocio, ServicoNegocio>();
        //services.AddScoped<IPesquisa, Pesquisa>();

        services.AddScoped(typeof(INegocioBase<>), typeof(NegocioBase<>));



    }

}
