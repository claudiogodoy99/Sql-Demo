using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;

public class UnityOfWork
{
    public readonly SqlConnection Connection;
    public DbTransaction? Transaction { get; private set; }

    public UnityOfWork()
    {

        this.Connection = new SqlConnection("");

    }

    public void OpenConnection()
    {
        if (Connection is not null && Connection.State == ConnectionState.Closed)
            Connection.Open();
    }

    public void CloseConnection()
    {
        if (Connection is not null && Connection.State == ConnectionState.Open)
            Connection.Close();
    }

    public void BeginTransaction()
    {
        OpenConnection();
        Transaction = Connection.BeginTransaction();
    }

    public void Commit()
    {
        if (Transaction != null)
        {
            Transaction.Commit();
        }
    }

    public void Rollback()
    {
        if (Transaction != null)
        {
            Transaction.Rollback();
        }
    }

    public IDataReader ExecuteReader(string query)
    {
        OpenConnection();
        DbCommand dbCommand = Connection.CreateCommand();
        dbCommand.CommandText = query;
        dbCommand.Connection = this.Connection;

        return dbCommand.ExecuteReader();
    }

    public int ExecuteNonQuery(string command)
    {
        OpenConnection();
        DbCommand dbCommand = Connection.CreateCommand();
        dbCommand.CommandText = command;
        dbCommand.Connection = this.Connection;
        dbCommand.Transaction = this.Transaction;
        return dbCommand.ExecuteNonQuery();
    }

    //Cadê o Dispose?
}
