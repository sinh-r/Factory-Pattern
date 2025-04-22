namespace StorageServiceApp.Api.Models.Abstracts
{
    public abstract class ContainerResponse(string containerName, string operation, bool isSuccess, string error = "")
        : StorageServiceResponse(operation, isSuccess, error)
    {
        public string ContainerName { get; } = containerName;
    }
}
