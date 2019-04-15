using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace MovieSearch.Pages
{
    public class UpdateModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet()
        {
            //Taking user entry

            string userEntry = Request.QueryString.Value;
            string copies = userEntry.Split("=")[2];
            userEntry = userEntry.Split("=")[1].Split("&")[0];
            userEntry = userEntry.Replace("+", " ");

            try
            {
                //Establishing a new SQLite Connection
                SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=movielibrary.db;Version=3;New=False;Compress=True;");
                sQLiteConnection.Open();
                SQLiteCommand sQLiteCommand = sQLiteConnection.CreateCommand();

                //Giving DELETE command to remove an entry from our table
                sQLiteCommand.CommandText = "UPDATE movielibrary SET Copies="+copies+ " WHERE Name = " + "'" + userEntry + "'";
                sQLiteCommand.ExecuteNonQuery();

                Message = "Updated!";

            }
            catch (Exception e)
            {
                Message = "Opreation Failed";
            }
        }
    }
}
