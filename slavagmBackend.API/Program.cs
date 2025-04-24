using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using slavagmBackend.API.Middlewares;
using slavagmBackend.Core.Repositories;
using slavagmBackend.Core.Services;
using slavagmBackend.Infrastructure.Data;
using slavagmBackend.Infrastructure.Repositories;
using slavagmBackend.Services;
using slavagmBackend.Services.Services;

namespace slavagmBackend.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        AuthOptions.MakeOptions(builder.Configuration);
        
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(
                builder.Configuration.GetConnectionString("SqliteConnection")));

        builder.Services.AddScoped<ICardRepository, CardRepository>();
        builder.Services.AddScoped<ISkillRepository, SkillRepository>();
        
        builder.Services.AddScoped<ICardService, CardService>();
        builder.Services.AddScoped<ISkillService, SkillService>();
        builder.Services.AddScoped<IAuthService, AuthService>();

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthOptions.Issuer,
                    
                    ValidateAudience = true,
                    ValidAudience = AuthOptions.Audience,

                    ValidateLifetime = true,
                    
                    IssuerSigningKey = AuthOptions.SymmetricSecurityKey,
                    ValidateIssuerSigningKey = true,
                };
            });
        
        builder.Services.AddControllers().AddJsonOptions(opts =>
        {
            opts.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme.",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    []
                }
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger(options => { options.RouteTemplate = "api/swagger/{documentName}/swagger.json"; });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Survey Backend V1");
                options.RoutePrefix = "api/swagger";
            });
        }
        
        app.UseMiddleware<ExceptionsMiddleware>();

        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapControllers();
        
        app.Run();
    }
}