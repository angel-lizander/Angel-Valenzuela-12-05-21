using MusicService.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicService.Services.Interfaces
{
    public interface ICommentsService
    {
        Task<List<CommentsDTO>> GetCommentsPhotoById(int id);
    }
}
