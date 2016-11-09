using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        private static string MESSAGE = "La nacionalidad no se condice con el numero de DNI";

        public NacionalidadInvalidaException()
            : this(NacionalidadInvalidaException.MESSAGE)
        { }

        public NacionalidadInvalidaException(string message)
            : base(message)
        { }
    }
}
