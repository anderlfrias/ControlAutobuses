using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class RutaNegocio
    {
        string message;
        readonly DataRuta _dataRuta;
        public RutaNegocio()
        {
            _dataRuta = new DataRuta();
        }

        public string Create(Ruta model)
        {
            if (string.IsNullOrEmpty(model.Nombre))
            {
                message = "Nombre no proporcionado";
            }
            else
            {
                try
                {
                    model.Id = Guid.NewGuid().ToString().ToUpper();
                    _dataRuta.Add(model);
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

        public IList<Ruta> Get(string filtro = "")
        {
            var result = _dataRuta.Find(filtro);
            return result;
        }

        public Ruta GetById(string id)
        {
            var result = _dataRuta.FindById(id);
            return result;
        }

        public string Update(Ruta model)
        {
            if (string.IsNullOrEmpty(model.Id))
            {
                message = "Id no proporcionado";
            }
            else
            {
                try
                {
                    _dataRuta.Update(model);
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
                    _dataRuta.Remove(id);
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
