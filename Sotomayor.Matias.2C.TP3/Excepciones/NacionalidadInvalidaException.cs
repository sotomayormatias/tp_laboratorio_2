using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        private static string MESSAGE = "La nacionalidad es invalida";

        public NacionalidadInvalidaException()
            : this(NacionalidadInvalidaException.MESSAGE)
        { }

        public NacionalidadInvalidaException(string message)
            : base(message)
        { }
    }
}
