namespace MusicLibrary.DTO
{
    public class MusicMicroService
    {
        public string URLBase { get; set; }
        public EndPointsDTO Endpoints{get;set;}

        public string AlbumUrl => URLBase + Endpoints.Albums;
        public string CommentsUrl => URLBase + Endpoints.Comments;
        public string PhotosUrl => URLBase + Endpoints.Photos;

    }
}
