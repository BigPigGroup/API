using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace API.Models {

	[Table("Temperature")]
	public partial class TemperatureSensor {
		public TemperatureSensor(int boxId, float temperatureValue, DateTime cts) {
			BoxId = boxId;
			TemperatureValue = temperatureValue;
			Cts = cts;
		}

		[ForeignKey("Box")]
		[Column("box_no")]
		public int BoxId { get; set; }

		[Column("temperature")]
		public float TemperatureValue { get; set; }

		[Column("c_ts")]
		public DateTime Cts { get; set; }

		
		public virtual Box Box { get; set; }
	}

}