using Microsoft.AspNetCore.Mvc;
using StorageServiceApp.Api.Contracts;
using StorageServiceApp.Api.ServiceFactory;

namespace StorageServiceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzureStorageController(StorageServiceFactory storageServiceFactory) : ControllerBase
    {
        private readonly IStorageService _minioStorageServicve = storageServiceFactory.GetMinioStorageService();
        private readonly IStorageService _azureStorageService = storageServiceFactory.GetStorageService(Models.StorageServiceType.Azure);

        [HttpGet("CreateContainer/{containerName}")]
        public async Task<IActionResult> CreateContainer(string containerName)
        {
            var createBucketResponse = await _azureStorageService.CreateContainerAsync(containerName);
            return Ok(createBucketResponse);
        }

        [HttpGet("DeleteContainer/{containerName}")]
        public async Task<IActionResult> DeleteContainer(string containerName)
        {
            var createBucketResponse = await _azureStorageService.DeleteContainerAsync(containerName);
            return Ok(createBucketResponse);
        }

        [HttpGet("UploadObject")]
        public async Task<IActionResult> UploadObjectFromSystem(string containerName, string systemFilePath, string uploadFilePath)
        {
            var uploadObjectResponse = await _azureStorageService.UploadObjectFromSystemAsync(containerName, systemFilePath, uploadFilePath);
            return Ok(uploadObjectResponse);
        }
    }
}
