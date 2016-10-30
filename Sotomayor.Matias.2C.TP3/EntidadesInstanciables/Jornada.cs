using System;
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

        //TODO: no entiendo la property this[int i]

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
            //TODO: la igualdad es si el alumno esta en la lista de la jornada o si comparten la clase?

            //Comparten solo la misma clase
            //return alumno == jornada._clase;

            //El alumno esta en la lista de alumnos de la jornada
            return jornada._alumnos.Contains(alumno);
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
            //TODO: el ToString lee del archivo?
            return base.ToString();
        }

        //TODO: el enunciado habla de un metodo LEER... a que se refiere?
    }
}
