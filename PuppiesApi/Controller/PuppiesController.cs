using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using PuppiesApi.Models;

namespace PuppiesApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PuppiesController : ControllerBase
    {
        private PuppyRepository _repo;
        public PuppiesController(PuppyRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetPuppies() 
        {
            var result = _repo.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetPuppy(int id)
        {
            var result = _repo.GetOne(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddPuppy(string name, string breed, DateTime birthDate)
        {
            var result = _repo.Create(name, breed, birthDate);

            return CreatedAtAction(nameof(GetPuppy), new { id = result.PuppyId }, result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePresident(int id, string name, string breed, DateTime birthDate)
        {
            if (_repo.GetOne(id) == null)
            {
                return NotFound();
            }

            var result = _repo.Update(id, name, breed, birthDate);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePuppy(int id)
        {
            _repo.Delete(id);

            return NoContent();
        }
    }
}
