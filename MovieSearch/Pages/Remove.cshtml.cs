using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieSearch.Pages
{
    public class RemoveModel : PageModel
    {
        String textReader = null;
        public string Message { get; set; }
        public void OnGet()
        {

            //Taking user entry

            string userEntry = Request.QueryString.Value;
            userEntry = userEntry.Split("=")[1];
            userEntry = userEntry.Replace("+", " ");

            try
            {
                //Establishing a new SQLite Connection
                SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=movielibrary.db;Version=3;New=False;Compress=True;");
                sQLiteConnection.Open();
                SQLiteCommand sQLiteCommand = sQLiteConnection.CreateCommand();

                //Giving DELETE command to remove an entry from our table
                sQLiteCommand.CommandText = "DELETE FROM movielibrary WHERE Name = " + "'" + userEntry + "'";

                sQLiteCommand.ExecuteNonQuery();

                Message = "Removed!";

            }catch(Exception e)
            {
                Message = "Opreation Failed";
            }
        }
    }
}