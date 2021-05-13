using Microsoft.Extensions.Options;
using MusicService.DTO;
using MusicService.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MusicService.Services
{
    public class AlbumService : IAlbumsService
    {
        private HttpClient _client;
        private readonly IOptions<InfoMusic> _config;


        public AlbumService(HttpClient client, IOptions<InfoMusic> config)
        {
            _client = client;
            _config = config;
        }

        public async Task<List<AlbumsDTO>> GetAlbums()
        {
            List<AlbumsDTO> AlbumsData = new List<AlbumsDTO>();
            string Albums = await _client.GetStringAsync(_config.Value.AlbumUrl);
            AlbumsData = JsonConvert.DeserializeObject<List<AlbumsDTO>>(Albums);
            return AlbumsData;
        }
    }
}
