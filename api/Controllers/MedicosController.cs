using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using api.ResultModel;

namespace api.Controllers
{
    [ApiController, Route("api/medicos")]
    public class MedicosController : ControllerBase
    {
        private readonly apiContext _context;

        public MedicosController(apiContext context)
        {
            _context = context;
        }

        // GET: api/Medicos
        [HttpGet, Route("")]
        public async Task<IActionResult> Get()
        {
            var medico = await _context.Medico.ToListAsync();

            return new MedicoListJson(medico, medico.Count);
        }

        // GET: api/Medicos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedico([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medico = await _context.Medico.FindAsync(id);

            if (medico == null)
            {
                return NotFound();
            }

            return Ok(medico);
        }

        // PUT: api/Medicos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedico([FromRoute] int id, [FromBody] Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medico.Id)
            {
                return BadRequest();
            }

            _context.Entry(medico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicoExists(id))
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

        // POST: api/Medicos
        [HttpPost, Route("create")]
        public async Task<IActionResult> PostMedico([FromBody] Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Medico.Add(medico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedico", new { id = medico.Id }, medico);
        }

        // DELETE: api/Medicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedico([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medico = await _context.Medico.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }

            _context.Medico.Remove(medico);
            await _context.SaveChangesAsync();

            return Ok(medico);
        }

        private bool MedicoExists(int id)
        {
            return _context.Medico.Any(e => e.Id == id);
        }
    }
}