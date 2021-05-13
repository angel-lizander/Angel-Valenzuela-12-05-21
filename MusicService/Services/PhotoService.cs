using Microsoft.Extensions.Options;
using MusicService.DTO;
using MusicService.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MusicService.Services
{
    public class PhotoService : IPhotosService
    {
        private HttpClient _client;
        private readonly IOptions<InfoMusic> _config;

        public PhotoService(HttpClient client, IOptions<InfoMusic> config)
        {
            _client = client;
            _config = config;
        }

        public async Task<List<PhotosDTO>> GetAlbumPhotosById(int id)
        {
            List<PhotosDTO> PhotosData = new List<PhotosDTO>();
            string Photos = await _client.GetStringAsync(_config.Value.PhotosUrl);
            PhotosData = JsonConvert.DeserializeObject<List<PhotosDTO>>(Photos).Where(Comments => Comments.albumId == id).ToList();
            return PhotosData;
        }
    }
}
