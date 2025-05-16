
using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using SOSUrbano.Infra.Data.Context;
using SOSUrbano.Infra.Data.Repository.UserRepository;

namespace SOSUrbano.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.Services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssemblies(assemblies));

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
        }
    }
}
