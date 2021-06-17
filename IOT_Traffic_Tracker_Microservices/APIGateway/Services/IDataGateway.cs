using DataProvider.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Services
{
    public interface IDataGateway
    {
        Task<IEnumerable<Track>> GetAllTracks();
        Task<Track> UpdateTrack(int id, Track track);
        Task DeleteTrack(int id);
        Task<IEnumerable<Track>> GetTracks(int maxSpeed);
        Task<IEnumerable<Track>> GetTracksAirDistanceCondition(int airDistance);
        Task<Track> GetTrack(int id);
    }
}
