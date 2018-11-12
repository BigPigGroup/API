using System.Collections.Generic;

namespace API.Models {

	public class ListSensorObject {
		public List<SensorValue> ListOfSensors { get; set; }

		public ListSensorObject(List<SensorValue> listOfSensors) {
			ListOfSensors = listOfSensors;
		}
	}

}