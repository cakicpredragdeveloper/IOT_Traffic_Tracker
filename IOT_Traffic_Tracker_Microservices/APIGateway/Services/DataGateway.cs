using DataProvider.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIGateway.Services
{
    public class DataGateway : IDataGateway
    {
        public async Task DeleteTrack(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync("http://data_service/data-service/" + id.ToString());
            }
        }

        public async Task<IEnumerable<Track>> GetAllTracks()
        {
            using (var client = new HttpClient())
            {
                using ( var response = await client.GetAsync("http://data_service/data-service/tracks"))
                {
                    string stringResponse = await response.Content.ReadAsStringAsync();
                    return  JsonConvert.DeserializeObject<IEnumerable<Track>>(stringResponse);
                }
            }
        }

        public async Task<IEnumerable<Track>> GetTracks(int maxSpeed)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("http://data_service/data-service/tracks/max-speed/" + maxSpeed.ToString()))
                {
                    string stringResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<Track>>(stringResponse);
                }
            }
        }

        public async Task<IEnumerable<Track>> GetTracksAirDistanceCondition(int airDistance)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("http://data_service/data-service/tracks/air-distance/" + airDistance.ToString()))
                {
                    string stringResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<Track>>(stringResponse);
                }
            }
        }

        public async Task<Track> UpdateTrack(int id, Track track)
        {

            var json = JsonConvert.SerializeObject(track);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                using (var response = await client.PutAsync("http://data_service/data-service/tracks/" + id.ToString(), data))
                {
                    string stringResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Track>(stringResponse);
                }
            }
        }
    }
}
