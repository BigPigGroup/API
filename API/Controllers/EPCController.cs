using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EpcController : ControllerBase {
        [HttpPost]
        public bool AddTemperature([FromBody] SensorValue input) {
            
            
            
            return true;
        }
        
        
        // GET api/epc
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET api/epc/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id) {
            return "value";
        }

        // POST api/epc
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/epc/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/epc/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
