using final_project_it3045c.Data;
using final_project_it3045c.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class MemberDetailsController : ControllerBase
{
    private readonly AppDbContext _context;

    public MemberDetailsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/memberdetails
    [HttpGet]
    public ActionResult<IEnumerable<MemberDetails>> Get()
    {
        var memberDetailsList = _context.MemberDetailsSet.ToList();

        try {
            return Ok(memberDetailsList.GetRange(0, 4));
        } catch {
            return Ok(memberDetailsList);
        }
    }

    // GET: api/memberdetails/1
    [HttpGet("{id}")]
    public ActionResult<MemberDetails> Get(int id)
    {
        var memberDetailsList = _context.MemberDetailsSet.ToList();
        var memberDetails = _context.MemberDetailsSet.Find(id);

        if (id == 0)
        {
            try {
                return Ok(memberDetailsList.GetRange(0, 4));
            } catch {
                return Ok(memberDetailsList);
            }
        }

        if (memberDetails == null) {
            return NotFound();
        }

        return Ok(memberDetails);
    }

    // POST: api/memberdetails
    [HttpPost]
    public ActionResult<MemberDetails> Post([FromBody] MemberDetails memberDetails)
    {
        _context.MemberDetailsSet.Add(memberDetails);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = memberDetails.Id }, memberDetails);
    }

    // PUT: api/memberdetails/1
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] MemberDetails updatedMemberDetails)
    {
        var existingMemberDetails = _context.MemberDetailsSet.Find(id);

        if (existingMemberDetails == null)
        {
            return NotFound();
        }

        existingMemberDetails.FavoriteFood = updatedMemberDetails.FavoriteFood; // Update other properties as needed

        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/memberdetails/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var memberDetails = _context.MemberDetailsSet.Find(id);

        if (memberDetails == null)
        {
            return NotFound();
        }

        _context.MemberDetailsSet.Remove(memberDetails);
        _context.SaveChanges();

        return NoContent();
    }
}
