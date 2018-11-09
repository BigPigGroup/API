using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models {

	[Table("Box")]
	public class Box {
		public Box(int boxId) {
			BoxId = boxId;
		}

		[Key]
		[Column("box_no")]
		public int BoxId { get; set; }
		
		public virtual TemperatureSensor TemperatureSensor { get; set; }
	}

}