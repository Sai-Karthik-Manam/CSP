
using CSP.API.Models.Responses;

namespace CSP.API.Services.Interfaces;

public interface IService
{
    Task<IEnumerable<ServiceResponseModel>> GetAllServicesAsync();
}
