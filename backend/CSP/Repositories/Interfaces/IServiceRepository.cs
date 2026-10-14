
using CSP.API.Models.Responses;

namespace CSP.API.Repositories.Interfaces;

public interface IServiceRepository
{
    Task<IEnumerable<ServiceResponseModel>> GetAllServicesAsync();
}
