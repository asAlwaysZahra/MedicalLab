using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Data;

namespace MedicalLabApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LabTestsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LabTestsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/LabTests
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LabTest>>> GetLabTests()
    {
        return await _context.LabTests.ToListAsync();
    }

    // GET: api/LabTests/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LabTest>> GetLabTest(int id)
    {
        var labTest = await _context.LabTests.FindAsync(id);

        if (labTest == null)
        {
            return NotFound();
        }

        return labTest;
    }

    // POST: api/LabTests
    [HttpPost]
    public async Task<ActionResult<LabTest>> PostLabTest(LabTest labTest)
    {
        _context.LabTests.Add(labTest);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetLabTest", new { id = labTest.Id }, labTest);
    }

    // PUT: api/LabTests/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLabTest(int id, LabTest labTest)
    {
        if (id != labTest.Id)
        {
            return BadRequest();
        }

        _context.Entry(labTest).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LabTestExists(id))
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

    // DELETE: api/LabTests/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLabTest(int id)
    {
        var labTest = await _context.LabTests.FindAsync(id);
        if (labTest == null)
        {
            return NotFound();
        }

        _context.LabTests.Remove(labTest);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool LabTestExists(int id)
    {
        return _context.LabTests.Any(e => e.Id == id);
    }
}