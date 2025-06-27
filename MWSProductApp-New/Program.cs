using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MWSProducts;
using AutoMapper;

using MWSProductApp.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using MediatR;
using MWSProductApp.Core;
using MWSProductApp.Infrastructure;


namespace MWSProductApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<DataDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCore();
builder.Services.AddAutoMapper(new[] { typeof(MappingProfile) });

            builder.Services.AddSwaggerGen();           
            // builder.Services.AddMediatR(cfg =>
            //     cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

            var app = builder.Build();

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
