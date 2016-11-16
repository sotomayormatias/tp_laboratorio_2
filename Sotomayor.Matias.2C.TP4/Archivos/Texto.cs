using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivo;
        private static string PATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";

        public Texto(string archivo)
        {
            this._archivo = archivo;
        }

        public bool guardar(string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(PATH + this._archivo, false, Encoding.UTF8);
                sw.Write(datos);
                sw.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            try
            {
                StreamReader sr = new StreamReader(PATH + this._archivo, Encoding.UTF8);
                datos.Add(sr.ReadLine());

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
