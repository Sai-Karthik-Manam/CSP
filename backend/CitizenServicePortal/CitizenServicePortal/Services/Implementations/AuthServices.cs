using CSP.API.Models.Responses;
using CSP.API.Models.Requests;
using CSP.API.Services.Interfaces;
using CSP.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CSP.API.Services.Implementations;

public class AuthServices : IAuthServices
{
    private readonly IUserRepository _userRepository;

    public AuthServices(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<DBResponse> RegistrationAsync(RegistrationModel model,string fileName,string createdBy)
    {
        string passwordHash =BCrypt.Net.BCrypt.HashPassword(model.Password);
        return await _userRepository.RegistrationAsync(model,passwordHash,fileName,createdBy);
    }
    public async Task<LoginResponseModel> LoginAsync(LoginModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Email))
        {
            return new LoginResponseModel
            {
              Flag=0,
              Message="Please Enter Email"  
            };
        }
        if (string.IsNullOrWhiteSpace(model.Password))
        {
            return new LoginResponseModel
            {
              Flag=0,
              Message="Please Enter Password"  
            };
        }
        var user=await _userRepository.LoginAsync(model);
        if (user == null)
        {
            return new LoginResponseModel
            {
                Flag=0,
                Message="Invalid Email"
            };
        }
        bool isValidPassword = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);
        if (!isValidPassword)
        {
            return new LoginResponseModel
            {
                Flag=0,
                Message="Password doesn't match"
            };  
        }
        user.Flag=1;
        user.Message="Login Successfull";
        return user;
    }
}