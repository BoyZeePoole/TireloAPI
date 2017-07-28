using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.interfaces {
    public interface ICourseBu {
        Response UpsertCourse(Course course);
        IEnumerable<Course> GetCourses();
        Response UpsertPersonCourse(PersonCourse personCourse);

        Course GetCourse(
         Guid id);

        void Save();

        IEnumerable<PersonCourse> GetPersonCourses(
            Guid id);

    }
}
