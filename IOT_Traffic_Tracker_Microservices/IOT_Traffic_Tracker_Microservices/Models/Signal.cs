using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_Device_Service.Models
{
    public class Signal
    {
        public DateTime Time { get; set; }
        public int? Segment { get; set; }
        public int? Speed { get; set; }
        public string Street { get; set; }
        public string Direction { get; set; }
        public string FromStreet { get; set; }
        public string ToStreet { get; set; }
        public double? Length { get; set; }
        public string StreetHeading { get; set; }
        public string Comments { get; set; }
        public int? BusCount { get; set; }
        public int? MessageCount { get; set; }
        public int? Hour { get; set; }
        public int? DayOfWeek { get; set; }
        public int? Month { get; set; }
        public string RecordId { get; set; }
        public double? StartLatitude { get; set; }
        public double? StartLongitude { get; set; }
        public double? EndLatitude { get; set; }
        public double? EndLongitude { get; set; }
        public int? CommunityAreas { get; set; }
        public int? ZipCodes { get; set; }
        public int? Wards { get; set; }
    }
}
