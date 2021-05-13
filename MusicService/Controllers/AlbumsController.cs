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
    public class AlbumsController : ControllerBase
    {
        private IAlbumsService _albumService;
        public AlbumsController(IAlbumsService _IAlbumsService)
        {
            _albumService = _IAlbumsService;

        }

        [HttpGet]
        public async Task<List<AlbumsVM>> GetAll()
        {
            var Albmums = await _albumService.GetAlbums();
            List<AlbumsVM> ListAlbums = new List<AlbumsVM>();
            ListAlbums = Albmums.Select(x => new AlbumsVM { Id = x.id, Title = x.title }).ToList();
            return ListAlbums;
        }
    }
}
