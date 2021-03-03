using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace mal
{
    class malvars
    {
        public Int32 mal_id { get; set; }
        public string title { get; set; }
        public string airing { get; set; }
        public string synopsis { get; set; }
        public string type { get; set; }
        public Int32 episodes { get; set; }
        public string rated { get; set; }
    }

    class Program
    {
        
        static async Task Main(string[] args)
        {
            using var client = new HttpClient();

            Console.WriteLine("Enter anime name");
            string animename = Console.ReadLine();
            var jikanres = await client.GetStringAsync($"https://api.jikan.moe/v3/search/anime?q={animename}");
            JObject json = JObject.Parse(jikanres);
            // Console.WriteLine(json);

            malvars result = new malvars
            {
                mal_id = (Int32)json["results"][0]["mal_id"],
                title = (string)json["results"][0]["title"],
                airing = (string)json["results"][0]["airing"],
                synopsis = (string)json["results"][0]["synopsis"],
                type = (string)json["results"][0]["type"],
                episodes = (Int32)json["results"][0]["episodes"],
                rated = (string)json["results"][0]["rated"],
                
            };

            Console.WriteLine($"Search Query: {animename}");
            Console.WriteLine($"> MAL ID: {result.mal_id}");
            Console.WriteLine($"> Title: {result.title}");
            Console.WriteLine($"> Airing: {result.airing}");
            Console.WriteLine($"> Synopsis: {result.synopsis}");
            Console.WriteLine($"> Type: {result.type}");
            Console.WriteLine($"> Episodes: {result.episodes}");
            Console.WriteLine($"> Rated: {result.rated}");

        }
    }
}