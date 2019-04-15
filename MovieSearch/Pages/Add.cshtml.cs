using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieSearch.Pages
{
    public class AddModel : PageModel
    {
        String textReader = null;
        public string Message { get; set; }
        public void OnGet()
        {

            //Taking user entry
            string userEntry = Request.QueryString.Value;
            string copies = userEntry.Split("=")[2];
            userEntry = userEntry.Split("=")[1].Split("&")[0];
            userEntry = userEntry.Replace("+", " ");


            //Establishing a new SQLite Connection
            SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=movielibrary.db;Version=3;New=False;Compress=True;");
            sQLiteConnection.Open();
            SQLiteCommand sQLiteCommand = sQLiteConnection.CreateCommand();

            //Giving INSERT command to add a new entry to our table
            sQLiteCommand.CommandText = "INSERT INTO movielibrary (Name, Copies) VALUES ("+"'"+userEntry+ "'"+","+"'"+copies+"'"+")";
            sQLiteCommand.ExecuteNonQuery();
        }
    }
}