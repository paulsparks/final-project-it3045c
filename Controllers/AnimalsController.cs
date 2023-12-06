using final_project_it3045c.Data;
using final_project_it3045c.Models;
using Microsoft.AspNetCore.Mvc;
using final_project_it3045c.HelperFunctions;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private AppDbContext _context;

    public AnimalsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/animals
    [HttpGet]
    public ActionResult<IEnumerable<Animal>> Get()
    {
        var animalsList = _context.Animals.ToList();
        
        try {
            return Ok(animalsList.GetRange(0, 5));
        } catch {
            return Ok(animalsList);
        }
    }

    // GET: api/animals/1
    [HttpGet("{id}")]
    public ActionResult<Animal> Get(int id)
    {
        var animalsList = _context.Animals.ToList();
        var animal = _context.Animals.Find(id);

        if (id == 0)
        {
            try {
                return Ok(animalsList.GetRange(0, 5));
            } catch {
                return Ok(animalsList);
            }
        }

        if (animal == null) {
            return NotFound();
        }

        return Ok(animal);
    }

    // POST: api/animals
    [HttpPost]
    public ActionResult<Animal> Post([FromBody] Animal animal)
    {
        _context.Animals.Add(animal);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = animal.Id }, animal);
    }

    // PUT: api/animals/1
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Animal updatedAnimal)
    {
        var existingAnimal = _context.Animals.Find(id);

        if (existingAnimal == null)
        {
            return NotFound();
        }

        CopyProperties.Copy(updatedAnimal, existingAnimal);

        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/animals/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var animal = _context.Animals.Find(id);

        if (animal == null)
        {
            return NotFound();
        }

        _context.Animals.Remove(animal);
        _context.SaveChanges();

        return NoContent();
    }
}
