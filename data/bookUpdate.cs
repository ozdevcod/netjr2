using Books.dto;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Books.dbo
{
    public class bookUpdate
    {
        public void UpdateBook(Book book)
        {
            BooksDataAccessADO ado = new BooksDataAccessADO();

            string connectionString = ado.getConnectionString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string storedProcedure = "spBooksUpdate";

                    using (SqlCommand cmd = new SqlCommand(storedProcedure, connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@name", book.name);
                        cmd.Parameters.AddWithValue("@author", book.author);
                        cmd.Parameters.AddWithValue("@pages", book.pages);
                        cmd.Parameters.AddWithValue("@genre", book.genre);
                        cmd.Parameters.AddWithValue("@year", book.year);
                        cmd.Parameters.AddWithValue("@bookId", book.id);

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