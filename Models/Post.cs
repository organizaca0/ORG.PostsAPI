namespace ORG.PostsAPI.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int WatchListId { get; set; }  // Foreign key to WatchList
        public WatchList WatchList { get; set; }  // Navigation property to WatchList
        public string Title { get; set; }
        public string Content { get; set; }
        public int PositiveScore { get; set; }
        public int NegativeScore { get; set; }
        public string ReadTime { get; set; }  // Added ReadTime property
    }
}
