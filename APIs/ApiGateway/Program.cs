using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Eureka;
using System.Text;

namespace ApiGateway
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var ocelotConfigPath = $"ocelot.{builder.Environment.EnvironmentName ?? "Development"}.json";

            var ocelotJsonString = File.ReadAllText(ocelotConfigPath);
            ocelotJsonString = ocelotJsonString
                .Replace("${EMPLOYER_SERVICE_HOST}", builder.Configuration["ServiceSettings:EmployerServiceHost"])
                .Replace("${EMPLOYER_SERVICE_PORT}", builder.Configuration["ServiceSettings:EmployerServicePort"])
                .Replace("${JOB_POSTING_SERVICE_HOST}", builder.Configuration["ServiceSettings:JobPostingServiceHost"])
                .Replace("${JOB_POSTING_SERVICE_PORT}", builder.Configuration["ServiceSettings:JobPostingServicePort"])
                .Replace("${APIGATEWAY_HOST}", builder.Configuration["ServiceSettings:ApiGatewayHost"])
                .Replace("${APIGATEWAY_PORT}", builder.Configuration["ServiceSettings:ApiGatewayPort"]);

            var ocelotJsonConfig = new ConfigurationBuilder()
                .AddJsonStream(new MemoryStream(Encoding.ASCII.GetBytes(ocelotJsonString)))
                .Build();

            builder.Services.AddOcelot(ocelotJsonConfig); 

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            await app.UseOcelot();
            app.Run();
        }
    }
}