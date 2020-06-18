using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.ResultModel
{
    public class PacienteListJson : IActionResult
    {
        public ICollection<Paciente> Paciente { get; set; }

        public int Count { get; set; }

        public PacienteListJson() { }

        public PacienteListJson(ICollection<Paciente> paciente, int count)
        {
            Paciente = paciente;
            Count = count;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new ObjectResult(this).ExecuteResultAsync(context);
        }
    }
}
