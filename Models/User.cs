using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ORG.PostsAPI.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }

        [JsonIgnore]
        public List<Post>? Posts { get; set; }
        [JsonIgnore]
        public List<WatchList>? Watchs { get; set; }
    }
}