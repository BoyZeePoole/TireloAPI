using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer {
    public partial class Role {

         public static implicit operator ServiceLayer.Role(Domain.Role role) {
            return new Role {
                Id = Guid.NewGuid(),
                Name = role.RoleName
            };
        }
    }
}
