using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {
    public class PersonCourse {

        public Guid? Id { get; set; }
        public Course Course { get; set; }
        public Person Employee { get; set; }
        public Person Manager { get; set; }
        public DateTime? DateCompleted { get; set; }
        public DateTime? DateExpired { get; set; }

    }
}
