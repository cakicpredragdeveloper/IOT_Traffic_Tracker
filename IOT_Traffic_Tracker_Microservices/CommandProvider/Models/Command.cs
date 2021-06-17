using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace CommandProvider.Models
{
    public class Command
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }
        public DateTime DateTime { get; set; }

        public string RecordId { get; set; }
        public string Status { get; set; }

        public Command(int code)
        {
            this.Code = code;
            if (code == 0)
                Description = "Safe situation!Reduce amount of data to be processed and increase the time interval";
            else Description = "Danger situation! Increase amount of data to be processed and reducing the time interval!";
        }

        public async Task Execute()
        {
            var client = new HttpClient();
            string url = "http://sensor_device_service/sensor-device-service/danger-mode-on";

            if (this.Code == 0)
                url = "http://sensor_device_service/sensor-device-service/normal-mode-on";

            var response = await client.GetAsync(url);
        }
    }
}
