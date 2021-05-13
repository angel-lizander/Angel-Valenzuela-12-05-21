using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MusicLibrary.DTO;
using MusicLibrary.ViewModels;
using MusicService.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace MusicLibrary.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IOptions<DTO.MusicMicroService> _config;

        public AlbumsController(IOptions<DTO.MusicMicroService> config)
        {
            _config = config;
        }

        // GET: Albums

        public async Task<ActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                string Albums = await client.GetStringAsync($"{_config.Value.AlbumUrl}/GetAll");
                var ListAlbums = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AlbumsVM>>(Albums);
                return View(ListAlbums);

            }
        }

        public async Task<List<AlbumPhotosVM>> AlbumPhotos(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string AlbumsPhotos = await client.GetStringAsync($"{_config.Value.PhotosUrl}/AlbumPhotos?id={id}");
                var ListAlbums = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AlbumPhotosVM>>(AlbumsPhotos);
                return ListAlbums;

            }
        }

        public async Task<List<CommentsVM>> PhotoComments(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string PhotosComment = await client.GetStringAsync($"{_config.Value.CommentsUrl}/PhotoComments?id={id}");
                var ListComments = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CommentsVM>>(PhotosComment);
                return ListComments;

            }
        }





    }
}
