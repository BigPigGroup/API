using API.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace API.Models {

	public class SensorValue {
		public int BoxNo { get; }
		public string Value { get; }

		[JsonConverter(typeof(StringEnumConverter))] //Maps a string to an enum
		public SensorEnum SensorType { get; }

		public SensorValue(string value, SensorEnum sensorType, int boxNo) {
			Value = value;
			SensorType = sensorType;
			BoxNo = boxNo;
		}
	}

}