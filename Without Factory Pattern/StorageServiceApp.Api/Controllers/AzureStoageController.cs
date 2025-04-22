using Microsoft.AspNetCore.Mvc;
using StorageServiceApp.Api.Contracts;

namespace StorageServiceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzureStoageController(IAzureStorageService azureStorageService) : ControllerBase
    {
        private readonly IAzureStorageService _azureStorageService = azureStorageService;

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
