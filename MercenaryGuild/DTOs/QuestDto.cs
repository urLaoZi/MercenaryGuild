namespace MercenaryGuild.DTOs
{
    public class QuestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Reward { get; set; }
        public string Rank { get; set; }
        public bool IsTaken { get; set; }
        public int? MercenaryId { get; set; }
    }
}