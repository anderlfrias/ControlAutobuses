using CapaEntidades;
using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class DataAutobus : Conexion
    {
        public void Add(Autobus model)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", model.Id));
            parameters.Add(new SqlParameter("@Marca", model.Marca));
            parameters.Add(new SqlParameter("@Modelo", model.Modelo));
            parameters.Add(new SqlParameter("@Placa", model.Placa));
            parameters.Add(new SqlParameter("@Color", model.Color));
            parameters.Add(new SqlParameter("@Anio", model.Anio));
            parameters.Add(new SqlParameter("@Asignado", model.Asignado));

            this.SqlDataReader = this.SqlQuery("SP_CREATE_AUTOBUS", parameters);

            this.sqlConnection.Close();
        }

        public IList<Autobus> Find(string filtro)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@FILTRAR", filtro));

            this.SqlDataReader = this.SqlQuery("SP_FILTRAR_AUTOBUS", parameters);

            IList<Autobus> autobuses = new List<Autobus>();
            while(this.SqlDataReader.Read())
            {
                autobuses.Add(new Autobus
                {
                    Id = this.SqlDataReader.GetString(0),
                    Codigo = this.SqlDataReader.GetString(1),
                    Marca = this.SqlDataReader.GetString(2),
                    Modelo = this.SqlDataReader.GetString(3),
                    Placa = this.SqlDataReader.GetString(4),
                    Color = this.SqlDataReader.GetString(5),
                    Anio = this.SqlDataReader.GetInt16(6),
                    Asignado = this.SqlDataReader.GetBoolean(7)                        
                });
            }

            this.sqlConnection.Close();
            this.SqlDataReader.Close();
            return autobuses;
        }

        public Autobus FindById(string id)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", id));

            this.SqlDataReader = this.SqlQuery("SP_FIND_AUTOBUS_BY_ID", parameters);

            Autobus autobus = new Autobus();
            this.SqlDataReader.Read();

            autobus.Id = this.SqlDataReader.GetString(0);
            autobus.Codigo = this.SqlDataReader.GetString(1);
            autobus.Marca = this.SqlDataReader.GetString(2);
            autobus.Modelo = this.SqlDataReader.GetString(3);
            autobus.Placa = this.SqlDataReader.GetString(4);
            autobus.Color = this.SqlDataReader.GetString(5);
            autobus.Anio = this.SqlDataReader.GetInt16(6);
            autobus.Asignado = this.SqlDataReader.GetBoolean(7);

            this.sqlConnection.Close();
            this.SqlDataReader.Close();
            return autobus;
        }

        public void Update(Autobus model)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", model.Id));
            parameters.Add(new SqlParameter("@Marca", model.Marca));
            parameters.Add(new SqlParameter("@Modelo", model.Modelo));
            parameters.Add(new SqlParameter("@Placa", model.Color));
            parameters.Add(new SqlParameter("@Color", model.Color));
            parameters.Add(new SqlParameter("@Anio", model.Anio));

            this.SqlDataReader = this.SqlQuery("SP_MODIFICAR_AUTOBUS", parameters);
            this.sqlConnection.Close();

        }

        public void Remove(string id)
        {
            IList<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));

            this.SqlDataReader = this.SqlQuery("SP_ELIMINAR_AUTOBUS", parameters);
            this.sqlConnection.Close();

        }
    }
}