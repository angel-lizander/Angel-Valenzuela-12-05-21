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
    public class CommentsController : ControllerBase
    {
        private ICommentsService _commentService;

        public CommentsController(ICommentsService _ICommentsService)
        {
            _commentService = _ICommentsService;

        }
        public async Task<List<CommentsVM>> PhotoComments(int id)
        {
            var AlbmumsImages = await _commentService.GetCommentsPhotoById(id);
            List<CommentsVM> ListComments = new List<CommentsVM>();
            ListComments = AlbmumsImages.Select(x => new CommentsVM { body = x.body, name = x.name }).ToList();
            return ListComments;
        }
    }
}
