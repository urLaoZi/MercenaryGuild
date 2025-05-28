using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MercenaryGuild.Data;
using MercenaryGuild.Models;

namespace MercenaryGuild.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestsController : ControllerBase
    {
        private readonly GuildDbContext _context;

        public QuestsController(GuildDbContext context)
        {
            _context = context;
        }

        // GET: api/Quests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quest>>> GetQuests()
        {
            return await _context.Quests.ToListAsync();
        }

        // POST: api/Quests
        [HttpPost]
        public async Task<ActionResult<Quest>> PostQuest(Quest quest)
        {
            _context.Quests.Add(quest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuest", new { id = quest.Id }, quest);
        }

        // PUT: api/Quests/5/accept/1
        [HttpPut("{questId}/accept/{mercenaryId}")]
        public async Task<IActionResult> AcceptQuest(int questId, int mercenaryId)
        {
            var mercenary = await _context.Mercenaries.FindAsync(mercenaryId);
            var quest = await _context.Quests.FindAsync(questId);

            if ((int)mercenary.Rank < (int)quest.Rank)
            {
                return BadRequest("Наёмник слишком низкого ранга для этого задания");
            }

            quest.IsTaken = true;
            quest.MercenaryId = mercenaryId;

            _context.Entry(quest).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    } 

}