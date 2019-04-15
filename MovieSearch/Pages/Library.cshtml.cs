using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieSearch.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class LibraryModel : PageModel
    {
        public string Message { get; set; }
        String line;
        public List<string> display = new List<string> { };
        public List<string> displayCopies = new List<string> { };

        public void OnGet()
        {
            try
            {
                //Establishing new SQLite Connection
                SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=movielibrary.db;Version=3;New=True;");
                sQLiteConnection.Open();
                SQLiteCommand sQLiteCommand = sQLiteConnection.CreateCommand();

                //Giving SELECT command to show table entries
                sQLiteCommand.CommandText = "SELECT * FROM movielibrary";
                SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
                while (sQLiteDataReader.Read())
                {

                    //Fetching data from the table and adding it to list
                    line = sQLiteDataReader.GetString(0);
                    display.Add(line);
                    displayCopies.Add(sQLiteDataReader.GetString(1));
                }
                
            }
            catch (Exception e)
            {
                Message = "Failed";
            }
        }
    }
}
