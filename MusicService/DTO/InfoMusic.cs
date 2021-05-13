using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicService.DTO
{
    public class InfoMusic
    {
        public string URLBase { get; set; }
        public EndPointsDTO Endpoints{get;set;}

        public string AlbumUrl => URLBase + Endpoints.Albums;
        public string CommentsUrl => URLBase + Endpoints.Comments;
        public string PhotosUrl => URLBase + Endpoints.Photos;

    }
}
