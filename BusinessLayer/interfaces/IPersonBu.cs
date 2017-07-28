using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.interfaces {
    public interface IPersonBu {

        Response UpsertPerson(Person person);
        IEnumerable<Person> GetPeople();

        Person GetPerson(Guid id);

        void Save();

    }
}
