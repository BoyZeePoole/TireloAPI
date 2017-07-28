using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.interfaces {
    public interface IRoleBu {
        Response UpsertRole(Role role);
        IEnumerable<Role> GetRoles();
            
           Role GetRole(
            Guid id);

        void Save();

    }
}
