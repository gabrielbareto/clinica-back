using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.ResultModel
{
    public class ReceitaListJson : IActionResult
    {
        public ICollection<Receita> Receita { get; set; }

        public int Count { get; set; }

        public ReceitaListJson() { }

        public ReceitaListJson(ICollection<Receita> receita, int count)
        {
            Receita = receita;
            Count = count;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new ObjectResult(this).ExecuteResultAsync(context);
        }
    }
}
