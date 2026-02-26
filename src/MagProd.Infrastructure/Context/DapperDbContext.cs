using System.Data;
using Npgsql;

namespace MagProd.Infrastructure;

public class DapperDbContext 
{
    public IDbConnection GetConnection()
    {
        var str = "Host=localhost;Port=5435;Database=productdb;Username=postgres;Password=postgres";
        return new NpgsqlConnection(str);

    }
}