
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using SOSUrbano.Domain.Interfaces.Services.LoginRepository;
using SOSUrbano.Infra.Data.Configurations.LoginConfigurations;
using SOSUrbano.Infra.Data.Context;
using SOSUrbano.Infra.Data.Repository.IncidentRepository;
using SOSUrbano.Infra.Data.Repository.InstitutionRepository;
using SOSUrbano.Infra.Data.Repository.UserRepository;

namespace SOSUrbano.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona suporte para lidar com referências circulares
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            //JWT(Json Web Token)

            var config = builder.Configuration;
            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(config["Jwt:Key"]!))
                    
                    };
                });

            builder.Services.AddAuthorization();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<SOSUrbanoContext>(options =>
            {
                options.UseSqlServer(builder
                    .Configuration.GetConnectionString("SOSUrbanoConnection"))
                .EnableSensitiveDataLogging();
            });

            /*
             AddTransient não reaproveita as instâncias da classe. Se pedirmos 
            para criar cinco usuários dentro de uma transação, ele vai criar 
            cinco vezes builder.Services.AddTransient()
             */

            /*
             AddScoped reaproveita as instâncias, ou seja, se pedirmos para criar
            cinco usuários, ele vai criar a instância uma vez e reaproveitar outras
            quatro vezes
             */
            builder.Services.AddScoped<IRepositoryUser, RepositoryUser>();
            builder.Services.AddScoped<IRepositoryUserStatus, RepositoryUserStatus>();
            builder.Services.AddScoped<IRepositoryUserType, RepositoryUserType>();
            builder.Services.AddScoped<IRepositoryUserPhone, RepositoryUserPhone>();

            builder.Services.AddScoped<IServiceLogin, LoginService>();
            
            builder.Services.AddScoped<IRepositoryInstitution, RepositoryInstitution>();
            builder.Services.AddScoped<IRepositoryInstitutionStatus, RepositoryInstitutionStatus>();
            builder.Services.AddScoped<IRepositoryInstitutionType, RepositoryInstitutionType>();
            builder.Services.AddScoped<IRepositoryInstitutionEmail, RepositoryInstitutionEmail>();
            builder.Services.AddScoped<IRepositoryInstitutionPhone, RepositoryInstitutionPhone>();
            
            builder.Services.AddScoped<IRepositoryIncident, RepositoryIncident>();
            builder.Services.AddScoped<IRepositoryIncidentPhoto, RepositoryIncidentPhoto>();
            builder.Services.AddScoped<IRepositoryIncidentStatus, RepositoryIncidentStatus>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.Services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssemblies(assemblies));

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SOSUrbano API", Version = "v1" });

                // 1? Cria a configuração pra informar que usamos token JWT
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization", // ? nome do campo no header
                    Type = SecuritySchemeType.Http, // ? tipo: http
                    Scheme = "Bearer", // ? tipo de autenticação: Bearer
                    BearerFormat = "JWT", // ? diz que é JWT
                    In = ParameterLocation.Header, // ? onde vai o token? No header
                    Description = "Insira o token JWT usando: Bearer {seu_token}"
                });

                // 2? Fala pro Swagger aplicar isso em todas as rotas protegidas
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer" // ? o mesmo nome lá de cima
                            }
                        },
                        Array.Empty<string>() // ? sem escopos extras
                    }
                 });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
