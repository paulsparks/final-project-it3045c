using final_project_it3045c.Data;
using final_project_it3045c.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class TeamMembersController : ControllerBase
{
    private AppDbContext _context;

    public TeamMembersController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/teammembers
    [HttpGet]
    public ActionResult<IEnumerable<TeamMember>> Get()
    {
        var teamMembers = _context.TeamMembers.ToList();
        return Ok(teamMembers);
    }

    // GET: api/teammembers/1
    [HttpGet("{id}")]
    public ActionResult<TeamMember> Get(int id)
    {
        var teamMember = _context.TeamMembers.Find(id);

        if (teamMember == null)
        {
            return NotFound();
        }

        return Ok(teamMember);
    }

    // POST: api/teammembers
    [HttpPost]
    public ActionResult<TeamMember> Post([FromBody] TeamMember teamMember)
    {
        _context.TeamMembers.Add(teamMember);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = teamMember.Id }, teamMember);
    }

    // PUT: api/teammembers/1
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TeamMember updatedTeamMember)
    {
        var existingTeamMember = _context.TeamMembers.Find(id);

        if (existingTeamMember == null)
        {
            return NotFound();
        }

        existingTeamMember.FullName = updatedTeamMember.FullName; // Update other properties as needed

        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/teammembers/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var teamMember = _context.TeamMembers.Find(id);

        if (teamMember == null)
        {
            return NotFound();
        }

        _context.TeamMembers.Remove(teamMember);
        _context.SaveChanges();

        return NoContent();
    }
}
