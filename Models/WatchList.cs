using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ORG.PostsAPI.Models
{
    public class WatchList
    {
        [Key]
        public int WatchListId { get; set; }
        public string WatchListName { get; set; }

        [ForeignKey("User")]
        public Guid UserGuid { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public List<int>? Posts { get; set; }
    }
}