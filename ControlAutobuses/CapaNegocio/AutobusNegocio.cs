using CapaDatos;
using CapaEntidades;
using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class AutobusNegocio
    {
        readonly DataAutobus _dataAutobus;
        string message;

        public AutobusNegocio()
        {
            _dataAutobus = new DataAutobus();
        }

        public string Create(Autobus model)
        {
            if (string.IsNullOrEmpty(model.Placa))
            {
                message = "Placa no proporcionada";
            }
            else
            {
                try
                {
                    model.Id = Guid.NewGuid().ToString().ToUpper();
                    _dataAutobus.Add(model);
                    message = "Operacion exitosa.";
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        message = ex.InnerException.Message;
                    else
                        message = ex.Message;
                }
            }
            return message;
        }

        public IList<Autobus> Get(string filtro = "")
        {
            var result = _dataAutobus.Find(filtro);
            return result;
        }

        public Autobus GetById(string id)
        {
            var result = _dataAutobus.FindById(id);
            return result;
        }

        public string Update(Autobus model)
        {
            if (string.IsNullOrEmpty(model.Id))
            {
                message = "Id no proporcionado";
            }
            else
            {
                try
                {
                    _dataAutobus.Update(model);
                    message = "Operacion exitosa";
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        message = ex.InnerException.Message;
                    else
                        message = ex.Message;
                }
            }
            return message;
        }

        public string Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                message = "Id no proporcionado";
            }
            else
            {
                try
                {
                    _dataAutobus.Remove(id);
                    message = "Operacion exitosa";
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        message = ex.InnerException.Message;
                    else
                        message = ex.Message;
                }
            }
            return message;
        }
    }
}