using CSP.API.Models.Requests;
using CSP.API.Models.Responses;

namespace CSP.API.Repositories.Interfaces;

public interface IUserRepository
{
    Task<DBResponse> RegistrationAsync(RegistrationModel model,string passwordHash,string fileName,string createdBy);
    Task<LoginResponseModel> LoginAsync(LoginModel model);
}