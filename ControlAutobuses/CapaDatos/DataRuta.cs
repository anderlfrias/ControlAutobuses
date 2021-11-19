using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DataRuta : Conexion
    {
        public void Add(Ruta model)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", model.Id));
            parameters.Add(new SqlParameter("@Nombre", model.Nombre));
            parameters.Add(new SqlParameter("@Descripcion", model.Descripcion));
            parameters.Add(new SqlParameter("@Asignado", model.Asignado));

            this.SqlDataReader = this.SqlQuery("SP_CREATE_RUTA", parameters);

            this.sqlConnection.Close();
        }

        public IList<Ruta> Find(string filtro)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@FILTRO", filtro));

            this.SqlDataReader = this.SqlQuery("SP_FILTRAR_RUTAS", parameters);

            IList<Ruta> rutas = new List<Ruta>();
            while (this.SqlDataReader.Read())
            {
                rutas.Add(new Ruta
                {
                    Id = this.SqlDataReader.GetString(0),
                    Codigo = this.SqlDataReader.GetString(1),
                    Nombre = this.SqlDataReader.GetString(2),
                    Descripcion = this.SqlDataReader.GetString(3),
                    Asignado = this.SqlDataReader.GetBoolean(4)
                });
            }

            this.sqlConnection.Close();
            this.SqlDataReader.Close();
            return rutas;
        }

        public Ruta FindById(string id)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", id));

            this.SqlDataReader = this.SqlQuery("SP_FIND_RUTA_BY_ID", parameters);

            Ruta ruta = new Ruta();
            this.SqlDataReader.Read();

            ruta.Id = this.SqlDataReader.GetString(0);
            ruta.Codigo = this.SqlDataReader.GetString(1);
            ruta.Nombre = this.SqlDataReader.GetString(2);
            ruta.Descripcion = this.SqlDataReader.GetString(3);
            ruta.Asignado = this.SqlDataReader.GetBoolean(4);

            this.sqlConnection.Close();
            this.SqlDataReader.Close();
            return ruta;
        }

        public void Update(Ruta model)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", model.Id));
            parameters.Add(new SqlParameter("@Codigo", model.Codigo));
            parameters.Add(new SqlParameter("@Nombre", model.Nombre));
            parameters.Add(new SqlParameter("@Descripcion", model.Descripcion));
            parameters.Add(new SqlParameter("@Asingnado", model.Asignado));

            this.SqlDataReader = this.SqlQuery("SP_MODIFICAR_RUTA", parameters);
            this.sqlConnection.Close();
        }

        public void Remove(string id)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));

            this.SqlDataReader = this.SqlQuery("SP_ELIMINAR_RUTA", parameters);
            this.sqlConnection.Close();
        }
    }
}
