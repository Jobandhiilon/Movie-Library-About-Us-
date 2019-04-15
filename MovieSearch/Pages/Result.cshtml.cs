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
    public class ResultModel : PageModel
    {
        public string JSONresponse { get; set; }
        public string Message { get; set; }
        public string title;
        public string rating;
        public string moviePosterLink;
        public string language;
        public string movieBio;
        public string movieReleaseDate;

        public void OnGet()
        {

            //Getting user entry
            string userEntry = Request.QueryString.Value;
            userEntry = userEntry.Split("=")[1];

            if (userEntry == null) {
                Response.Redirect("/Search");
            }
            else {

                //Making a new HTTP request (Calling API)
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.themoviedb.org/3/search/movie?api_key=a3bdaae66f8cf705750820e17c0e9471&query=" + userEntry);
                try
                {
                    //Recieving response from the API
                    WebResponse response = httpWebRequest.GetResponse();
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                        JSONresponse = reader.ReadToEnd();

                        dynamic data = JObject.Parse(JSONresponse);
                        try {

                            //Parsing JSON

                            title = data.results[0].original_title;
                            rating = data.results[0].vote_average;
                            moviePosterLink = "https://image.tmdb.org/t/p/w300/" + data.results[0].poster_path;
                            language = data.results[0].original_language;
                            movieBio = data.results[0].overview;
                            movieReleaseDate = data.results[0].release_date;
                        }
                        catch (Exception e)
                        {
                            Message = "Sorry no movie with this name found. Please try again.";
                        }
                    }
                }


                catch (WebException ex)
                {
                    Message = "Something went wrong. Please try again.";
                }

            }
        }
    }
}
