using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Ruta
    {
        public Ruta()
        {
            //Chofer = new Chofer();
        }
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Asignado { get; set; }

        //public Chofer Chofer { get; set; }
    }
}
