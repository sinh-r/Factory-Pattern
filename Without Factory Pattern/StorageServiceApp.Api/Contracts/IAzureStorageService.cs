using StorageServiceApp.Api.Models.ContainerOperationResponse;
using StorageServiceApp.Api.Models.ObjectOperationResponse;

namespace StorageServiceApp.Api.Contracts
{
    public interface IAzureStorageService
    {
        Task<CreateContainerResponse> CreateContainerAsync(string containerName);
        Task<DeleteContainerResponse> DeleteContainerAsync(string containerName);

        Task<UploadObjectResponse> UploadObjectFromSystemAsync(string containerName, string objectName, string filePath = "");
    }
}
