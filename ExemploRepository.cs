public class ExemploRepository
{
    public readonly ConnectionFactory factory;

    public ExemploRepository(ConnectionFactory factory)
    {
        this.factory = factory;
    }

    public void AlgumaOperacao()
    {
        using var connection = factory.CreateNew();
        connection.Open();
        using var transaction = connection.BeginTransaction();
        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Exemplo (Nome) VALUES ('Nome')";
        command.ExecuteNonQuery();
        command.ExecuteNonQuery();
        transaction.Commit();
    }
}