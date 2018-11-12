using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models {

	public class Box {
		
		public int BoxNo { get; set; }

		public virtual TemperatureSensor TemperatureSensor { get; set; }
	}

}