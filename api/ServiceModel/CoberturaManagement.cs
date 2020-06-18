using api.Data;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace api.ServiceModel
{
    public class CoberturaManagement
    {

        private readonly apiContext _context;

        public Cobertura Cobertura { get; set; }
        
        public CoberturaManagement(apiContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Cobertura cobertura)
        {
            Cobertura = cobertura;

            _context.Cobertura.Add(Cobertura);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, Cobertura cobertura)
        {
            Cobertura = _context.Cobertura.SingleOrDefault(x => x.Id == id);

            if (Cobertura == null) return false;

            Cobertura.Descricao = cobertura.Descricao;

            await _context.SaveChangesAsync();

            return true;
        }

    }
}
