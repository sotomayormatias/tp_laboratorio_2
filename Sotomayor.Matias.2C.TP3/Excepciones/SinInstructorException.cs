using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinInstructorException : Exception
    {
        private static string MESSAGE = "No hay instructor";

        public SinInstructorException()
            : base(SinInstructorException.MESSAGE)
        { }
    }
}
