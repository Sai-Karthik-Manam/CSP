
using CSP.API.Models.Responses;
using CSP.API.Repositories.Interfaces;
using CSP.API.Services.Interfaces;

namespace CSP.API.Services.Implementations;

public class Service : IService
{
    private readonly IServiceRepository _repository;

    public Service(IServiceRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ServiceResponseModel>> GetAllServicesAsync()
    {
        return _repository.GetAllServicesAsync();
    }
}
