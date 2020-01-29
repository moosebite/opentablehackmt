using System;
using MySql.Data.MySqlClient;

namespace ReactOpenTable.Context
{
    public class DbAppContext : IDisposable
    {
        public MySqlConnection Connection { get; }

        public DbAppContext(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}
