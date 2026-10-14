
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using CSP.API.Models.Responses;
using CSP.API.Repositories.Interfaces;

namespace CSP.API.Repositories.Implementations;

public class ServiceRepository : IServiceRepository
{
    private readonly IConfiguration _configuration;

    public ServiceRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private IDbConnection CreateConnection()
    {
        var connectionString =_configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("DefaultConnection is not configured.");

        return new SqlConnection(connectionString);
    }

    public async Task<IEnumerable<ServiceResponseModel>> GetAllServicesAsync()
    {
        using var connection = CreateConnection();

        return await connection.QueryAsync<ServiceResponseModel>("Get_All_Services",commandType: CommandType.StoredProcedure);
    }
}
