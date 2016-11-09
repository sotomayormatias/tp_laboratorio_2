using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : PersonaGimnasio
    {
        public enum EEstadoCuenta { MesPrueba, Deudor, AlDia };

        public Gimnasio.EClases _claseQueToma;
        public EEstadoCuenta _estadoCuenta;

        public Alumno()
        { 
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma, EEstadoCuenta.MesPrueba)
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
            this._estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno alumno, Gimnasio.EClases clase)
        {
            return (alumno._estadoCuenta != EEstadoCuenta.Deudor && alumno._claseQueToma == clase);
        }

        public static bool operator !=(Alumno alumno, Gimnasio.EClases clase)
        {
            return alumno._claseQueToma != clase;
        }
    }
}
