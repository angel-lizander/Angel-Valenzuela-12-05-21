using Microsoft.Extensions.Options;
using MusicService.DTO;
using MusicService.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MusicService.Services
{
    public class CommentService : ICommentsService
    {

        private HttpClient _client;
        private readonly IOptions<InfoMusic> _config;

        public CommentService(HttpClient client, IOptions<InfoMusic> config)
        {
            _client = client;
            _config = config;
        }
        public async Task<List<CommentsDTO>> GetCommentsPhotoById(int id)
        {
            List<CommentsDTO> CommentsData = new List<CommentsDTO>();
            string Comments = await _client.GetStringAsync(_config.Value.CommentsUrl);
            CommentsData = JsonConvert.DeserializeObject<List<CommentsDTO>>(Comments).Where(Photos => Photos.postId == id).ToList();
            return CommentsData;
        }
    }
}
