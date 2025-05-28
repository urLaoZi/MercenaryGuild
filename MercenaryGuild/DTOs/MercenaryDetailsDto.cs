namespace MercenaryGuild.DTOs
{
    public class MercenaryDetailsDto : MercenaryDto
    {
        public List<QuestShortDto> CompletedQuests { get; set; }
    }

    public class QuestShortDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Reward { get; set; }
        public string Rank { get; set; }
    }
}