using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.ResultModel
{
    public class MedicoListJson : IActionResult
    {
        public ICollection<Medico> Medico { get; set; }

        public int Count { get; set; }

        public MedicoListJson() { }

        public MedicoListJson(ICollection<Medico> medico, int count)
        {
            Medico = medico;
            Count = count;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new ObjectResult(this).ExecuteResultAsync(context);
        }
    }
}
