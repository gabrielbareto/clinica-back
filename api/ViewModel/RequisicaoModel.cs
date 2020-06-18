using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ViewModel
{
    public class RequisicaoModel
    {
        public string Descricao { get; set; }
        public int PacienteId { get; set; }

        public Requisicao Map()
        {
            return new Requisicao
            {
                Descricao = Descricao,
                PacienteId = PacienteId
            };
        }
    }
}
