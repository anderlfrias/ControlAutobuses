using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DataRole : Conexion
    {
        public Role FindByRoleName(string name)
        {
            try
            {
                IList<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Nombre", name));

                this.SqlDataReader = this.SqlQuery("SP_FIND_ROLE_BY_NAME", parameters);

                Role role = new Role();
                this.SqlDataReader.Read();

                role.Id = this.SqlDataReader.GetString(0);
                role.Codigo = this.SqlDataReader.GetString(1);
                role.Nombre = this.SqlDataReader.GetString(2);
                role.NombreNormal = this.SqlDataReader.GetString(3);

                this.sqlConnection.Close();
                this.SqlDataReader.Close();

                return role;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
