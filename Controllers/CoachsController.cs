using AwesomeGym.Entidades;
using AwesomeGym.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.Controllers
{
    [ApiController]
    [Route("api/coachs")]
    public class CoachsController : ControllerBase
    {
        private readonly AwesomeGymDbContext _awesomeGymDbContext;
        public CoachsController(AwesomeGymDbContext awesomeGymDbContext)
        {
            _awesomeGymDbContext = awesomeGymDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            List<Coach> coachs = await _awesomeGymDbContext.Coachs.ToListAsync();

            return Ok(coachs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var coach = await _awesomeGymDbContext.Coachs.SingleOrDefaultAsync(u => u.Id == id);

            return Ok(coach);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Coach coach)
        {
            await _awesomeGymDbContext.Coachs.AddAsync(coach);
            await _awesomeGymDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByIdAsync), coach, new { id = coach.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Coach coach)
        {
            if (await _awesomeGymDbContext.Coachs.AnyAsync(a => a.Id == id))
            {
                return NotFound();
            }

            _awesomeGymDbContext.Entry(coach).State = EntityState.Modified;
            await _awesomeGymDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var coach = await _awesomeGymDbContext.Coachs.SingleOrDefaultAsync(a => a.Id == id);

            if (coach == null)
            {
                return NotFound();
            }

            coach.ChangeToInactiveStatus();
            await _awesomeGymDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}