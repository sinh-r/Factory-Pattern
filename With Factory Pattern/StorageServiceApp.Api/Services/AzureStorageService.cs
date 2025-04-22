using Azure.Storage.Blobs;
using StorageServiceApp.Api.Contracts;
using StorageServiceApp.Api.Models.ContainerOperationResponse;
using StorageServiceApp.Api.Models.ObjectOperationResponse;

namespace StorageServiceApp.Api.Services
{
    public class AzureStorageService(BlobServiceClient blobServiceClient) : IStorageService
    {
        private readonly BlobServiceClient _blobServiceClient = blobServiceClient;

        public async Task<CreateContainerResponse> CreateContainerAsync(string containerName)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

                var containerExists = await containerClient.ExistsAsync();

                if (containerExists)
                {
                    return CreateContainerResponse.ContainerExistsFailure(containerName);
                }

                await containerClient.CreateIfNotExistsAsync();

                return CreateContainerResponse.Success(containerName);
            }
            catch (Exception ex)
            {
                return CreateContainerResponse.ExceptionOccuredFailure(containerName, ex.Message);
            }
        }

        public async Task<DeleteContainerResponse> DeleteContainerAsync(string containerName)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

                var containerExists = await containerClient.ExistsAsync();

                if (!containerExists)
                {
                    return DeleteContainerResponse.ContainerDoesNotExistsFailuer(containerName);
                }

                await containerClient.DeleteIfExistsAsync();

                return DeleteContainerResponse.Success(containerName);
            }
            catch (Exception ex)
            {
                return DeleteContainerResponse.ExceptionOccuredFailure(containerName, ex.Message);
            }
        }

        public async Task<UploadObjectResponse> UploadObjectFromSystemAsync(string containerName, string objectName, string filePath = "")
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

                var containerExists = await containerClient.ExistsAsync();

                if (!containerExists)
                {
                    return UploadObjectResponse.ContainerDoesNotExistsFailure(objectName, containerName);
                }

                var blobClient = containerClient.GetBlobClient($"{filePath}/{objectName}");

                await using var fileStream = File.OpenRead(filePath);

                await blobClient.UploadAsync(fileStream);

                return UploadObjectResponse.Success(objectName, containerName);
            }
            catch (Exception ex)
            {
                return UploadObjectResponse.ExceptionOccuredFailure(objectName, containerName, ex.Message);
            }
        }
    }
}
