using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.interfaces {
    public interface ICourse {
        Response UpsertCourse(ServiceLayer.Course course);
        IEnumerable<Course> GetCourse();

        ServiceLayer.Course GetCourse(Guid id);

        void Save();
    }
}
