using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public class Instructor : PersonaGimnasio
    {
        public Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        static Instructor()
        {
            Instructor._random = new Random();
        }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {

            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();
        }

        private void _randomClases()
        {
            this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(3));
            this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(3));
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DÍA:");
            foreach (Gimnasio.EClases clase in this._clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        public static bool operator ==(Instructor instructor, Gimnasio.EClases clase)
        {
            bool esIgual = false;

            foreach (Gimnasio.EClases unaClase in instructor._clasesDelDia)
            {
                if (unaClase == clase)
                    esIgual = true;
            }

            return esIgual;
        }

        public static bool operator !=(Instructor instructor, Gimnasio.EClases clase)
        {
            return !(instructor == clase);
        }
    }
}
