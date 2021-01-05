using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;

namespace Speaker.API
{
    public static class GetSpeakers
    {
        [FunctionName("GetSpeakers")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            List<Speaker> speakers = new List<Speaker>(){
                new Speaker() { Name ="Simon Collins", Image="speaker-1.png", Bio = "Simon is designer and partner at Fictivekin and has worked in a variety of situations for bands, record labels, governments, polar explorers, and most other things..."},
                new Speaker() { Name ="Stephanie Troeth",Image="speaker-2.png", Bio = "Stephie is a user experience researcher and designer. In over 15 years of working on the web, she has worn many hats, including a product lead for a tech startup in publishing..."},
                new Speaker() { Name ="Harry Roberts", Image="speaker-3.png",Bio = "Harry is a freelance designer, developer, writer, speaker and front-end architect from the UK, previously working as Senior UI Developer for Sky. He Tweets at..."},
                new Speaker() { Name ="Geri Coady", Image="speaker-4.png",Bio = "Geri  is a freelance designer, developer, writer, speaker and front-end architect from the UK, previously working as Senior UI Developer for Sky. He Tweets at..."},
                new Speaker() { Name ="Andy Budd", Image="speaker-5.png",Bio = "Andy  is a freelance designer, developer, writer, speaker and front-end architect from the UK, previously working as Senior UI Developer for Sky. He Tweets at..."},
                new Speaker() { Name ="Christian Lauke", Image="speaker-6.png",Bio = "Christian  is a freelance designer, developer, writer, speaker and front-end architect from the UK, previously working as Senior UI Developer for Sky. He Tweets at..."}

            };
            log.LogInformation("C# HTTP trigger function processed a request.");

            var json = JsonConvert.SerializeObject(speakers, Formatting.Indented);
            
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

        }
    }

    public class Speaker{
        public string   Name { get; set; }
        public string   Image { get; set; }
        public string Bio { get; set; }
        
    }
}
