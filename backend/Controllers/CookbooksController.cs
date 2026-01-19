using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;

namespace Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CookbooksController : ControllerBase
{
    private readonly AppDbContext _db;

    public CookbooksController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Cookbook>>> GetAll()
    {
        return await _db.Cookbooks.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Cookbook>> Create(Cookbook cookbook)
    {
        cookbook.CreatedAt = DateTime.UtcNow;
        _db.Cookbooks.Add(cookbook);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = cookbook.Id }, cookbook);
    }
}