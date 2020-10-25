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
    [Route("api/machines")]
    public class MachinesController : ControllerBase
    {
        private readonly AwesomeGymDbContext _awesomeGymDbContext;
        public MachinesController(AwesomeGymDbContext awesomeGymDbContext)
        {
            _awesomeGymDbContext = awesomeGymDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            List<Machine> machines = await _awesomeGymDbContext.Machines.ToListAsync();

            return Ok(machines);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var machines = await _awesomeGymDbContext.Machines.SingleOrDefaultAsync(u => u.Id == id);

            return Ok(machines);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Machine machine)
        {
            await _awesomeGymDbContext.Machines.AddAsync(machine);
            await _awesomeGymDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByIdAsync), machine, new { id = machine.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Machine machine)
        {
            if (await _awesomeGymDbContext.Machines.AnyAsync(a => a.Id == id))
            {
                return NotFound();
            }

            _awesomeGymDbContext.Entry(machine).State = EntityState.Modified;
            await _awesomeGymDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var machine = await _awesomeGymDbContext.Machines.SingleOrDefaultAsync(a => a.Id == id);

            if (machine == null)
            {
                return NotFound();
            }

            machine.ChangeToInactiveStatus();
            await _awesomeGymDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}