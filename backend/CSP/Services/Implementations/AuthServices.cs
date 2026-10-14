using CSP.API.Models.Responses;
using CSP.API.Models.Requests;
using CSP.API.Services.Interfaces;
using CSP.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CSP.API.Services.Implementations;

public class AuthServices : IAuthServices
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthServices(IUserRepository userRepository,ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService=tokenService;
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
                Flag = 0,
                Message = "Please enter email"
            };
        }

        if (string.IsNullOrWhiteSpace(model.Password))
        {
            return new LoginResponseModel
            {
                Flag = 0,
                Message = "Please enter password"
            };
        }

        var user = await _userRepository.LoginAsync(model);

        if (user == null)
        {
            return new LoginResponseModel
            {
                Flag = 0,
                Message = "Invalid email or password"
            };
        }

        bool isValidPassword =
            BCrypt.Net.BCrypt.Verify(model.Password, user.Password);

        if (!isValidPassword)
        {
            return new LoginResponseModel
            {
                Flag = 0,
                Message = "Invalid email or password"
            };
        }

        return new LoginResponseModel
        {
            Id = user.Id,
            UserName = user.UserName,
            CitizenID = user.CitizenID,
            Role = user.Role,
            Flag = 1,
            Message = "Login successful",
            Token = _tokenService.GenerateToken(user.Id,user.UserName,user.CitizenID,user.Role)
        };
    }
}