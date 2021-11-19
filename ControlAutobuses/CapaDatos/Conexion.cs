using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    class Conexion
    {
        SqlConnection _conexion = new SqlConnection("Data Source=LAPTOP-VMT01VSC;Initial Catalog=ControlAutobuses;Integrated Security=True");

        protected SqlConnection Connection { get => _conexion;}
    }
}
