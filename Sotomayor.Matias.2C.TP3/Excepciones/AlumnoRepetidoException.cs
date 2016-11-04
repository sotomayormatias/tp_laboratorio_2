﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        private static string MESSAGE = "El alumno esta repetido";

        public AlumnoRepetidoException()
            : base(AlumnoRepetidoException.MESSAGE)
        { }
    }
}
