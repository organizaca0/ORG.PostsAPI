namespace ORG.PostsAPI.Models
{
    public class WatchList
    {
        public int WatchListId { get; set; }
        public int UserId { get; set; }  // Foreign key to User
        public User User { get; set; }  // Navigation property to User
        public ICollection<WatchListPost> WatchListPosts { get; set; } = new List<WatchListPost>();
    }
}