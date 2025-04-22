using StorageServiceApp.Api.Models;

namespace StorageServiceApp.Api.Contracts
{
    public interface IStorageServiceFactory
    {
        IStorageService GetAzureStorageService();
        IStorageService GetMinioStorageService();
        IStorageService GetStorageService(StorageServiceType serviceType);
    }
}
