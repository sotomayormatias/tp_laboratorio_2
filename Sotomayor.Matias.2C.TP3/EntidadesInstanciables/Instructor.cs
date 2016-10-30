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
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        //TODO: RESOLVER EL TEMA DE LOS CONSTRUCTORES
        //SI SE DEBEN AGREGAR LOS CONST POR DEFECTO, QUE VALOR SE PONE?
        private Instructor()
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            Instructor._random = new Random();

            this._randomClases();
            this._randomClases();
        }

        //ESTE TIENE QUE LLAMAR A BASE O A THIS??
        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
        }

        private void _randomClases()
        {
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
            StringBuilder sb = new StringBuilder(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        protected override string MostrarDatos()
        {
            return this.ToString();
        }

        public static bool operator ==(Instructor instructor, Gimnasio.EClases clase)
        {
            return instructor._clasesDelDia.Contains(clase);
        }

        public static bool operator !=(Instructor instructor, Gimnasio.EClases clase)
        {
            return !(instructor == clase);
        }
    }
}
