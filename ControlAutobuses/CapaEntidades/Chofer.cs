using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Chofer
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime BirthDay { get; set; }
        public string Cedula { get; set; }

        public string AutobusId { get; set; }
        public string RutaId { get; set; }

        public Autobus Autobus { get; set; }
        public Ruta Ruta { get; set; }
    }
}
