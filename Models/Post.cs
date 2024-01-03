namespace ORG.PostsAPI.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } //define a conexão de post com user
        public string Title { get; set; }
        public string Content { get; set; }
        public int PositiveScore { get; set; }
        public int NegativeScore { get; set; }
        public string ReadTime { get; set; }  

        public List<string> Tags {  get; set; }
    }
}
