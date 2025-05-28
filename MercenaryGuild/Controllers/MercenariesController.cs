using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MercenaryGuild.Data;
using MercenaryGuild.Models;
using MercenaryGuild.DTOs;

namespace MercenaryGuild.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercenariesController : ControllerBase
    {
        private readonly GuildDbContext _context;

        public MercenariesController(GuildDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MercenaryDto>>> GetMercenaries()
        {
            return await _context.Mercenaries
                .Select(m => new MercenaryDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Rank = m.Rank.ToString(),
                    RegistrationDate = m.RegistrationDate,
                    Bio = m.Bio  // Добавлено новое поле
                })
                .ToListAsync();
        }

        // GET: api/Mercenaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MercenaryDetailsDto>> GetMercenary(int id)
        {
            var mercenary = await _context.Mercenaries
                .Include(m => m.CompletedQuests)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mercenary == null)
            {
                return NotFound();
            }

            return new MercenaryDetailsDto
            {
                Id = mercenary.Id,
                Name = mercenary.Name,
                Rank = mercenary.Rank.ToString(),
                RegistrationDate = mercenary.RegistrationDate,
                CompletedQuests = mercenary.CompletedQuests.Select(q => new QuestShortDto
                {
                    Id = q.Id,
                    Title = q.Title,
                    Reward = q.Reward,
                    Rank = q.Rank.ToString()
                }).ToList()
            };
        }

        // POST: api/Mercenaries
        [HttpPost]
        public async Task<ActionResult<MercenaryDto>> PostMercenary(MercenaryCreateDto mercenaryDto)
        {
            if (!Enum.TryParse<Rank>(mercenaryDto.Rank, out var rank))
            {
                return BadRequest("Invalid rank value");
            }

            var mercenary = new Mercenary
            {
                Name = mercenaryDto.Name,
                Rank = rank,
                RegistrationDate = DateTime.UtcNow
            };

            _context.Mercenaries.Add(mercenary);
            await _context.SaveChangesAsync();

            var result = new MercenaryDto
            {
                Id = mercenary.Id,
                Name = mercenary.Name,
                Rank = mercenary.Rank.ToString(),
                RegistrationDate = mercenary.RegistrationDate
            };

            return CreatedAtAction(nameof(GetMercenary), new { id = mercenary.Id }, result);
        }

        // GET: api/Mercenaries/5/quests
        [HttpGet("{id}/quests")]
        public async Task<ActionResult<IEnumerable<QuestDto>>> GetMercenaryQuests(int id)
        {
            var quests = await _context.Quests
                .Where(q => q.MercenaryId == id)
                .Select(q => new QuestDto
                {
                    Id = q.Id,
                    Title = q.Title,
                    Description = q.Description,
                    Reward = q.Reward,
                    Rank = q.Rank.ToString(),
                    IsTaken = q.IsTaken,
                    MercenaryId = q.MercenaryId
                })
                .ToListAsync();

            if (!quests.Any())
            {
                return NotFound("No quests found for this mercenary");
            }

            return quests;
        }
    }
}