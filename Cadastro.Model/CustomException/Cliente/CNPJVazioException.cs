using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Model.CustomException.Cliente
{
    public class CNPJVazioException : Exception
    {
        public CNPJVazioException()
        {
        }

        public CNPJVazioException(string message)
            : base(message)
        {
        }

        
    }
}
