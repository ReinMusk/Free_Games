// Gavrilov Daniil 220p
// Free_Games API
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Free_Games
{
    class Program
    {
        static void Main()
        {
            var url = $"https://www.freetogame.com/api/games?genre=MMORPG&platform=pc";

            var request = WebRequest.Create(url);

            var response = request.GetResponse();
            var httpStatusCode = (response as HttpWebResponse).StatusCode;

            if (httpStatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(httpStatusCode);
                return;
            }

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string tmp = streamReader.ReadToEnd();

                var myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(tmp);

                Random rnd = new Random();
                int value = rnd.Next(0, myDeserializedClass.Count);


                Console.WriteLine(myDeserializedClass[value].id);
                Console.WriteLine(myDeserializedClass[value].title);
                Console.WriteLine(myDeserializedClass[value].thumbnail);
                Console.WriteLine(myDeserializedClass[value].short_description);
                Console.WriteLine(myDeserializedClass[value].game_url);
                Console.WriteLine(myDeserializedClass[value].genre);
                Console.WriteLine(myDeserializedClass[value].developer);
            }

        }

        public class Root
        {
            public int id { get; set; }
            public string title { get; set; }
            public string thumbnail { get; set; }
            public string short_description { get; set; }
            public string game_url { get; set; }
            public string genre { get; set; }
            public string platform { get; set; }
            public string publisher { get; set; }
            public string developer { get; set; }
            public string release_date { get; set; }
            public string freetogame_profile_url { get; set; }
        }
    }
}
