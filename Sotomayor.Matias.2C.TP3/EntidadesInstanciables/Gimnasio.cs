using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInstanciables
{
    public class Gimnasio
    {
        public enum EClases { Crossfit = 0, Natacion = 1, Pilates = 2, Yoga = 3 };

        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornadas;

        public Jornada this[int index]
        {
            get
            {
                return this._jornadas[index];
            }
        }

        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornadas = new List<Jornada>();
        }

        public static bool operator ==(Gimnasio gym, Alumno alumno)
        {
            bool esIgual = false;

            foreach (Alumno unAlumno in gym._alumnos)
            {
                if (unAlumno == alumno)
                    esIgual = true;
            }

            return esIgual;
        }

        public static bool operator !=(Gimnasio gym, Alumno alumno)
        {
            return !(gym == alumno);
        }

        public static Gimnasio operator +(Gimnasio gym, Alumno alumno)
        {
            if (gym != alumno)
                gym._alumnos.Add(alumno);

            return gym;
        }

        public static bool operator ==(Gimnasio gym, Instructor instructor)
        {
            bool esIgual = false;

            foreach (Instructor unInstructor in gym._instructores)
            {
                if (unInstructor == instructor)
                    esIgual = true;
            }

            return esIgual;
        }

        public static bool operator !=(Gimnasio gym, Instructor instructor)
        {
            return !(gym == instructor);
        }

        public static Gimnasio operator +(Gimnasio gym, Instructor instructor)
        {
            if (gym != instructor)
                gym._instructores.Add(instructor);

            return gym;
        }

        public static Gimnasio operator +(Gimnasio gym, EClases clase)
        {
            Instructor instructorAsignado = null;

            foreach (Instructor instr in gym._instructores)
            {
                if (instr == clase)
                    instructorAsignado = instr;
            }

            Jornada jornada = new Jornada(clase, instructorAsignado);

            foreach (Alumno unAlumno in gym._alumnos)
            {
                if (unAlumno == clase)
                    gym._alumnos.Add(unAlumno);
            }


            return gym;
        }

        private static string MostrarDatos(Gimnasio gym)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada jornada in gym._jornadas)
            {
                sb.AppendLine(jornada.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }
    }
}
