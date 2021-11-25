using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ViajesNegocio
    {
        readonly DataViajes _dataViajes;
        public ViajesNegocio()
        {
            _dataViajes = new DataViajes();
        }

        public IList<Viajes> GetViajes()
        {
            var result = _dataViajes.Find();
            return result;
        }
    }
}
