using StorageServiceApp.Api.Models.Abstracts;

namespace StorageServiceApp.Api.Models.ContainerOperationResponse
{
    public class CreateContainerResponse(string containerName, bool isSuccess, string error = "")
        : ContainerResponse(containerName, "CREATE", isSuccess, error)

    {
        public static CreateContainerResponse Success(string containerName) => new(containerName, true);
        public static CreateContainerResponse ContainerExistsFailure(string containerName) => new(containerName, false, $"Container {containerName} already exists!");
        public static CreateContainerResponse ExceptionOccuredFailure(string containerName, string exception) => new(containerName, false, $"Exception caught while performing operation: {exception}");
    }
}
