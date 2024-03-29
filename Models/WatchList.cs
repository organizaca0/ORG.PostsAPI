﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ORG.PostsAPI.Models
{
    [Table("WatchList")]
    public class WatchList
    {
        [Key]
        public Guid WatchListGuid { get; set; }
        [Required]
        public string WatchListName { get; set; }
        [Required]
        public Guid UserGuid { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public string? UserName { get; set; }
        public List<Guid>? Posts { get; set; }
        [JsonIgnore]
        public Boolean Active { get; set; }

    }
}