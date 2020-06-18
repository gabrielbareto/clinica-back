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
    [ApiController, Route("api/requisicoes")]
    public class RequisicoesController : ControllerBase
    {
        private readonly apiContext _context;

        public RequisicoesController(apiContext context)
        {
            _context = context;
        }

        // GET: api/Requisicoes
        [HttpGet, Route("")]
        public async Task<IActionResult> Get()
        {
            var requisicao = await _context.Requisicao.ToListAsync();

            return new RequisicaoListJson(requisicao, requisicao.Count);
        }

        // GET: api/Requisicoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequisicao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requisicao = await _context.Requisicao.FindAsync(id);

            if (requisicao == null)
            {
                return NotFound();
            }

            return Ok(requisicao);
        }

        // PUT: api/Requisicoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequisicao([FromRoute] int id, [FromBody] Requisicao requisicao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requisicao.Id)
            {
                return BadRequest();
            }

            _context.Entry(requisicao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequisicaoExists(id))
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

        // POST: api/Requisicoes
        [HttpPost, Route("create")]
        public async Task<IActionResult> PostRequisicao([FromBody] Requisicao requisicao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Requisicao.Add(requisicao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequisicao", new { id = requisicao.Id }, requisicao);
        }

        // DELETE: api/Requisicoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequisicao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requisicao = await _context.Requisicao.FindAsync(id);
            if (requisicao == null)
            {
                return NotFound();
            }

            _context.Requisicao.Remove(requisicao);
            await _context.SaveChangesAsync();

            return Ok(requisicao);
        }

        private bool RequisicaoExists(int id)
        {
            return _context.Requisicao.Any(e => e.Id == id);
        }
    }
}