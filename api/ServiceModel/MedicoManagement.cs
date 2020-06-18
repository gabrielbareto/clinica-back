using api.Data;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ServiceModel
{
    public class MedicoManagement
    {
        private readonly apiContext _context;

        public Medico Medico { get; set; }

        public MedicoManagement(apiContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Medico medico)
        {
            Medico = medico;

            _context.Medico.Add(Medico);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, Medico medico)
        {
            Medico = _context.Medico.SingleOrDefault(x => x.Id == id);

            if (Medico == null) return false;

            Medico.Nome = medico.Nome;
            Medico.EspecialidadeId = medico.EspecialidadeId;
            Medico.Crm = medico.Crm;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
