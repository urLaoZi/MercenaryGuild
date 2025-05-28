using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MercenaryGuild.Models
{
    public enum Rank
    {
        SSS, SS, S, A, B, C, D, E
    }

    public class Mercenary
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public Rank Rank { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        public string? Bio { get; set; }

        [JsonIgnore]
        public List<Quest> CompletedQuests { get; set; } = new List<Quest>();
    }
}