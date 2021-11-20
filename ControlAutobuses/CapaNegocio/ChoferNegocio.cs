using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ChoferNegocio
    {
        string message;
        readonly DataChofer _dataChofer;

        public ChoferNegocio()
        {
            _dataChofer = new DataChofer();
        }

        public string Create(Chofer model)
        {
            if (string.IsNullOrEmpty(model.Cedula))
            {
                message = "Cedula no proporcionada";
            }
            else
            {
                try
                {
                    model.Id = Guid.NewGuid().ToString().ToUpper();
                    _dataChofer.Add(model);
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

        public IList<Chofer> Get(string filtro = "")
        {
            var result = _dataChofer.Find(filtro);
            return result;
        }

        public Chofer GetById(string id)
        {
            var result = _dataChofer.FindById(id);
            return result;
        }

        public string Update(Chofer model)
        {
            if (string.IsNullOrEmpty(model.Id))
            {
                message = "Id no proporcionado";
            }
            else
            {
                try
                {
                    _dataChofer.Update(model);
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
                    _dataChofer.Remove(id);
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
