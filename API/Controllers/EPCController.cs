using System;
using System.Collections.Generic;
using System.Globalization;
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
		public bool AddTemperature([FromBody] ListSensorObject list) {
			var success = 0;
			var isOk = false;

			foreach (var jsonSensor in list.ListOfSensors) {
				try {
					var sensor = new TemperatureSensor(float.Parse(jsonSensor.Value, CultureInfo.InvariantCulture.NumberFormat), DateTime.Now, jsonSensor.BoxNo);
					var efContext = new ApiDataContext();
					var box = efContext.Box.Find(jsonSensor.BoxNo);

					if (box != null) {
						switch (jsonSensor.SensorType) {
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
								Console.WriteLine("Sensor type doesn't exist! : " + jsonSensor.SensorType);

								break;
						}
					} else {
						Console.WriteLine("Box doesn't exist!");
					}
				} catch (Exception e) {
					Console.WriteLine(e);
				}

				if (success > 0) {
					isOk = true;
				}
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