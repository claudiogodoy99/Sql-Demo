using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;

public class ConnectionFactory
{

    public IDbConnection CreateNew()
    {
        return new SqlConnection("");
    }
}
