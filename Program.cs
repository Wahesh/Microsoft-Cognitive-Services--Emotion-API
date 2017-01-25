using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;
using Newtonsoft;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Paste the image url");
            string url = Console.ReadLine ();
            MakeRequest(url);
            Console.ReadLine();
        }

        static async void MakeRequest( string url)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
 

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "Copy Subscription Key from Website"

            var uri = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize?" + queryString;

            HttpResponseMessage response;
        
            string json = "{ \"url\":\"http://images.shape.mdpcdn.com/sites/shape.com/files/styles/story_detail/public/story/crying-for-no-reason_0.jpg?itok=17PRimp7 \"}";
            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes(json);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                 string jsonser = Newtonsoft.Json.JsonConvert.SerializeObject(response);
                Console.Write(jsonser);

                var ob = await response.Content.ReadAsStringAsync();
                Console.WriteLine(ob);

                //Parse the received JSON 

                char[] d = { ',' };
                string[] ob1 = ob.Split(d);


                double anger = Convert.ToDouble(ob1[4].Split(':')[2]);  // convert to int for manipulation if needed 
                Console.WriteLine("anger" + ob1[4].Split(':')[2]);

                double contempt = Convert.ToDouble(ob1[5].Split(':')[1]);
                Console.WriteLine("contempt:" + ob1[5].Split(':')[1]);

                double disgust = Convert.ToDouble(ob1[6].Split(':')[1]);
                Console.WriteLine("disgust:" + ob1[6].Split(':')[1]);

                double fear = Convert.ToDouble(ob1[7].Split(':')[1]);
                Console.WriteLine("fear:" + ob1[7].Split(':')[1]);

                double happiness = Convert.ToDouble(ob1[8].Split(':')[1]);
                Console.WriteLine("happiness:" + ob1[8].Split(':')[1]);

                double neutral = Convert.ToDouble(ob1[9].Split(':')[1]);
                Console.WriteLine("neutral:" + ob1[9].Split(':')[1]);

                double sadness = Convert.ToDouble(ob1[10].Split(':')[1]);
                Console.WriteLine("sadness:" + ob1[10].Split(':')[1]);

                double surprise = Convert.ToDouble(ob1[11].Split(':', '}')[1]);
                Console.WriteLine("surprise:" + ob1[11].Split(':', '}')[1]);


            }

        }
    }
}
