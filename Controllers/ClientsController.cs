using System.Linq;
using System.Threading.Tasks;
using AwesomeGym.Entidades;
using AwesomeGym.InputModels;
using AwesomeGym.Persistence;
using AwesomeGym.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AwesomeGym.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly AwesomeGymDbContext _awesomeGymDbContext;
        public ClientsController(AwesomeGymDbContext awesomeGymDbContext)
        {
            _awesomeGymDbContext = awesomeGymDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var clients = await _awesomeGymDbContext
                .Clients
                .ToListAsync();

            var clientViewModel = clients.Select(a => new ClientViewModel(a.Name, a.Status)).ToList();
            
            return Ok(clientViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var client = await _awesomeGymDbContext.Clients.SingleOrDefaultAsync(u => u.Id == id);

            var clientViewModel = new ClientViewModel(client.Name, client.Status);

            return Ok(clientViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ClientInputModel clientInputModel)
        {
            var client = new Client(clientInputModel.Name,
                                    clientInputModel.Adress, 
                                    clientInputModel.DateBirth);

            await _awesomeGymDbContext.Clients.AddAsync(client);
            await _awesomeGymDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByIdAsync), client, new { id = client.Id});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ClientUpdateInputModel clientUpdateInputModel)
        {
            var client = await _awesomeGymDbContext.Clients.SingleOrDefaultAsync(a => a.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            client.Adress = clientUpdateInputModel.Adress;

            await _awesomeGymDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var client = await _awesomeGymDbContext.Clients.SingleOrDefaultAsync(a => a.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            client.ChangeToInactiveStatus();
            await _awesomeGymDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}