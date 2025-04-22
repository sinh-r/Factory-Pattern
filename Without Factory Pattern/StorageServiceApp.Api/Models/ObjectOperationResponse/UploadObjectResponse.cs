using StorageServiceApp.Api.Models.Abstracts;

namespace StorageServiceApp.Api.Models.ObjectOperationResponse
{
    public class UploadObjectResponse(string objectName, string containerName, bool isSuccess, string error = "") : 
        ObjectResponse(objectName, containerName, "UPLOAD", isSuccess, error)
    {
        public static UploadObjectResponse Success(string objectName, string containerName) => new(objectName, containerName, true);
        public static UploadObjectResponse CouldNotFindObjectFromSystemFailure(string objectName, string containerName) => new(objectName, containerName, false, $"Could not find the object in file please check the file path");
        public static UploadObjectResponse ContainerDoesNotExistsFailure(string objectName, string containerName) => new(objectName, containerName, false, $"Container {containerName} arealdy exits");
        public static UploadObjectResponse ObjectAlreadyExistsFailure(string objectName, string containerName) => new(objectName, containerName, false, $"Object {objectName} already exits");
        public static UploadObjectResponse ExceptionOccuredFailuer(string objectName, string containerName, string message) => new(objectName, containerName, false, $"Excpetion occure while uploading {objectName}. Exception Message: {message}");
    }
}
