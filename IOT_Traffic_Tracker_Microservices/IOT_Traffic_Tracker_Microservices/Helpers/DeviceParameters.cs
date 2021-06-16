using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_Device_Service.Helpers
{
    public static class DeviceParameters
    {
        public static int TimeLimit { get; set; } = 20;
        public static int AmmountOfData { get; set; } = 2;

        public static List<string> SignalProperties { get; set; }
            = new List<string>()
            {
                "Time", "SegmentId", "Speed", "Street", "Direction", "FromStreet", "ToStreet",
                "Length", "StreetHeading", "Comments", "BusCount", "MessageCount", "Hour",
                "DayOfWeek", "Month", "RecordId", "StartLat", "StartLng",
                "EndLat", "EndLng", "CommunityAreas", "ZipCodes", "Wards"
            };
    }
}
