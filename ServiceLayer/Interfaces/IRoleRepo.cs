﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces {
    public interface IRoleRepo {
        Response UpsertRole(Domain.Role role);
        IEnumerable<Role> GetRoles();
        Role GetRole(Guid id);

        void Save();
    }
}
