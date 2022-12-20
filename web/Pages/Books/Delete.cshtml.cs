using Books.dbo;
using Books.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.web.Pages.Books
{
    public class DeleteModel : PageModel
    {
        public string errorMessage = string.Empty;
        public string successMessage = string.Empty;

        public Book book = new Book();

        public List<Book> BooksList;

        public void OnGet()
        {
            bookRead read = new bookRead();

            string sBookId = Request.Query["id"].ToString();
            int iBookId = int.Parse(sBookId);

            BooksList = read.getBooksbyId(iBookId);

            if (BooksList.Count == 1)
            {
                book = BooksList.FirstOrDefault();
            }
        }

        public void OnPost()
        {
            int iId;
            Int32.TryParse(Request.Form["idHidden"].ToString(), out iId);

            deleteBookInfo(iId);
        }

        public void deleteBookInfo(int id)
        {
            bookDelete bookDelete = new bookDelete();

            bookDelete.deleteBookbyId(id);
            successMessage = "book deleted correctly";

        }
    }
}