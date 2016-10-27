﻿using System;
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

        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;
        
        //QUE HAGO CON EL ESTADO DE CUENTA EN ESTE CONSTRUCTOR???
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            return this.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.MostrarDatos());
            sb.Append("CARNET NÚMERO: ");
            //COMO MUESTRO EL ID SI EN PersonaGimnasio ES PRIVATE??
            sb.Append("ESTADO DE CUENTA: ");
            sb.Append(this._estadoCuenta.ToString() + "\n");
            sb.Append(this.ParticiparEnClase() + "\n");
            return sb.ToString();
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