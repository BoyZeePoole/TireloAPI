using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces {
    public interface IPersonRepo {
        Response UpsertPerson(Domain.Person person);
        IEnumerable<Person> GetPersons();
        Person GetPerson(Guid id);
        void Save();
    }
}
