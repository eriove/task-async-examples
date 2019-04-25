using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Lightning.Library;

namespace Lightning.AspNet.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly WorkerClass _workerClass;

        public ValuesController()
        {
            _workerClass = new WorkerClass();
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //_workerClass.DoWorkAsync().Wait();
            _workerClass.DoWorkThreadSyncAsync().Wait();
            stopwatch.Stop();
            return $"{stopwatch.Elapsed.TotalSeconds:F6} s\n";
        }

        //public async Task<string> GetAsync(int id)
        //{
        //    Stopwatch stopwatch = new Stopwatch();
        //    stopwatch.Start();
        //    await _workerClass.DoWorkAsync();
        //    //await _workerClass.DoWorkThreadSyncAsync();
        //    stopwatch.Stop();
        //    return $"{stopwatch.Elapsed.TotalSeconds:F6} s\n";
        //}


        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
