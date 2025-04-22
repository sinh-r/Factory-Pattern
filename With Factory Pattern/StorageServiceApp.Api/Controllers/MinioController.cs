using Microsoft.AspNetCore.Mvc;
using StorageServiceApp.Api.Contracts;
using StorageServiceApp.Api.ServiceFactory;

namespace StorageServiceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinioController(StorageServiceFactory storageServiceFactory) : ControllerBase
    {
        private readonly IStorageService _minioService = storageServiceFactory.GetStorageService(Models.StorageServiceType.Minio);

        [HttpGet("CreateContainer/{containerName}")]
        public async Task<IActionResult> CreateContainer(string containerName)
        {
            var createBucketResponse = await _minioService.CreateContainerAsync(containerName);
            return Ok(createBucketResponse);
        }

        [HttpGet("DeleteContainer/{containerName}")]
        public async Task<IActionResult> DeleteContainer(string containerName)
        {
            var createBucketResponse = await _minioService.DeleteContainerAsync(containerName);
            return Ok(createBucketResponse);
        }

        [HttpGet("UploadObject")]
        public async Task<IActionResult> UploadObjectFromSystem(string containerName, string systemFilePath, string uploadFilePath)
        {
            var uploadObjectResponse = await _minioService.UploadObjectFromSystemAsync(containerName, systemFilePath, uploadFilePath);
            return Ok(uploadObjectResponse);
        }
    }
}
