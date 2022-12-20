using Books.dto;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using Books.dbo;

namespace Books.web.Pages.Books
{
    public class IndexModel : PageModel
    {
        public List<Book> booksList;
        public void OnGet()
        {
            bookRead read = new bookRead();

            booksList = read.getBooksbyId(null);
        }
    }
}