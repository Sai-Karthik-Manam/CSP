using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using CSP.API.Models.Requests;
using CSP.API.Models.Responses;
using CSP.API.Repositories.Interfaces;

namespace CSP.API.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly IConfiguration _configuration;

    public UserRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private IDbConnection CreateConnection()
    {
        var connectionString =_configuration.GetConnectionString("DefaultConnection");

        return new SqlConnection(connectionString);
    }

    public async Task<DBResponse> RegistrationAsync(RegistrationModel model,string passwordHash,string fileName,string createdBy)
    {
        using var conn = CreateConnection();
        var parameters = new
        {
            model.Name,
            model.Email,
            model.MobileNumber,
            model.DOB,
            PasswordHash = passwordHash,
            Photo = fileName,
            CreatedBy = createdBy
        };
        var result =await conn.QuerySingleAsync<DBResponse>("User_Registration",parameters,commandType: CommandType.StoredProcedure);
        return result;
    }
    public async Task<LoginUserData> LoginAsync(LoginModel model)
    {
        using var conn=CreateConnection();
        var parameters = new
        {
            model.Email
        };
        return await conn.QuerySingleAsync<LoginUserData>("User_Login",parameters,commandType:CommandType.StoredProcedure);
    }
}