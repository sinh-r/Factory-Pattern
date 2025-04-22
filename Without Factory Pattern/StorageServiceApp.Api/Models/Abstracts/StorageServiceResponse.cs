namespace StorageServiceApp.Api.Models.Abstracts
{
    public abstract class StorageServiceResponse(string operation, bool isSuccess, string error = "")
    {
        public string Operation { get; } = operation;
        public bool IsSuccess { get; } = isSuccess;
        public string Error { get; set; } = error;
    }
}
