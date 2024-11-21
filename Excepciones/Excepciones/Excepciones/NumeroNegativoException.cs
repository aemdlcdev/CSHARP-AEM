using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    internal class NumeroNegativoException : Exception
    {
        public int ValorNegativo { get; }

        public NumeroNegativoException(string message, int valorNegativo) : base(message)
        {
            ValorNegativo = valorNegativo;
        }
    }
}
