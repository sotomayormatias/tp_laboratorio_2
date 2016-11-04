﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;

        //TODO: no entiendo la property this[int i] usar indexadores

        public Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            bool esIgual = false;

            foreach (Alumno unAlumno in jornada._alumnos)
            {
                if (unAlumno == alumno)
                    esIgual = true;
            }

            return esIgual;
        }

        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            return !(jornada == alumno);
        }

        public static Jornada operator +(Jornada jornada, Alumno alumno)
        {
            if (jornada != alumno)
                jornada._alumnos.Add(alumno);

            return jornada;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            sb.AppendLine("CLASE DE " + this._clase + " POR ");
            sb.AppendLine(this._instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            sb.AppendLine(this._alumnos.ToString());

            return sb.ToString();
        }

    }
}
