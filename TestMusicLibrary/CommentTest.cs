using Moq;
using MusicService.Controllers;
using MusicService.DTO;
using MusicService.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestMusicLibrary
{
    public class CommentTest
    {
        private readonly CommentsController _target;

        public CommentTest()
        {
            var productMock = new Mock<ICommentsService>();
            productMock.Setup(p => p.GetCommentsPhotoById(1))
                .ReturnsAsync(new List<CommentsDTO>
                {
                     new CommentsDTO
                    {
                        postId = 1,
                        id = 1,
                        name= "name",
                        email="Eliseo@gardner.biz",
                        body="laudantium enim quasi est quidem magnam voluptate"
                    }
                });

            _target = new CommentsController(productMock.Object);



        }

        [Fact]
        public async Task GetAlbums()
        {
            var result = await _target.PhotoComments(1);
            Assert.Equal("name", result.First().name);
        }


    }
}
