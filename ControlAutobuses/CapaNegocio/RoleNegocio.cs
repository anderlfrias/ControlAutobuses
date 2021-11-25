using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class RoleNegocio
    {
        readonly DataRole _dataRole;

        public RoleNegocio()
        {
            _dataRole = new DataRole();
        }

        public Role GetByRoleName(string name)
        {
            var result = _dataRole.FindByRoleName(name);
            return result;
        }
    }
}
