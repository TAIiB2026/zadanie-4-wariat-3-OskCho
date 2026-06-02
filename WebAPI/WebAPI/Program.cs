
using Contracts;
using Services.Memory;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.WebHost.UseUrls("http://localhost:5111");

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IGetDataInterface, GetDataService>();
            builder.Services.AddScoped<IFormSubmitInterface, FormSubmitService>();

            const string POLICY_NAME = "ourCORS";
            builder.Services.AddCors(opt => opt
                .AddPolicy(POLICY_NAME, policy => policy
                    .WithOrigins("http://localhost:4111")
                    .AllowAnyMethod()
                    .AllowAnyHeader()));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(POLICY_NAME);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
