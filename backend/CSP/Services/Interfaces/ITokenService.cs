namespace CSP.API.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(int userId,string userName,string citizenId,int role);
}