using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace ServiceLayer {
    public class CourseRepo : Interfaces.ICourseRepo {
        private readonly TireloContext _Context;

        public CourseRepo(TireloContext context) {
            _Context = context;
        }

        public Course GetCourse(Guid id) {
            return _Context.Courses.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Course> GetCourses() {
            return _Context.Courses;
        }

        public IEnumerable<PersonCourse> GetPersonCourses(Guid id) {
            IEnumerable<PersonCours> personCourses = _Context.PersonCourses.Where(x => x.Person.Id == id);
            var personCourse = new List<PersonCourse>();
            foreach (PersonCours pc in personCourses) {
                personCourse.Add(new PersonCourse {
                    Id = pc.Id,
                    Course = ConvertCourse(pc.Course),
                    DateRegistered = pc.Date_Registered,
                    DateCompleted = Convert.ToDateTime(pc.Date_Completed),
                    Manager = pc.Person.Manager != null ? ConvertPerson(pc.Person.Manager): null,
                    Employee = pc.Person != null ? ConvertPerson(pc.Person) : null
                });
            }
            return personCourse;
        }

        private static Domain.Course ConvertCourse(Course course) {
            return new Domain.Course {
                Id = course.Id,
                Name = course.Name,
                ValidPeriod = course.ValidPeriod
            };
        }

        private static Domain.Person ConvertPerson(Person person) {
            return new Domain.Person {
                Id = person.Id,
                Initials = person.Initials,
                Surname = person.Surname
            };
        }
        public void Save() {
            _Context.SaveChanges();
        }

        public Response UpsertCourse(Domain.Course course) {
            Course courseEntity = _Context.Courses.Find(course.Id);
            if (courseEntity != null) {
                courseEntity.Name = course.Name;
                courseEntity.ValidPeriod = course.ValidPeriod;
            }
            else {
                courseEntity = (Course)course;
                _Context.Courses.Add(courseEntity);
            }
            var response = new Response {
                Success = true,
                Updated = true
            };
            return response;
        }

        public Response UpsertPersonCourse(PersonCourse personCourse) {
            Person personEntity = _Context.People.Find(personCourse.Employee.Id);
            Course courseEntity = _Context.Courses.Find(personCourse.Course.Id);
            if (personCourse.Id != null) {
                PersonCours personCourseEntity = _Context.PersonCourses.Find(personCourse.Id);
                if (personCourseEntity != null) {
                    personCourseEntity.Person = personEntity;
                    personCourseEntity.Course = courseEntity;
                    personCourseEntity.Date_Registered = personCourse.DateRegistered;
                    personCourseEntity.Date_Completed = personCourse.DateCompleted;
                }
                else {
                    return new Response {
                        Updated = false,
                        Success = false,
                        Errors = new List<Errors>() {
                            new Errors {
                                Error = "Course does not exist"
                            }
                        }
                    };
                }
            }
            else {
                var personCourseEntity = new ServiceLayer.PersonCours {
                    Id = Guid.NewGuid(),
                    Person = personEntity,
                    Course = courseEntity,
                    Date_Completed = personCourse.DateCompleted,
                    Date_Registered = personCourse.DateRegistered
                };
                _Context.PersonCourses.Add(personCourseEntity);
            }
            
            return new Response() {
                Success = true,
                Updated = true
            };
        }
    }
}
