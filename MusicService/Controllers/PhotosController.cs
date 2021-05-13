using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicService.Services.Interfaces;
using MusicService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private IPhotosService _photosService;

        public PhotosController(IPhotosService _IPhotosService)
        {
            _photosService = _IPhotosService;

        }

        public async Task<List<AlbumPhotosVM>> AlbumPhotos(int id)
        {
            var AlbmumsImages = await _photosService.GetAlbumPhotosById(id);
            List<AlbumPhotosVM> ListPhotos = new List<AlbumPhotosVM>();
            ListPhotos = AlbmumsImages.Select(x => new AlbumPhotosVM { Id = x.id, Title = x.title, UrlPhoto = x.thumbnailUrl }).ToList();


            return ListPhotos;
        }
    }
}
