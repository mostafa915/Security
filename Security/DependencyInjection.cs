using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MapsterMapper;
using Security.Services;
using Security.Services.Security.Services;
using System.Reflection;

namespace Security
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDepends(this IServiceCollection services)
        {
            services.AddOpenApi();
            services.AddControllers();
            services.AddFluentValidation();
            services.AddMapster();
            services.AddGlobalExceptionHandler();
            services.AddCorsBroswer();
            services.AddServices();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICaesarService, CaesarService>();
            services.AddScoped<IMonoalphabeticService, MonoalphabeticService>();
            services.AddScoped<IPlayfairService, PlayfairService>();
            services.AddScoped<IVigenereService, VigenereService>();
            services.AddScoped<IAutoKeyService, AutokeyService>();
            services.AddScoped<IRailFenceService, RailFenceService>();
            services.AddScoped<IRowTranspositionService, RowTranspositionService>();
            return services;
        }
        private static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }

        private static IServiceCollection AddMapster(this IServiceCollection services)
        {

            var mappingConfing = TypeAdapterConfig.GlobalSettings;
            mappingConfing.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton<IMapper>(new Mapper(mappingConfing));
            return services;
        }

        private static IServiceCollection AddCorsBroswer(this IServiceCollection services)
        {
            //var allowdOrings =  configuration.GetSection("AllowedOrings").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            });
            return services;
        }
        private static IServiceCollection AddGlobalExceptionHandler(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();
            return services;
        }
    }
}
