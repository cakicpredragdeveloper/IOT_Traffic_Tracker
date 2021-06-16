using DataProvider.Entities;
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
            using var client = new HttpClient();
            var response = await client.DeleteAsync("http://data_service/data-service/" + id.ToString());
        }

        public async Task<IEnumerable<Track>> GetAllTracks()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("http://data_service/data-service/tracks");
            return (IEnumerable<Track>)await JsonSerializer.DeserializeAsync<IEnumerable<Task>>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<IEnumerable<Track>> GetTracks(int maxSpeed)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("http://data_service/data-service/tracks/max-speed/" + maxSpeed.ToString());
            return (IEnumerable<Track>)await JsonSerializer.DeserializeAsync<IEnumerable<Task>>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<IEnumerable<Track>> GetTracksAirDistanceCondition(int airDistance)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("http://data_service/data-service/tracks/air-distance/" + airDistance.ToString());
            return (IEnumerable<Track>)await JsonSerializer.DeserializeAsync<IEnumerable<Task>>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<Track> UpdateTrack(int id, Track track)
        {
            var json = JsonSerializer.Serialize(track);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var response = await client.PutAsync("http://data_service/data-service/tracks/" + id.ToString(), data);
            return (Track)await JsonSerializer.DeserializeAsync<IEnumerable<Task>>(await response.Content.ReadAsStreamAsync());
        }
    }
}
