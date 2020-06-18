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
using api.ServiceModel;
using Microsoft.Extensions.DependencyInjection;
using api.ViewModel;

namespace api.Controllers
{
    
    [ApiController, Route("api/coberturas")]
    public class CoberturasController : Controller
    {
        private readonly apiContext _context;
        private readonly IServiceProvider _provider;

        public CoberturasController(apiContext context, IServiceProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        // GET: api/Coberturas
        [HttpGet, Route("")]
        public async Task<IActionResult> Get()
        {
            var cobertura = await _context.Cobertura.ToListAsync();

            return new CoberturaListJson(cobertura, cobertura.Count);
        }

        // GET: api/Coberturas/5
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetCobertura([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cobertura = await _context.Cobertura.FindAsync(id);

            if (cobertura == null)
            {
                return NotFound();
            }

            return Ok(cobertura);
        }

        // PUT: api/Coberturas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CoberturaModel model)
        {
            var service = _provider.GetRequiredService<CoberturaManagement>();

            if(!await service.UpdateAsync(id, model.Map()))
            {
                return BadRequest();
            }

            return new JsonResult(service.Cobertura);
        }

        // POST: api/Coberturas
        [HttpPost, Route("create")]
        public async Task<IActionResult> PostCobertura([FromBody] Cobertura cobertura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cobertura.Add(cobertura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCobertura", new { id = cobertura.Id }, cobertura); 

            
        }
        
        // DELETE: api/Coberturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCobertura([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cobertura = await _context.Cobertura.FindAsync(id);
            if (cobertura == null)
            {
                return NotFound();
            }

            _context.Cobertura.Remove(cobertura);
            await _context.SaveChangesAsync();

            return Ok(cobertura);
        }

        private bool CoberturaExists(int id)
        {
            return _context.Cobertura.Any(e => e.Id == id);
        }
        
    }
}