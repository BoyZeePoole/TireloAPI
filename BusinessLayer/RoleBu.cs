using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using ServiceLayer;

namespace BusinessLayer
{
    public class RoleBu : interfaces.IRoleBu {

        private readonly ServiceLayer.Interfaces.IRoleRepo _RoleRepo;

        public RoleBu(ServiceLayer.Interfaces.IRoleRepo roleRepo) {
            _RoleRepo = roleRepo;
        }
        public Domain.Role GetRole(Guid id) {
            ServiceLayer.Role role = _RoleRepo.GetRole(id);
            return new Domain.Role {
                Id = role.Id,
                RoleName = role.Name
            };
        }

        public IEnumerable<Domain.Role> GetRoles() {
            IEnumerable<ServiceLayer.Role> roles = _RoleRepo.GetRoles();
            return roles.Select(role => new Domain.Role {
                RoleName = role.Name, Id = role.Id
            }).ToList();
        }

        public void Save() {
            _RoleRepo.Save();
        }

        public Response UpsertRole(Domain.Role role) {
            Response response = _RoleRepo.UpsertRole(role);
            Save();
            return response;
        }
    }
}
