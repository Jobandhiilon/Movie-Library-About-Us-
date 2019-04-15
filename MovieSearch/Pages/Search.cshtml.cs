using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieSearch.Pages
{
    public class SearchModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {

            try
            {
                //Establishing a new SQLite Connection
                SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=movielibrary.db;Version=3;New=False;Compress=True;");
                sQLiteConnection.Open();
                SQLiteCommand sQLiteCommand = sQLiteConnection.CreateCommand();
                sQLiteCommand.CommandText = "CREATE TABLE movielibrary (Name varchar, Copies varchar)";
                sQLiteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
        }
    }
}
