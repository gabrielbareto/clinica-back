using api.Data;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ServiceModel
{
    public class ReceitaManagement
    {
        private readonly apiContext _context;

        public Receita Receita { get; set; }

        public ReceitaManagement(apiContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Receita receita)
        {
            Receita = receita;

            _context.Receita.Add(Receita);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, Receita receita)
        {
            Receita = _context.Receita.SingleOrDefault(x => x.Id == id);

            if (Receita == null) return false;

            Receita.Descricao = receita.Descricao;
            Receita.PacienteId = receita.PacienteId;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
