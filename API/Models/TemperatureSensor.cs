using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace API.Models {

	public partial class TemperatureSensor {

		public TemperatureSensor(float temperatureValue, DateTime ctsNo, int boxNo) {
			TemperatureValue = temperatureValue;
			CtsNo = ctsNo;
			BoxNo = boxNo;
		}

		public float TemperatureValue { get; set; }

		public DateTime CtsNo { get; set; }
		
		public int BoxNo { get; set; }

		public virtual Box Box { get; set; }
	}


}