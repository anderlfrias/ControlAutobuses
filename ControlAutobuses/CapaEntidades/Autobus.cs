using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CapaEntidades
{
    public class Autobus
    {
        public Autobus()
        {
            Chofer = new Chofer();
        }
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Color { get; set; }
        public int Anio { get; set; }
        public bool Asignado { get; set; }

        public Chofer Chofer { get; set; }
    }
}