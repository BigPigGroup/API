using API.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace API.Models {

	public class SensorValue {
		public string Value { get; }

		[JsonConverter(typeof(StringEnumConverter))] //Maps a string to an enum
		public SensorEnum SensorType { get; }

		public SensorValue(string value, SensorEnum sensorType) {
			Value = value;
			SensorType = sensorType;
		}
	}

}