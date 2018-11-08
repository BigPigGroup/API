using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Migrations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Models
{
    [Table("Temperature")]
    public partial class TemperatureSensor
    {
        [Key]
        [ForeignKey("Box")]
        public int BoxNo { get; set; }
        public float TemperatureValue { get; set; }
        
        public virtual Box Box { get; set; }
    }
}
