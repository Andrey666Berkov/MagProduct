using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace MagProd.Infrastructure.Context;

public class DapperDbContext(IConfiguration configuration) 
{
    public IDbConnection GetConnection()
    {
        
        var str = configuration.GetConnectionString("DefaultConnection");
        return new NpgsqlConnection(str);

    }
}