using final_project_it3045c.Data;
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
        var teamMembers = _context.TeamMembers.ToList();
        return Ok(teamMembers);
    }

    // Implement your CRUD operations using _context
}
