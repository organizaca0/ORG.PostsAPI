using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ORG.PostsAPI.Models
{
    public class User
    {
        [Key]
        public Guid UserGuid { get; set; }
        public string? UserName { get; set; }

        [JsonIgnore]
        public List<Post>? Posts { get; set; } // Navigation property
        [JsonIgnore]

        public List<WatchList>? Watchs { get; set; }
    }
}
