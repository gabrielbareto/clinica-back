using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.ResultModel
{
    public class ConsultaListJson : IActionResult
    {
        public ICollection<Consulta> Consultas { get; set; }

        public int Count { get; set; }

        public ConsultaListJson(ICollection<Consulta> consultas, int count)
        {
            Consultas = consultas;
            Count = count;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new ObjectResult(this).ExecuteResultAsync(context);
        }
    }
}
