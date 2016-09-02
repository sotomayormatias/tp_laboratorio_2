using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Numero
    {
        /// <summary>
        /// Atributo que almacena el valor numerico del objeto
        /// </summary>
        private double _numero;

        #region Constructores
            /// <summary>
            /// Constructor por defecto (sin parametros)
            /// </summary>
            public Numero()
            {
                this._numero = 0;
            }

            /// <summary>
            /// Constructor que recibe parametro string y setea el parametro a un formato adecuado
            /// </summary>
            /// <param name="unNumero">numero de tipo string</param>
            public Numero(string unNumero)
            {
                this.setNumero(unNumero);
            }

            /// <summary>
            /// Constructor que recibe parametro double y lo almacena
            /// </summary>
            /// <param name="unNumero">Numero de tipo double</param>
            public Numero(double unNumero)
            {
                this._numero = unNumero;
            } 
        #endregion

        #region MetodosDeInstancia
            /// <summary>
            /// Valida el numero pasado por parametro y se setea al formato adecuado
            /// </summary>
            /// <param name="unNumero"></param>
            /// <returns></returns>
            private void setNumero(string unNumero)
            {
                this._numero = validarNumero(unNumero);
            }

            /// <summary>
            /// Retorna el valor del atributo _numero
            /// </summary>
            /// <returns></returns>
            public double getNumero() 
            {
                return this._numero;
            }
        #endregion

        #region MetodosDeClase
            /// <summary>
            /// Valida el numero pasado por parametro, si se puede, lo parsea; si no se puede, retorna 0
            /// </summary>
            /// <param name="unNumero">Numero de tipo string</param>
            /// <returns>Numero parseado o con valor 0</returns>
            private static double validarNumero(string unNumero)
            {
                int numeroFinal = 0;

                int.TryParse(unNumero, out numeroFinal);
                return numeroFinal;
            } 
        #endregion
    }
}
