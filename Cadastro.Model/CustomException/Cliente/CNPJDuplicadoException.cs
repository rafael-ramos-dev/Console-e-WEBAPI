using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Model.CustomException.Cliente
{
    public class CNPJDuplicadoException : Exception
    {
        public CNPJDuplicadoException()
        {
        }

        public CNPJDuplicadoException(string message)
            : base(message)
        {
        }

        
    }
}
