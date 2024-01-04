namespace ORG.PostsAPI.Models
{
    public class WatchList
    {
        public int WatchListId { get; set; }
        public int UserId { get; set; }
        public List<int> Posts { get; set; } = new List<int>();
    }
}