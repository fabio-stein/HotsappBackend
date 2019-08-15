using DbManager;
using System;
using System.Linq;
using Flurl.Http;
using System.Threading;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                new Thread(() => {
                    Get(i);
                }).Start();
                Thread.Sleep(50);
            }
            Console.ReadLine();
        }

        //https://www.googleapis.com/youtube/v3/search?q=&maxResults=50&type=video&part=snippet,id&key=AIzaSyAsMiGn7Z09Yh1zYyJlmPf0ak8XwZ7lFJY&videoEmbeddable=true
        //AIzaSyCju791bC9hkCE8thtQZB25LePTpvBCoWc
        public static async void Get(int i)
        {
            var url = "https://www.googleapis.com/youtube/v3/search?part=snippet&q="+i+ "&maxResults=50&type=video&key=AIzaSyAsMiGn7Z09Yh1zYyJlmPf0ak8XwZ7lFJY";
            var t = url
                .WithHeader("Referer", "affectiva.github.io")
                .GetStringAsync().Result.IndexOf("youtube#searchListResponse") != -1;
            Console.WriteLine(t+" - "+i);
        }
    }
}
