namespace ORG.PostsAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public List<Post>? Posts { get; set; } // Navigation property
    }
}
