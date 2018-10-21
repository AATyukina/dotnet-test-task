using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Task3.Models;

namespace Task3.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return"Enter any string after api/values";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            
            HashMD5 hhmd = new HashMD5(id);
            string tmp = hhmd.Hashstr();
            string serialized = JsonConvert.SerializeObject(hhmd.Hashstr());

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            Log.Write(Request.ToString() +" " + elapsedTime + " "  + id.Length +"\n");
            return serialized;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            int a = 1;
            //вычленить файл 
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
