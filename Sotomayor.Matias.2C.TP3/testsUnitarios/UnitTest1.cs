using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace TestsUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DniNoNumericoTest()
        {
            try
            {
                //Se genera un alumno con un dni que no es numerico
                string dni = "treintaycuatro456987";
                Alumno alumno = new Alumno(10, "Diego", "Maradona", dni, Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit);
            }
            catch (Exception e)
            {
                //Se lanza excepecion de nacionalidad invalida
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void GimnasioInstanciaSusAtributosTest()
        {
            Gimnasio gym = new Gimnasio();

            //La lista de alumnos fue instanciada
            Assert.IsNotNull(gym._alumnos);

            //La lista de instructores fue instanciada
            Assert.IsNotNull(gym._instructores);

            //La lista de jornadas fue instanciada
            Assert.IsNotNull(gym._jornadas);
        }
    }
}
