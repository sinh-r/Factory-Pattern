using Minio;
using Minio.DataModel.Args;
using StorageServiceApp.Api.Contracts;
using StorageServiceApp.Api.Models.ContainerOperationResponse;
using StorageServiceApp.Api.Models.ObjectOperationResponse;

namespace StorageServiceApp.Api.Services
{
    public class MinioService(IMinioClient minioClient) : IStorageService
    {
        private readonly IMinioClient _minioClient = minioClient;

        private async Task<bool> BucketExistsAsync(string containerName)
        {
            var bucketExistsArg = new BucketExistsArgs().WithBucket(containerName);

            var bucketExists = await _minioClient.BucketExistsAsync(bucketExistsArg);

            return bucketExists;
        }

        private async Task<bool> ObjectExistsAsync(string containerName, string objectName)
        {
            var statObjectArgs = new StatObjectArgs()
                                       .WithBucket(containerName)
                                       .WithObject(objectName);

            try
            {
                var objectStat = await minioClient.StatObjectAsync(statObjectArgs);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<CreateContainerResponse> CreateContainerAsync(string containerName)
        {
            try
            {
                var containerExists = await BucketExistsAsync(containerName);

                if (containerExists)
                {
                    return CreateContainerResponse.ContainerExistsFailure(containerName);
                }

                var makeBucketArg = new MakeBucketArgs().WithBucket(containerName);

                await _minioClient.MakeBucketAsync(makeBucketArg);

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
                var bucketExists = await BucketExistsAsync(containerName);

                if (!bucketExists)
                {
                    return DeleteContainerResponse.ContainerDoesNotExistsFailuer(containerName);
                }

                var removeBucketArg = new RemoveBucketArgs().WithBucket(containerName);

                await _minioClient.RemoveBucketAsync(removeBucketArg);

                return DeleteContainerResponse.Success(containerName);
            }
            catch (Exception ex)
            {
                return DeleteContainerResponse.ExceptionOccuredFailure(containerName, ex.Message);
            }
        }

        public async Task<UploadObjectResponse> UploadObjectFromSystemAsync(string containerName, string systemFilePath, string filePath = "")
        {
            string objectName = string.Empty;
            try
            {
                objectName = systemFilePath.Split('/').LastOrDefault() ?? string.Empty;

                if (string.IsNullOrEmpty(objectName))
                {
                    return UploadObjectResponse.CouldNotFindObjectFromSystemFailure(objectName, containerName);
                }

                var bucketExists = await BucketExistsAsync(containerName);

                if (!bucketExists)
                {
                    return UploadObjectResponse.ContainerDoesNotExistsFailure(objectName, containerName);
                }

                var objectExists = await ObjectExistsAsync(containerName, objectName);

                if (objectExists)
                {
                    return UploadObjectResponse.ObjectAlreadyExistsFailure(objectName, containerName);
                }

                var putObjectArg = new PutObjectArgs()
                    .WithBucket(containerName)
                    .WithFileName(systemFilePath)
                    .WithObject($"{filePath}/{objectName}");

                await _minioClient.PutObjectAsync(putObjectArg);

                return UploadObjectResponse.Success(objectName, containerName);
            }
            catch (Exception ex)
            {
                return UploadObjectResponse.ExceptionOccuredFailure(objectName, containerName, ex.Message);
            }
        }
    }
}
