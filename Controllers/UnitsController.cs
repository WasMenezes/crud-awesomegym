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
    [Route("api/units")]
    public class UnitsController : ControllerBase
    {
        private readonly AwesomeGymDbContext _awesomeGymDbContext;
        public UnitsController(AwesomeGymDbContext awesomeGymDbContext)
        {
            _awesomeGymDbContext = awesomeGymDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            List<Unit> units = await _awesomeGymDbContext.Units.ToListAsync();
            
            return Ok(units);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var units = await _awesomeGymDbContext.Units.SingleOrDefaultAsync(u => u.Id == id);

            return Ok(units);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Unit unit)
        {
            await _awesomeGymDbContext.Units.AddAsync(unit);
            await _awesomeGymDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByIdAsync), unit, new { id = unit.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Unit unit)
        {
            if(await _awesomeGymDbContext.Units.AnyAsync(a => a.Id == id))
            {
                return NotFound();
            }

            _awesomeGymDbContext.Entry(unit).State = EntityState.Modified;
            await _awesomeGymDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
