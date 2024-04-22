using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;
using SistemaTeste.Data;
using System.Data.Common;
using SistemaTeste.Models;
using SistemaTeste.Reposiorios;
using SistemaTeste.Reposiorios.Interfaces;

namespace SistemaTeste
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
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkMySql()
                .AddDbContext<SistemaTarefasDBContex>(
                    options => options.UseMySql(ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DataBase")))
                );
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

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
