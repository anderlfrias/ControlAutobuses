using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DataViajes : Conexion
    {
        public IList<Viajes> Find()
        {
            this.SqlDataReader = this.SqlQuery("SP_MOSTRAR_INFORMES");

            IList<Viajes> viajes = new List<Viajes>();
            while (this.SqlDataReader.Read())
            {
                viajes.Add(new Viajes
                {
                    ChoferId = this.SqlDataReader.GetString(0),
                    AutobusId = this.SqlDataReader.GetString(1),
                    RutaId = this.SqlDataReader.GetString(2),
                    NombreChofer = this.SqlDataReader.GetString(3),
                    Cedula = this.SqlDataReader.GetString(4),
                    MarcaAutobus = this.SqlDataReader.GetString(5),
                    Placa = this.SqlDataReader.GetString(6),
                    NombreRuta = this.SqlDataReader.GetString(7),
                });
            }

            this.sqlConnection.Close();
            this.SqlDataReader.Close();
            return viajes;
        } 
    }
}
