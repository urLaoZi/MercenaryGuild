using Microsoft.EntityFrameworkCore;
using MercenaryGuild.Models;

namespace MercenaryGuild.Data
{
    public class GuildDbContext : DbContext
    {
        public GuildDbContext(DbContextOptions<GuildDbContext> options) : base(options)
        {
        }

        public DbSet<Mercenary> Mercenaries { get; set; }
        public DbSet<Quest> Quests { get; set; }
    }
}