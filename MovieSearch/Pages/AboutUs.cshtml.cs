using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieSearch.Pages
{
    public class AboutUs : PageModel
    {
        String textReader = null;
        public string Message { get; set; }
        public void OnGet()
        {
           
        }
    }
}