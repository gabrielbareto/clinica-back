﻿using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.ResultModel
{
    public class EspecialidadeListJson : IActionResult
    {
        public ICollection<Especialidade> Especialidade { get; set; }

        public int Count { get; set; }

        public EspecialidadeListJson() { }

        public EspecialidadeListJson(ICollection<Especialidade> especialidade, int count)
        {
            Especialidade = especialidade;
            Count = count;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new ObjectResult(this).ExecuteResultAsync(context);
        }
    }
}
