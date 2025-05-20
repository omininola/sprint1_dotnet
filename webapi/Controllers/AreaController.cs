﻿using Microsoft.AspNetCore.Mvc;
using webapi.DTO;
using webapi.Model;
using webapi.Data;
using Microsoft.EntityFrameworkCore;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : Controller
    {
        private readonly AppDbContext _context;

        public AreaController(AppDbContext context)
        { 
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<AreaRespostaDTO>> CreateArea(AreaDTO areaDTO)
        {
            var filial = await _context.Filiais.FindAsync(areaDTO.FilialId);

            if (filial == null)
            {
                return BadRequest("Filial não encontrada");                    
            }

            var area = new Area
            {
                Status = areaDTO.Status,
                FilialId = areaDTO.FilialId
            };

            _context.Areas.Add(area);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArea), new { id = area.Id });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaRespostaDTO>>> GetAreas()
        {
            var areas = await _context.Areas
                .Include(a => a.Filial)
                .Select(a => new AreaRespostaDTO
                {
                    Id = a.Id,
                    Status = a.Status,
                    FilialId = a.FilialId,
                    FilialNome = a.Filial.Nome
                })
                .ToListAsync();

            return areas;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AreaRespostaDTO>> GetArea(int id)
        {
            var area = await _context.Areas
                .Include(a => a.Filial)
                .Where(a => a.Id == id)
                .Select(a => new AreaRespostaDTO
                {
                    Id = a.Id,
                    Status = a.Status,
                    FilialId = a.FilialId,
                    FilialNome = a.Filial.Nome
                })
                .FirstOrDefaultAsync();

            if (area == null)
            {
                return NotFound();
            }

            return area;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArea(int id, AreaDTO areaDTO)
        {
            var area = await _context.Areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            var filial = await _context.Filiais.FindAsync(area.FilialId);
            if (filial == null)
            {
                return BadRequest("Filial não encontrada");
            }

            area.Status = areaDTO.Status;
            area.FilialId = areaDTO.FilialId;

            _context.Entry(area).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            var area = await _context.Areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
