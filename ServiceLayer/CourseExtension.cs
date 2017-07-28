using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer {

    public partial class Course {

        public static implicit operator ServiceLayer.Course(Domain.Course course) {
            return new Course {
                Id = Guid.NewGuid(),
                Name = course.Name,
                ValidPeriod = course.ValidPeriod
            };
        }

    }

}
