using Blasco.Data;
using Blasco.Services.Data.Interfaces;
using Blasco.Web.Infrastructure.Extentions;

using Microsoft.EntityFrameworkCore;

namespace Blasco.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string conectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<BlascoDbContext>(opt =>
            opt.UseSqlServer(conectionString));

            builder.Services.AddApplicationServices(typeof(IProductService));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(setup =>
            {
                setup.AddPolicy("Blasco", policyBuilder =>
                {
                    policyBuilder.WithOrigins("https://localhost:7138")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
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

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("Blasco");

            app.Run();
        }
    }
}