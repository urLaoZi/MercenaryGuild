using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MercenaryGuild.Models
{
    public class Quest
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public decimal Reward { get; set; }

        [Required]
        public Rank Rank { get; set; }

        public bool IsTaken { get; set; } = false;

        public int? MercenaryId { get; set; }

        public string? Location { get; set; }

        [JsonIgnore]
        public Mercenary? Mercenary { get; set; }
    }
}