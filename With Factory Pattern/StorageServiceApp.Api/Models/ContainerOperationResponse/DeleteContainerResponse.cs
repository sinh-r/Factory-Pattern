using StorageServiceApp.Api.Models.Abstracts;

namespace StorageServiceApp.Api.Models.ContainerOperationResponse
{
    public class DeleteContainerResponse(string containerName, bool isSuccess, string error = "")
        : ContainerResponse(containerName, "DELETE", isSuccess, error)
    {
        public static DeleteContainerResponse Success(string containerName) => new(containerName, true);
        public static DeleteContainerResponse ExceptionOccuredFailure(string containerName, string message) => new(containerName, false, $"Exception occured while performing delete operation on bucket {containerName}. Exception Message: {message}");
        public static DeleteContainerResponse ContainerDoesNotExistsFailuer(string containerName) => new(containerName, false, $"Bucket {containerName} does not exists");
    }
}
