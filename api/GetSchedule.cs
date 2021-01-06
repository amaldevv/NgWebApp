using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;

using System.Text;

namespace api
{
    public static class GetSchedule
    {
        [FunctionName("GetSchedule")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function,  "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            List<Schedule> scheule = new List<Schedule>(){
                new Schedule() { Name ="THE DESIGNER’S GUIDE TO BEING ESSENTIAL", Time = "10am to 10:30am",  Image="speaker-1.png", Bio = "Simon is designer and partner at Fictivekin and has worked in a variety of situations for bands, record labels, governments, polar explorers, and most other things"},
                new Schedule() { Name ="MODULAR DESIGN AT WORK", Time = "10:45am to 11:30am", Image="speaker-2.png",Bio= "Simon is designer and partner at Fictivekin and has worked in a variety of situations for bands, record labels, governments, polar explorers, and most other things"},
                new Schedule() { Name ="AN INTRODUCTION TO TOUCH AND POINTER EVENTS", Time = "12:00pm to 01:30pm", Image="speaker-3.png",Bio = "Simon is designer and partner at Fictivekin and has worked in a variety of situations for bands, record labels, governments, polar explorers, and most other things"},
                new Schedule() { Name ="WEB FONTS PERFORMANCE", Time = "02:00pm to 03.30pm", Image="speaker-4.png",Bio = "Simon is designer and partner at Fictivekin and has worked in a variety of situations for bands, record labels, governments, polar explorers, and most other things"}
               
            };

            var json = JsonConvert.SerializeObject(scheule, Formatting.Indented);
            
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
        }
    }

    public class Schedule{
        public string   Name { get; set; }
        public string   Image { get; set; }
        public string Bio { get; set; }
        public string Time { get; set; }
        
    }
}


