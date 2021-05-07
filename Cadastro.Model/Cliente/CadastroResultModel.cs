using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cadastro.Models.Cliente
{
    public class CadastroResultModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public object ResultModel { get; set; }
    }
}