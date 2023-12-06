using final_project_it3045c.Data;
using final_project_it3045c.Models;
using Microsoft.AspNetCore.Mvc;
using final_project_it3045c.HelperFunctions;

[Route("api/[controller]")]
[ApiController]
public class StoreItemsController : ControllerBase
{
    private AppDbContext _context;

    public StoreItemsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/storeitems
    [HttpGet]
    public ActionResult<IEnumerable<StoreItem>> Get()
    {
        var storeItemsList = _context.StoreItems.ToList();

        try
        {
            return Ok(storeItemsList.GetRange(0, 5));
        }
        catch
        {
            return Ok(storeItemsList);
        }
    }

    // GET: api/storeitems/1
    [HttpGet("{id}")]
    public ActionResult<StoreItem> Get(int id)
    {
        var storeItemsList = _context.StoreItems.ToList();
        var storeItem = _context.StoreItems.Find(id);

        if (id == 0)
        {
            try
            {
                return Ok(storeItemsList.GetRange(0, 5));
            }
            catch
            {
                return Ok(storeItemsList);
            }
        }

        if (storeItem == null)
        {
            return NotFound();
        }

        return Ok(storeItem);
    }

    // POST: api/storeitems
    [HttpPost]
    public ActionResult<StoreItem> Post([FromBody] StoreItem storeItem)
    {
        _context.StoreItems.Add(storeItem);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = storeItem.Id }, storeItem);
    }

    // PUT: api/storeitems/1
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] StoreItem updatedStoreItem)
    {
        var existingStoreItem = _context.StoreItems.Find(id);

        if (existingStoreItem == null)
        {
            return NotFound();
        }

        CopyProperties.Copy(updatedStoreItem, existingStoreItem);

        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/storeitems/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var storeItem = _context.StoreItems.Find(id);

        if (storeItem == null)
        {
            return NotFound();
        }

        _context.StoreItems.Remove(storeItem);
        _context.SaveChanges();

        return NoContent();
    }
}
