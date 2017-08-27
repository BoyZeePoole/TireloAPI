using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Person{

        public Guid? Id { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string Email { get; set; }
        public string CoyNumber { get; set; }
        public Role Role { get; set; }
        public Person Manager { get; set; }
        public Section Section { get; set; }
        public Occupation Occupation { get; set; }
    }
}
