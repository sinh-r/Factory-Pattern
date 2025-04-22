using Microsoft.AspNetCore.Mvc;
using StorageServiceApp.Api.Contracts;

namespace StorageServiceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinioController(IMinioService minioService) : ControllerBase
    {
        private readonly IMinioService _minioService = minioService;

        [HttpGet("CreateBucket/{bucketName}")]
        public async Task<IActionResult> CreateBucket(string bucketName)
        {
            var createBucketResponse = await _minioService.CreateContainerAsync(bucketName);
            return Ok(createBucketResponse);
        }

        [HttpGet("DeleteBucket/{bucketName}")]
        public async Task<IActionResult> DeleteBucket(string bucketName)
        {
            var createBucketResponse = await _minioService.DeleteContainerAsync(bucketName);
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
