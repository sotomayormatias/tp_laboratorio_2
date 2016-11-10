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
                string dni = "treintaycuatro456987";
                Alumno alumno = new Alumno(10, "Diego", "Maradona", dni, Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }
    }
}
