using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Calculadora
    {

        #region MetodosDeClase
            /// <summary>
            /// Realiza la operacion pasada por paramentro entre los numeros tambien pasados por parametro
            /// </summary>
            /// <param name="numero1">Numero con el que realiza la operacion</param>
            /// <param name="numero2">Numero con el que realiza la operacion</param>
            /// <param name="operador">operacion a realizar</param>
            /// <returns>Retorna el resultado de la operacion</returns>
            public static double operar(Numero numero1, Numero numero2, string operador)
            {
                double resultado;

                switch (operador)
                {
                    case "+":
                        resultado = numero1.getNumero() + numero2.getNumero();
                        break;
                    case "-":
                        resultado = numero1.getNumero() - numero2.getNumero();
                        break;
                    case "*":
                        resultado = numero1.getNumero() * numero2.getNumero();
                        break;
                    case "/":
                        if (numero2.getNumero() != 0)
                            resultado = numero1.getNumero() / numero2.getNumero();
                        else
                            resultado = 0;
                        break;
                    default:
                        resultado = 0;
                        break;
                }

                return resultado;
            }

            /// <summary>
            /// Valida que el operador sea correcto
            /// </summary>
            /// <param name="operador">string que representa al operador</param>
            /// <returns>Si no es un operador valido, retorna "+", sino retorna el mismo operador que ingresó</returns>
            public static string validarOperador(string operador)
            {
                if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
                    operador = "+";

                return operador;
            } 
        #endregion
    }
}
