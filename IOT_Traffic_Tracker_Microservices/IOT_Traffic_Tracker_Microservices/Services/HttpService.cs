using Newtonsoft.Json;
using Sensor_Device_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sensor_Device_Service.Services
{
    public class HttpService : IHttpService
    {
        public async Task<string> PostRequest(string url, IEnumerable<Signal> dataFromSensor)
        {
            //IEnumerable<KeyValuePair<string, IEnumerable<Signal>>> queries = new List<KeyValuePair<string, IEnumerable<Signal>>>()
            //{
            //    new KeyValuePair<string, IEnumerable<Signal>>("tracks", dataFromSensor)
            //};


            //HttpContent content = new Conte

            var json = JsonConvert.SerializeObject(dataFromSensor);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var response = await client.PostAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;

            return result;
        }
    }
}
