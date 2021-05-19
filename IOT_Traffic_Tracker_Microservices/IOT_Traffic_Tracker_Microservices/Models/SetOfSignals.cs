using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_Device_Service.Models
{
    public class SetOfSignals
    {
        public List<Signal> Tracks { get; set; }
            = new List<Signal>();
    }
}
