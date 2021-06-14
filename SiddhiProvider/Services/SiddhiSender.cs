using DataProvider.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SiddhiProvider.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SiddhiProvider.Services
{
    public class SiddhiSenderc : ISiddhiSender
    {
        public async Task<string> SendData(Track track)
        {
            SiddhiInputModel inputTestModel = new SiddhiInputModel()
            {
                Speed = track.Speed,
                BusCount = track.BusCount,
                RecordId = track.RecordId
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(inputTestModel, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync("http://192.168.1.58:8006/track-analizator", data);
            string result = response.Content.ReadAsStringAsync().Result;

            return result;
        }
    }
}
