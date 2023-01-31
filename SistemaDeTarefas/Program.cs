using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Repository;
using SistemaDeTarefas.Repository.Interfaces;
using System;

namespace SistemaDeTarefas
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

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaTarefasDBContext>(
                   options =>
                   {
                       options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"));
                       options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                   }
                );

            // config das dependencia do repository
            // toda vez que chamar a interface IUsuarioRepository
            // a classe que vai resolver é a UsuarioRepository
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

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