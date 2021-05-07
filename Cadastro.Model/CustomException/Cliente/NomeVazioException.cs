using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Model.CustomException.Cliente
{
    public class NomeVazioException : Exception
    {
        public NomeVazioException()
        {
        }

        public NomeVazioException(string message)
            : base(message)
        {
        }


    }
}
