using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using ServiceLayer;

namespace BusinessLayer {
    public class PersonBu : interfaces.IPersonBu {
        private readonly ServiceLayer.Interfaces.IPersonRepo _PersonRepo;
        public PersonBu(ServiceLayer.Interfaces.IPersonRepo personRepo) {
            _PersonRepo = personRepo;
        }
        public IEnumerable<Domain.Person> GetPeople() {
            IEnumerable<ServiceLayer.Person> people = _PersonRepo.GetPersons();
            return people.Select(CastPerson);
        }

        public Domain.Person GetPerson(Guid id) {
            ServiceLayer.Person person = _PersonRepo.GetPerson(id);
            return CastPerson(person);
        }

        public void Save() {
            _PersonRepo.Save();
        }

        public Response UpsertPerson(Domain.Person person) {
            Response response = _PersonRepo.UpsertPerson(person);
            Save();
            return response;
        }

        private static Domain.Person CastPerson(ServiceLayer.Person person) {
            return new Domain.Person {
                Id = person.Id,
                Role = new Domain.Role {
                    Id = person.Role.Id,
                    RoleName = person.Role.Name
                },
                Manager = new Domain.Person {
                    Id = person.fk_Manager_Id,
                    Surname = person.Manager == null ? "***" : person.Manager.Surname,
                    Initials = person.Manager == null ? "***" : person.Manager.Initials,
                    Email = person.Email
                },
                CoyNumber = person.CoyNumber,
                Initials = person.Initials,
                Email = person.Email,
                Surname = person.Surname
            };
        }
    }
}
