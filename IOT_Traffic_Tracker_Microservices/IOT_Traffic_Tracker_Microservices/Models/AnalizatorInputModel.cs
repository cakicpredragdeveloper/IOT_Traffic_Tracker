using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_Device_Service.Models
{
    public class AnalizatorInputModel
    {
        public int? Speed { get; set; }
        public int? BusCount { get; set; }
        public string RecordId { get; set; }
    }
}
