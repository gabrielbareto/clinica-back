using api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ResultModel
{
    public class CoberturaListJson : IActionResult
    {
        public ICollection<Cobertura> Cobertura { get; set; }

        public int Count { get; set; }

        public CoberturaListJson() { }

        public CoberturaListJson(ICollection<Cobertura> cobertura, int count)
        {
            Cobertura = cobertura;
            Count = count;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new ObjectResult(this).ExecuteResultAsync(context);
        }
    }
   
}
