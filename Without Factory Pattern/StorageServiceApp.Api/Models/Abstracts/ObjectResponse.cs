namespace StorageServiceApp.Api.Models.Abstracts
{
    public abstract class ObjectResponse(string objectName, string containerName, string operation, bool isSuccess, string error = "") : 
        ContainerResponse(containerName, operation, isSuccess, error)
    {
        public string ObjectName { get; set; } = objectName;
    }
}
