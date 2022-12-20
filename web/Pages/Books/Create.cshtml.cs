using Books.dto;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System;

namespace Books.web.Pages.Books
{
    public class CreateModel : PageModel
    {
        public Book book = new Book();
        public string errorMessage = string.Empty;
        public string successMessage = string.Empty;

        public void OnGet()
        {

        }
        public void OnPost()
        {
            try
            {
                book.name = Request.Form["name"];
                book.author = Request.Form["author"];

                int pages;

                Int32.TryParse(Request.Form["pages"].ToString(), out pages);

                book.pages = pages;

                book.genre = Request.Form["genre"];
                book.year = Request.Form["year"];

                //backend validation 
                if (book.name.Length == 0
                    || book.author.Length == 0
                    || book.genre.Length == 0
                    || book.pages == 0
                    || book.year.Length == 0
                    )
                {
                    errorMessage = "all fields are required";
                    return;
                }

                CreateBook(book);

                successMessage = "book created correctly";

                //book.name = "";
                //book.author = "";
                //book.year = "";
                //book.pages = 0;
                //book.genre = "";
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

        }

        public void CreateBook(Book book)
        {
            dbo.bookCreate create = new dbo.bookCreate();

            create.CreateBooks(book);

        }
    }
}