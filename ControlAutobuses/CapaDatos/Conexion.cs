using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public abstract class Conexion
    {
        //private readonly SqlConnection connection = new SqlConnection("Data Source=LAPTOP-VMT01VSC;Initial Catalog=ControlAutobuses;Integrated Security=True");

        protected SqlConnection sqlConnection;
        protected SqlCommand sqlCommand;
        protected SqlDataReader SqlDataReader;

        public Conexion()
        {
            sqlConnection = new SqlConnection("Data Source=LAPTOP-VMT01VSC;Initial Catalog=ControlAutobuses;Integrated Security=True");
        }

        public SqlDataReader SqlQuery(string StoreProcedure, IList<SqlParameter>parametros = null)
        {
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = StoreProcedure;
            
            sqlConnection.Open();

            if(parametros != null)
            {
                foreach (var item in parametros)
                {
                    sqlCommand.Parameters.Add(item);
                }
            }

            return sqlCommand.ExecuteReader();
        }
    }
}
