using MusicService.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicService.Services.Interfaces
{
    public interface IPhotosService
    {
        Task<List<PhotosDTO>> GetAlbumPhotosById(int id);
    }
}
