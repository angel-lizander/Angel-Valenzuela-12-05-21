using Moq;
using MusicService.Controllers;
using MusicService.DTO;
using MusicService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestMusicLibrary
{
    public class AlbumTest
    {
        private readonly AlbumsController _target;

        public AlbumTest()
        {
            var productMock = new Mock<IAlbumsService>();
            productMock.Setup(p => p.GetAlbums())
                .ReturnsAsync(new List<AlbumsDTO>
                {
                     new AlbumsDTO
                    {
                        userId = 1,
                        id = 1,
                        title= "quidem molestiae enim"
                    }
                });

            _target = new AlbumsController(productMock.Object);



        }

        [Fact]
        public async Task GetAlbums()
        {
            Assert.True((await _target.GetAll()).Count == 1);
        }


    }
}
