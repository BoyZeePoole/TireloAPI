using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer {

    public partial class Person {

        public static implicit operator ServiceLayer.Person(Domain.Person person) {
            return new Person {
                Id = Guid.NewGuid(),
                Role = person.Role,
                CoyNumber = person.CoyNumber,
                Surname = person.Surname,
                Initials = person.Initials,
                Email = person.Email
            };
        }

    }

}
