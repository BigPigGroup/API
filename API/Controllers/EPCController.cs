using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Enums;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {

	[Route("api/[controller]")]
	[ApiController]
	public class EpcController : ControllerBase {
		[HttpPost]
		[Route("temperature")]
		public bool AddTemperature([FromBody] SensorValue input) {
			var hej = input.Value.Split("§");
			int success = 0;
			bool isOk = false;

			if (hej.Length > 1) {
				try {
					TemperatureSensor sensor = new TemperatureSensor(Int32.Parse(hej[0]),
						float.Parse(hej[1], CultureInfo.InvariantCulture.NumberFormat), DateTime.Now);
					var efContext = new ApiDataContext();
					Box box = efContext.Box.Find(Int32.Parse(hej[0]));

					if (box != null) {
						switch (input.SensorType) {
							case SensorEnum.Temperature:

								efContext.Temperature.Add(sensor);
								success = efContext.SaveChanges();

								break;
							case SensorEnum.Water:

								break;
							case SensorEnum.UV:

								break;
							case SensorEnum.Food:

								break;
							default:
								Console.WriteLine("Sensor type doesn't exist! : " + input.SensorType);

								break;
						}
					} else {
						Console.WriteLine("Box doesn't exist!");
					}
				} catch (Exception e) {
					Console.WriteLine(e);
				}
			}

			if (success > 0) {
				isOk = true;
			}

			return isOk;
		}

		// GET api/epc
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get() {
			return new string[] {"value1", "value2"};
		}

		// GET api/epc/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id) {
			return "value";
		}

		// POST api/epc
		[HttpPost]
		public void Post([FromBody] string value) { }

		// PUT api/epc/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value) { }

		// DELETE api/epc/5
		[HttpDelete("{id}")]
		public void Delete(int id) { }
	}

}