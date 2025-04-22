using Azure.Storage.Blobs;
using Minio;
using StorageServiceApp.Api.Contracts;
using StorageServiceApp.Api.Models;
using StorageServiceApp.Api.Services;

namespace StorageServiceApp.Api.ServiceFactory
{
    public class StorageServiceFactory(IMinioClient minioClient, BlobServiceClient blobServiceClient) : IStorageServiceFactory
    {
        private readonly IMinioClient _minioClient = minioClient;
        private readonly BlobServiceClient _blobServiceClient = blobServiceClient;

        public IStorageService GetAzureStorageService() 
            => new AzureStorageService(_blobServiceClient);

        public IStorageService GetMinioStorageService() 
            => new MinioService(_minioClient);


        public IStorageService GetStorageService(StorageServiceType serviceType)
        {
            return serviceType switch
            {
                StorageServiceType.Minio => new MinioService(_minioClient),
                StorageServiceType.Azure => new AzureStorageService(_blobServiceClient), 
                _ => throw new NotImplementedException($"Storage service '{serviceType}' is not implemented.")
            };
        }
    }
}
