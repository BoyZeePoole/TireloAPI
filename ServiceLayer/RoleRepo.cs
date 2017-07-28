using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace ServiceLayer
{
    public class RoleRepo : Interfaces.IRoleRepo {
        private readonly TireloContext _Context;

        public RoleRepo(TireloContext context) {
            _Context = context;
        }
        public Role GetRole(Guid id) {
            return _Context.Roles.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Role> GetRoles() {
            return _Context.Roles;
        }

        public void Save() {
            _Context.SaveChanges();
        }

        public Response UpsertRole(Domain.Role role) {
            Role roleEntity = _Context.Roles.SingleOrDefault(x => x.Id == role.Id);
            if (roleEntity != null) {
                roleEntity.Name = role.RoleName;
            }
            else {
                roleEntity = role;
                _Context.Roles.Add(roleEntity);
            }
            var response = new Response {
                Updated = true,
                Success = true
            };
            
            return response;
        }
    }
}
