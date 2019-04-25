using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lightning.Library;
using Microsoft.AspNetCore.Mvc;

namespace Lightning.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly WorkerClass _workerClass;

        public ValuesController(WorkerClass workerClass)
        {
            _workerClass = workerClass;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<string>> Get(int id)
        //{
        //    Stopwatch stopwatch = new Stopwatch();
        //    stopwatch.Start();
        //    await _workerClass.DoWorkAsync();
        //    //await _workerClass.DoWorkThreadSyncAsync();
        //    stopwatch.Stop();
        //    return $"{stopwatch.Elapsed.TotalSeconds:F6} s\n";
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _workerClass.DoWorkAsync().Wait();
            //_workerClass.DoWorkThreadSyncAsync().Wait();
            stopwatch.Stop();
            return $"{stopwatch.Elapsed.TotalSeconds:F6} s\n";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
