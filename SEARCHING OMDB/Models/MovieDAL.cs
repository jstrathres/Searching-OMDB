using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using System.Net;

namespace SEARCHING_OMDB.Models
{
    public class MovieDAL
    {
        public static MovieModel GetMovie(string title)
        {
            //Will need to adjust URL
            //SetUp -copy link
            string key = Secret.apiKey;
            string url = $"http://www.omdbapi.com/?t={title}&apikey={key}";


            //request -pulls from url(above), saves. 
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            //Convert to JSON.  Streamreader, then converts to JSON
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();


            //Adjust Names to match class naem
            //Convert to C#. Pass JSON in
            MovieModel result = JsonConvert.DeserializeObject<MovieModel>(JSON);
            return result;
        }
    }
}
