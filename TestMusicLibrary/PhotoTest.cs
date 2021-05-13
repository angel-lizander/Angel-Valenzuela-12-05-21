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
    public class PhotoTest
    {
        private readonly PhotosController _target;

        public PhotoTest()
        {
            var productMock = new Mock<IPhotosService>();
            productMock.Setup(p => p.GetAlbumPhotosById(1))
                .ReturnsAsync(new List<PhotosDTO>
                {
                     new PhotosDTO
                    {
                        albumId = 1,
                        id = 1,
                        title= "accusamus beatae ad facilis cum similique qui sunt",
                        url="https://via.placeholder.com/600/92c952",
                        thumbnailUrl="https://via.placeholder.com/150/92c952"
                    }
                });

            _target = new PhotosController(productMock.Object);



        }

        [Fact]
        public async Task GetAllPhotosByCommentId()
        {

            var result = await _target.AlbumPhotos(1);
            Assert.Equal(1, result.First().Id);
        }


    }
}
