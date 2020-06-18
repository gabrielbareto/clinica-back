using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ViewModel
{
    public class MedicoModel
    {
        public string Nome { get; set; }
        public string Crm { get; set; }
        public int EspecialidadeId { get; set; }

        public Medico Map()
        {
            return new Medico
            {
                Nome = Nome,
                Crm = Crm,
                EspecialidadeId = EspecialidadeId
            };
        }
    }
}
