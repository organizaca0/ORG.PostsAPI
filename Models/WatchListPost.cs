namespace ORG.PostsAPI.Models
{
    public class WatchListPost
    {
        public int WatchListPostId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }  // Navigation property to Post
        public string Title { get; set; }
        public string ReadTime { get; set; }
    }
}