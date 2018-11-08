using System.Runtime.Serialization;

namespace API.Models {

	[DataContract]
	public class SensorValue {
		[DataMember(Name = "value")]
		public string Value { get; }
	}

}