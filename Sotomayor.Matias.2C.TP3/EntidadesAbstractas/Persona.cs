using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero };

        #region Atributos y Propiedades
        private string _apellido;

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = ValidarNombreApellido(value); }
        }

        private int _dni;

        public int DNI
        {
            get { return _dni; }
            set { _dni = ValidarDni(this.Nacionalidad, value); }
        }

        private ENacionalidad _nacionalidad;

        public ENacionalidad Nacionalidad
        {
            get { return _nacionalidad; }
            set { _nacionalidad = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = ValidarNombreApellido(value); }
        }

        [XmlIgnore]
        public string StringToDNI
        {
            set
            {
                try
                {
                    this._dni = ValidarDni(this.Nacionalidad, value);
                }
                catch (Exception)
                {
                    throw new NacionalidadInvalidaException();
                }
            }
        }
        #endregion


        #region Constructores
        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this._dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        } 
        #endregion

        #region Metodos
        /// <summary>
        /// Valida que el dni sea coherente con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            bool dniInvalido = false;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        dniInvalido = true;
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000 || dato > 99999999)
                        dniInvalido = true;
                    break;
                default:
                    throw new NacionalidadInvalidaException("Nacionalidad inexistente");
            }

            if (dniInvalido)
                throw new DniIvalidoException("El dni es invalido");
            else
                return dato;
        }

        /// <summary>
        /// Valida que el dni sea coherente con la nacionalidad, reutiliza el ValidarDni que recibe el dni como tipo int
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                return ValidarDni(nacionalidad, int.Parse(dato));
            }
            catch (DniIvalidoException)
            {
                throw;
            }
            catch (NacionalidadInvalidaException)
            {
                throw;
            }
            catch (FormatException)
            {
                throw new DniIvalidoException("El dni no es numerico");
            }
        }


        /// <summary>
        /// Valida que tanto el nombre como el apellido sean solo caracteres
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            //Se establece una expresion regular para validar que el dato ingresado
            //sea coherente para un nombre y apellido (que contenga solo letras, sin numeros ni simbolos)
            Regex reg = new Regex("^[A-Za-z]+$");
            if (reg.IsMatch(dato))
                return dato;
            else
                return "";
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this._apellido + ", " + this._nombre);
            sb.AppendLine("NACIONALIDAD: " + this._nacionalidad.ToString());
            return sb.ToString();
        } 
        #endregion
    }
}
