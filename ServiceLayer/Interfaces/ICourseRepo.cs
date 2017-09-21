using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces {
    public interface ICourseRepo {
        Response UpsertCourse(Domain.Course course);
        IEnumerable<Course> GetCourses();
        Course GetCourse(Guid id);

        Response UpsertPersonCourse(Domain.PersonCourse personCourse);
        void Save();

        IEnumerable<PersonCourse> GetPersonCourses(
            Guid id);

        Response DeletePersonCourses(
            string[] ids);

        Response DeletePerson(string id);

    }
}
