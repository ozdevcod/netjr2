using Books.dbo;
using Books.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.web.Pages.Books
{
    public class UpdateModel : PageModel
    {
        public string errorMessage = string.Empty;
        public string successMessage = string.Empty;

        public Book book = new Book();

        public List<Book> BooksList;

        public void OnGet()
        {
            getBookInfo();
        }

        public void OnPost()
        {

            int iPages;
            Int32.TryParse(Request.Form["pages"].ToString(), out iPages);

            int iId;
            Int32.TryParse(Request.Form["idHidden"].ToString(), out iId);

            book.id = iId;
            book.name = Request.Form["name"];
            book.author = Request.Form["author"];
            book.pages = iPages;
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

            updateBookInfo(book);

            successMessage = "book updated correctly";

        }

        public void getBookInfo()
        {
            string sBookId = Request.Query["id"].ToString();
            int iBookId = int.Parse(sBookId);
            book.id = iBookId;

            bookRead read = new bookRead();

            BooksList = read.getBooksbyId(iBookId);

            if (BooksList.Count == 1)
            {
                book = BooksList.FirstOrDefault();
            }
        }

        public void updateBookInfo(Book book)
        {
            bookUpdate update = new dbo.bookUpdate();

            update.UpdateBook(book);

        }
    }
}