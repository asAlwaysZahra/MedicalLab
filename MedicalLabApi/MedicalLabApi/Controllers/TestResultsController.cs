﻿using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace MedicalLabApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestResultsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TestResultsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/TestResults
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TestResult>>> GetTestResults()
    {
        return await _context.TestResults.ToListAsync();
    }

    // GET: api/TestResults/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TestResult>> GetTestResult(int id)
    {
        var testResult = await _context.TestResults.FindAsync(id);

        if (testResult == null)
        {
            return NotFound();
        }

        return testResult;
    }

    // POST: api/TestResults
    [HttpPost]
    public async Task<ActionResult<TestResult>> PostTestResult(TestResult testResult)
    {
        _context.TestResults.Add(testResult);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTestResult", new { id = testResult.Id }, testResult);
    }

    // PUT: api/TestResults/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTestResult(int id, TestResult testResult)
    {
        if (id != testResult.Id)
        {
            return BadRequest();
        }

        _context.Entry(testResult).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TestResultExists(id))
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

    // DELETE: api/TestResults/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTestResult(int id)
    {
        var testResult = await _context.TestResults.FindAsync(id);
        if (testResult == null)
        {
            return NotFound();
        }

        _context.TestResults.Remove(testResult);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TestResultExists(int id)
    {
        return _context.TestResults.Any(e => e.Id == id);
    }
}