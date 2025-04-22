using Azure.Storage.Blobs;
using Minio;
using StorageServiceApp.Api.Contracts;
using StorageServiceApp.Api.ServiceFactory;
using StorageServiceApp.Api.Services;

namespace StorageServiceApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var configuration = builder.Configuration;
            var azureStorageConnectionString = configuration["AzureStorage:ConnectionString"];

            //Add services
            builder.Services.AddMinio(
                configure => configure
                .WithEndpoint(configuration["MinioConfig:Endpoint"])
                .WithCredentials(configuration["MinioConfig:AccessKey"], configuration["MinioConfig:SecretKey"])
                .WithSSL(false).Build()
            );

            builder.Services.AddSingleton(new BlobServiceClient(azureStorageConnectionString));

            builder.Services.AddSingleton<IStorageService, AzureStorageService>();
            builder.Services.AddSingleton<IStorageService, MinioService>();

            builder.Services.AddSingleton<IStorageServiceFactory, StorageServiceFactory>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
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
