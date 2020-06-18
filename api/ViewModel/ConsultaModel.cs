using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ViewModel
{
    public class ConsultaModel
    {
        public DateTime Data { get; set; }
        public int PacienteId { get; set; }
        public int CoberturaId { get; set; }
        public int MedicoId { get; set; }
        public int ReceitaId { get; set; }
        public int RequisicaoId { get; set; }

        public Consulta Map()
        {
            return new Consulta
            {
                Data = Data,
                PacienteId = PacienteId,
                CoberturaId = CoberturaId,
                MedicoId = MedicoId,
                ReceitaId = ReceitaId,
                RequisicaoId = RequisicaoId
            };
        }
    }
}
