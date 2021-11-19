using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        private readonly SqlConnection connection = new SqlConnection("Data Source=LAPTOP-VMT01VSC;Initial Catalog=ControlAutobuses;Integrated Security=True");

        protected SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
