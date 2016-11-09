using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    public class Jornada
    {
        public List<Alumno> _alumnos;
        public Gimnasio.EClases _clase;
        public Instructor _instructor;

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
            foreach (Alumno unAlumno in this._alumnos)
            {
                sb.AppendLine(unAlumno.ToString());
            }
            sb.AppendLine("<------------------------------------------------>");

            return sb.ToString();
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();

            return texto.Guardar("Jornada.txt", jornada.ToString());
        }

        public static string Leer(Jornada jornada)
        {
            string datosJornada = "";
            Texto texto = new Texto();

            texto.Leer("Jornada.txt", out datosJornada);

            return datosJornada;
        }

    }
}
