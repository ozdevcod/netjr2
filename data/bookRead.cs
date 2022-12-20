using Books.dto;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.dbo
{
    public class bookRead
    {
        public List<Book> BooksList { get; set; }

        public bookRead()
        {
            BooksList = new List<Book>();
        }
        public List<Book> getBooksbyId(int? bookid)
        {
            BooksDataAccessADO ado = new BooksDataAccessADO();

            string connectionString = ado.getConnectionString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string storedProcedure = "spBooksRead";

                    using (SqlCommand cmd = new SqlCommand(storedProcedure, connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter sqlParameterBookId = new SqlParameter()
                        {
                            ParameterName = "@bookId",
                            Value = bookid
                        };

                        cmd.Parameters.Add(sqlParameterBookId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Book book = new Book();

                                book.id = reader.GetInt32(0);
                                book.name = reader.GetString(1);
                                book.author = reader.GetString(2);
                                book.pages = reader.GetInt16(3);
                                book.genre = reader.GetString(4);
                                book.year = reader.GetString(5);
                                BooksList.Add(book);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Write("Exception: " + ex.ToString());
            }
            return BooksList;
        }
    }
}