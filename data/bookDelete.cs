using Books.dto;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.dbo
{
    public class bookDelete
    {
        public bookDelete()
        {

        }
        public void deleteBookbyId(int? bookid)
        {
            BooksDataAccessADO ado = new BooksDataAccessADO();

            string connectionString = ado.getConnectionString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string storedProcedure = "spBooksDelete";

                    using (SqlCommand cmd = new SqlCommand(storedProcedure, connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter sqlParameterBookId = new SqlParameter()
                        {
                            ParameterName = "@bookId",
                            Value = bookid
                        };

                        cmd.Parameters.Add(sqlParameterBookId);

                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Write("Exception: " + ex.ToString());
            }
        }
    }
}