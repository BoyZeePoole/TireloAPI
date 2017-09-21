using BusinessLayer.interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace TireloAPI.Controllers
{
    public class TireloController : ApiController {

        private IRoleBu BusinessRole { get; }
        private IPersonBu BussinessPerson { get; }
        private ICourseBu BussinessCourse { get; }
        public TireloController() {
        }
        public TireloController(IRoleBu roleBu, IPersonBu personBu, ICourseBu courseBu) {
            BusinessRole = roleBu;
            BussinessPerson = personBu;
            BussinessCourse = courseBu;
        }

        [HttpPost]
        [Route("api/role")]
        public IHttpActionResult Role([FromBody] Role role) {
            if (!ModelState.IsValid) {
                return BadRequest("Invalid Request");
            }
            return Ok(BusinessRole.UpsertRole(role));
        }

        [HttpGet]
        [Route("api/getRoles")]
        public IHttpActionResult GetRoles() {
            return Ok(BusinessRole.GetRoles());
        }

        [HttpPost]
        [Route("api/person")]
        public IHttpActionResult Person([FromBody] Person person) {
            if (!ModelState.IsValid) {
                return BadRequest("Invalid Request");
            }
            return Ok(BussinessPerson.UpsertPerson(person));
        }

        [HttpPost]
        [Route("api/course")]
        public IHttpActionResult Course([FromBody] Course course) {
            if (!ModelState.IsValid) {
                return BadRequest("Invalid Request");
            }
            return Ok(BussinessCourse.UpsertCourse(course));
        }

        [HttpPost]
        [Route("api/personcourse")]
        public Response PersonCourse([FromBody] PersonCourse personCourse) {
            return BussinessCourse.UpsertPersonCourse(personCourse);
        }



        [HttpGet]
        [Route("api/getpersoncourse")]
        public IHttpActionResult GetPersonCourse(string id) {
            return Ok(BussinessCourse.GetPersonCourses(Guid.Parse(id)));
        }

        [HttpPost]
        [Route("api/deleteperson")]
        public OkNegotiatedContentResult<Response> DeletePerson(string id)
        {
            return Ok(BussinessCourse.DeletePerson(id));
        }
        [HttpPost]
        [Route("api/deletepersoncourse")]
        public IHttpActionResult DeletePersonCourse(string[] ids) {
            return Ok(BussinessCourse.DeletePersonCourses(ids));
        }

        [HttpGet]
        [Route("api/getCourses")]
        public IHttpActionResult GetCourses() {
            return Ok(BussinessCourse.GetCourses());
        }

        [HttpGet]
        [Route("api/getCourse")]
        public IHttpActionResult GetCourse(string id) {
            return Ok(BussinessCourse.GetCourse(Guid.Parse(id)));
        }

        [HttpGet]
        [Route("api/getPeople")]
        public IHttpActionResult GetPeople() {
            return Ok(BussinessPerson.GetPeople());
        }

        [HttpGet]
        [Route("api/getPerson")]
        public IHttpActionResult GetPerson(string id) {
            return Ok(BussinessPerson.GetPerson(Guid.Parse(id)));
        }

        [HttpGet]
        [Route("api/getRole")]
        public IHttpActionResult GetRole(string id) {
            return Ok(BusinessRole.GetRole(Guid.Parse(id)));
        }
    }
}
