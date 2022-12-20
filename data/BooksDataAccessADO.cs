using Books.dto;
using Microsoft.Data.SqlClient;

namespace Books.dbo
{
    public class BooksDataAccessADO
    {
        private string connectionString;

        public string MyProperty
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        public BooksDataAccessADO()
        {
            connectionString = "Data Source=.\\SQLSERVERNAME;Initial Catalog=DATABASENAME;Integrated Security=True;Persist Security Info=False;TrustServerCertificate=True";
        }

        public string getConnectionString()
        {

            return this.connectionString;
        }

    }
}