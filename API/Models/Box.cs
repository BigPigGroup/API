using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models {

	[Table("Box")]
	public class Box {
		[Key]
		public int BoxNo { get; set; }
		public virtual TemperatureSensor TemperatureSensor { get; set; }
	}

}