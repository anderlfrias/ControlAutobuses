using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DataChofer : Conexion
    {
        public void Add(Chofer model)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", model.Id));
            parameters.Add(new SqlParameter("@Nombre", model.Nombre));
            parameters.Add(new SqlParameter("@Apellido", model.Apellido));
            parameters.Add(new SqlParameter("@BirthDate", model.BirthDay));
            parameters.Add(new SqlParameter("@Cedula", model.Cedula));
            parameters.Add(new SqlParameter("@AutobusId", model.AutobusId));
            parameters.Add(new SqlParameter("@Ruta", model.RutaId));

            this.SqlDataReader = this.SqlQuery("SP_CREATE_CHOFER", parameters);

            this.sqlConnection.Close();
        }

        public IList<Chofer> Find(string filtro)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@FILTRO", filtro));

            this.SqlDataReader = this.SqlQuery("SP_FILTRAR_CHOFERES", parameters);

            IList<Chofer> choferes = new List<Chofer>();
            Chofer chofer;
            while (this.SqlDataReader.Read())
            {
                chofer = new Chofer();
                chofer.Id = this.SqlDataReader.GetString(0);
                chofer.Codigo = this.SqlDataReader.GetString(1);
                chofer.Nombre = this.SqlDataReader.GetString(2);
                chofer.Apellido = this.SqlDataReader.GetString(3);
                chofer.BirthDay = this.SqlDataReader.GetDateTime(4);
                chofer.Cedula = this.SqlDataReader.GetString(5);
                try
                {
                    chofer.AutobusId = this.SqlDataReader.GetString(6);
                    chofer.RutaId = this.SqlDataReader.GetString(7);
                }
                catch (Exception)
                {
                    chofer.AutobusId = null;
                    chofer.RutaId = null;
                }
                choferes.Add(chofer);
            }

            this.sqlConnection.Close();
            this.SqlDataReader.Close();
            return choferes;
        }

        public Chofer FindById(string id)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", id));

            this.SqlDataReader = this.SqlQuery("SP_FIND_CHOFER_BY_ID", parameters);

            Chofer chofer = new Chofer();
            this.SqlDataReader.Read();

            chofer.Id = this.SqlDataReader.GetString(0);
            chofer.Codigo = this.SqlDataReader.GetString(1);
            chofer.Nombre = this.SqlDataReader.GetString(2);
            chofer.Apellido = this.SqlDataReader.GetString(3);
            chofer.BirthDay = this.SqlDataReader.GetDateTime(4);
            chofer.Cedula = this.SqlDataReader.GetString(5);
            chofer.AutobusId = this.SqlDataReader.GetString(6);
            chofer.RutaId = this.SqlDataReader.GetString(7);

            this.sqlConnection.Close();
            this.SqlDataReader.Close();
            return chofer;
        }

        public void Update(Chofer model)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", model.Id));
            parameters.Add(new SqlParameter("@Codigo", model.Codigo));
            parameters.Add(new SqlParameter("@Nombre", model.Nombre));
            parameters.Add(new SqlParameter("@Apellido", model.Apellido));
            parameters.Add(new SqlParameter("@BirthDate", model.BirthDay));
            parameters.Add(new SqlParameter("@Cedula", model.Cedula));
            parameters.Add(new SqlParameter("@AutobusId", model.AutobusId));
            parameters.Add(new SqlParameter("@RutaId", model.RutaId));

            this.SqlDataReader = this.SqlQuery("SP_MODIFICAR_RUTA", parameters);
            this.sqlConnection.Close();
        }

        public void Remove(string id)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));

            this.SqlDataReader = this.SqlQuery("SP_ELIMINAR_CHOFER", parameters);
            this.sqlConnection.Close();
        }
    }
}
