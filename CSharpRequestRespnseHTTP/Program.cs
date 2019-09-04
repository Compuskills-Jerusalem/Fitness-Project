using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;

namespace CSharpRequestRespnseHTTP
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetRequest("https://www.google.com/");

            PostRequest("http://ptsv2.com/t/8sebg-1567542394/post");
            Console.ReadKey();
        }
        async static void GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    //string responseheader = response.ToString();
                    //Console.WriteLine(responseheader);

                    using (HttpContent content = response.Content)
                    {
                        //string myContent = await content.ReadAsStringAsync();
                        //Console.WriteLine(myContent);

                        HttpContentHeaders contentHeaders = content.Headers;
                        
                        Console.WriteLine(contentHeaders);
                    }
                    
                }
            }
        }

        async static void PostRequest(string url)
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>(key:"latitued", value:"49085904"),
                new KeyValuePair<string, string>(key:"longitude", value:"4905803")


            };
            HttpContent q = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            {              
                using (HttpResponseMessage response = await client.PostAsync( url, q))
                {
                    //string responseheader = response.ToString();
                    //Console.WriteLine(responseheader);

                    using (HttpContent content = response.Content)
                    {
                        string myContent = await content.ReadAsStringAsync();
                        Console.WriteLine(myContent);

                        HttpContentHeaders headers = content.Headers;

                        //Console.WriteLine(headers);
                    }

                }
            }
        }
    }
}
