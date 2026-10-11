using CSP.API.Models.Requests;
using CSP.API.Models.Responses;

namespace CSP.API.Services.Interfaces;
public interface IAuthServices
{
    Task <DBResponse> RegistrationAsync(RegistrationModel model,string fileName,string createdBy);
    Task<LoginResponseModel> LoginAsync(LoginModel model);
}