using final_project_it3045c.Data;
using final_project_it3045c.HelperFunctions;
using final_project_it3045c.Models;
using Microsoft.AspNetCore.Mvc;

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
        var teamMembersList = _context.TeamMembers.ToList();
        
        try {
            return Ok(teamMembersList.GetRange(0, 4));
        } catch {
            return Ok(teamMembersList);
        }
    }

    // GET: api/teammembers/1
    [HttpGet("{id}")]
    public ActionResult<TeamMember> Get(int id)
    {
        var teamMembersList = _context.TeamMembers.ToList();
        var teamMember = _context.TeamMembers.Find(id);

        if (id == 0)
        {
            try {
                return Ok(teamMembersList.GetRange(0, 4));
            } catch {
                return Ok(teamMembersList);
            }
        }

        if (teamMember == null) {
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

        CopyProperties.Copy(updatedTeamMember, existingTeamMember);

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
