using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ORG.PostsAPI.Models
{
    public class Post
    {
        [Key]
        public Guid PostGuid { get; set; }
        [Required]
        public Guid UserGuid { get; set; }
        public string? UserName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public int PositiveScore { get; set; }
        public int NegativeScore { get; set; }
        public string ReadTime { get; set; }
        [Required]
        public List<string> Tags {  get; set; }
        public DateTime CreatedAt { get; set; } // Stores date only
        public DateTime LastUpdate { get; set; }// store date and hour
        [JsonIgnore]
        public Boolean Active { get; set; }
    }
}
