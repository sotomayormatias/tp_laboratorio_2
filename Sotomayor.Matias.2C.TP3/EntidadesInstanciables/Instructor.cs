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
        
        private Instructor() 
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
        }
    }
}
