using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace ServiceLayer {
    public class PersonRepo : Interfaces.IPersonRepo {
        private readonly TireloContext _Context;

        public PersonRepo(TireloContext context) {
            _Context = context;
        }

        public IEnumerable<Person> GetPersons() {
            return _Context.People;
        }

        public Person GetPerson(Guid id) {
            return _Context.People.SingleOrDefault(x => x.Id == id);
        }

        public void Save() {
            _Context.SaveChanges();
        }

        public Response UpsertPerson(Domain.Person person) {
            Person personEntity = _Context.People.SingleOrDefault(x => x.Id == person.Id);
            Person manager = _Context.People.SingleOrDefault(x => x.Id == person.Manager.Id);
            if (personEntity != null) {
                personEntity.Role = _Context.Roles.Find(person.Role.Id);
                personEntity.CoyNumber = person.CoyNumber;
                personEntity.Initials = person.Initials;
                personEntity.Email = person.Email;
                personEntity.Surname = person.Surname;
                personEntity.Manager = manager;
            }
            else {
                personEntity = (Person) person;
                personEntity.Role = _Context.Roles.Find(person.Role.Id);
                personEntity.Manager = manager;
                _Context.People.Add(personEntity);
            }
            var response = new Response {
                Success = true,
                Updated = true
            };
            return response;
        }
    }
}
