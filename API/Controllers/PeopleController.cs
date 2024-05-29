using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sharedmodels;

namespace API.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class PeopleController : ControllerBase
        {
            private readonly PeopleContext _context;

            public PeopleController(PeopleContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Person>>> GetUsers()
            {
                return await _context.People.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Person>> GetPerson(int id)
            {
                var person = await _context.People.FindAsync(id);

                if (person == null)
                {
                    return NotFound();
                }

                return person;
            }

            [HttpPost]
            public async Task<ActionResult<Person>> PostPerson(Person person)
            {
                _context.People.Add(person);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPerson", new { id = person.Id }, person);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutPerson(int id, Person person)
            {
                if (id != person.Id)
                {
                    return BadRequest();
                }

                _context.Entry(person).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return NoContent();

            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteUser(int id)
            {
                var user = await _context.People.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                _context.People.Remove(user);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool UserExists(int id)
            {
                return _context.People.Any(e => e.Id == id);
            }
        }
    }

