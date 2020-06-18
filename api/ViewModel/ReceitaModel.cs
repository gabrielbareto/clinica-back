using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ViewModel
{
    public class ReceitaModel
    {
        public string Descricao { get; set; }
        public int PacienteId { get; set; }

        public Receita Map()
        {
            return new Receita
            {
                Descricao = Descricao,
                PacienteId = PacienteId
            };
        }
    }
}
