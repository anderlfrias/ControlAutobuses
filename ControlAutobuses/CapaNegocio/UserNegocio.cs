﻿using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class UserNegocio
    {
        readonly DataUser _dataUser;
        string message;

        public UserNegocio()
        {
            _dataUser = new DataUser();
        }

        public User GetByUserName(string userName)
        {
            var result = _dataUser.FindByUserName(userName);
            return result;
        }

        public User GetById(string id)
        {
            var result = _dataUser.FindById(id);
            return result;
        }

        public string Create(User model)
        {
            if ((string.IsNullOrEmpty(model.Usuario)) || (string.IsNullOrEmpty(model.Password)))
            {
                message = "Asegurese de completar correctamento los campos de usuario y contrasea;"
            }
            else 
            {
                try
                {
                    model.Id = Guid.NewGuid().ToString().ToUpper();
                    _dataUser.Add(model);
                    message = "Registro exitoso";
                }
                catch(Exception ex)
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
