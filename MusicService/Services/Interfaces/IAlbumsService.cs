using MusicService.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicService.Services.Interfaces
{
    public interface IAlbumsService
    {
        Task<List<AlbumsDTO>> GetAlbums();
    }
}
