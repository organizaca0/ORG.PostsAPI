using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ORG.PostsAPI.Models
{
    public class Post
    {
        [Key]
        public Guid PostGuid { get; set; }

        [ForeignKey("User")]
        public Guid UserGuid { get; set; }

        [ForeignKey("User")]
        public string? UserName { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int PositiveScore { get; set; }
        public int NegativeScore { get; set; }
        public string ReadTime { get; set; }  
        public List<string> Tags {  get; set; }
        public DateTime CreatedAt { get; set; } // Stores date only
        public DateTime LastUpdate { get; set; } // store date and hour
        [JsonIgnore]
        public Boolean Active { get; set; }
    }
}
