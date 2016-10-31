using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniIvalidoException : Exception
    {
        public DniIvalidoException()
            : base()
        { }

        public DniIvalidoException(Exception e)
            : this(e.Message)
        { }

        public DniIvalidoException(string message)
            : base(message)
        { }

        //TODO: como es el tema de las excepciones
        //public DniIvalidoException(string message, Exception e)
        //    : base(message)
        //{ }
    }
}
