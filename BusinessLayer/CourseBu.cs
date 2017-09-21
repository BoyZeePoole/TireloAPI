using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BusinessLayer {
    public class CourseBu : interfaces.ICourseBu {

        private readonly ServiceLayer.Interfaces.ICourseRepo _CourseRepo;

        public CourseBu(ServiceLayer.Interfaces.ICourseRepo courseRepo) {
            _CourseRepo = courseRepo;
        }

        public Course GetCourse(Guid id) {
            ServiceLayer.Course course = _CourseRepo.GetCourse(id);
            return CastCourse(course);
        }

        public IEnumerable<Course> GetCourses() {
            IEnumerable<ServiceLayer.Course> courses = _CourseRepo.GetCourses();
            return courses.Select(CastCourse);
        }

        public void Save() {
            _CourseRepo.Save();
        }

        public Response UpsertCourse(Course course) {
            Response response = _CourseRepo.UpsertCourse(course);
            Save();
            return response;
        }
        private static Domain.Course CastCourse(ServiceLayer.Course course) {
            return new Domain.Course {
                Id = course.Id,
                Name = course.Name,
                ValidPeriod = course.ValidPeriod
            };
        }

        public Response UpsertPersonCourse(PersonCourse personCourse) {
            Response response = _CourseRepo.UpsertPersonCourse(personCourse);

            Save();
            return response;
        }

        public IEnumerable<PersonCourse> GetPersonCourses(Guid id) {
            return _CourseRepo.GetPersonCourses(id);
        }

        public Response DeletePersonCourses(
            string[] ids) {
            Response response = _CourseRepo.DeletePersonCourses(ids);
            Save();
            return response;
        }

        public Response DeletePerson(string id)
        {
            return _CourseRepo.DeletePerson(id);
        }
    }
}
