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
    [ApiController, Route("api/receitas")]
    public class ReceitasController : ControllerBase
    {
        private readonly apiContext _context;

        public ReceitasController(apiContext context)
        {
            _context = context;
        }

        // GET: api/Receitas
        [HttpGet, Route("")]
        public async Task<IActionResult> Get()
        {
            var medico = await _context.Medico.ToListAsync();

            return new MedicoListJson(medico, medico.Count);
        }

        // GET: api/Receitas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceita([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var receita = await _context.Receita.FindAsync(id);

            if (receita == null)
            {
                return NotFound();
            }

            return Ok(receita);
        }

        // PUT: api/Receitas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceita([FromRoute] int id, [FromBody] Receita receita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != receita.Id)
            {
                return BadRequest();
            }

            _context.Entry(receita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceitaExists(id))
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

        // POST: api/Receitas
        [HttpPost, Route("create")]
        public async Task<IActionResult> PostReceita([FromBody] Receita receita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Receita.Add(receita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceita", new { id = receita.Id }, receita);
        }

        // DELETE: api/Receitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceita([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var receita = await _context.Receita.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }

            _context.Receita.Remove(receita);
            await _context.SaveChangesAsync();

            return Ok(receita);
        }

        private bool ReceitaExists(int id)
        {
            return _context.Receita.Any(e => e.Id == id);
        }
    }
}