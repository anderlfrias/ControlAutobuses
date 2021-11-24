using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DataUser : Conexion
    {
        public User FindByUserName(string userName)
        {
            try
            {
                IList<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Usuario", userName));

                this.SqlDataReader = this.SqlQuery("SP_FIND_USER_BY_USERNAME", parameters);

                User user = new User();
                this.SqlDataReader.Read();

                user.Id = this.SqlDataReader.GetString(0);
                user.Codigo = this.SqlDataReader.GetString(1);
                user.Nombre = this.SqlDataReader.GetString(2);
                user.Usuario = this.SqlDataReader.GetString(3);
                user.Password = this.SqlDataReader.GetString(4);
                user.Role = this.SqlDataReader.GetString(5);

                this.sqlConnection.Close();
                this.SqlDataReader.Close();

                return user;
            } catch(Exception)
            {
                return null;
            }
            
        }

        public User FindById(string id)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));

            this.SqlDataReader = this.SqlQuery("SP_FIND_USER_BY_ID", parameters);

            User user = new User();
            this.SqlDataReader.Read();

            user.Id = this.SqlDataReader.GetString(0);
            user.Codigo = this.SqlDataReader.GetString(1);
            user.Nombre = this.SqlDataReader.GetString(2);
            user.Usuario = this.SqlDataReader.GetString(3);
            user.Password = this.SqlDataReader.GetString(4);
            user.Role = this.SqlDataReader.GetString(5);

            this.sqlConnection.Close();
            this.SqlDataReader.Close();
            return user;
        }
    }
}
