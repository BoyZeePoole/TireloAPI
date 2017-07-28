using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {
    public class Response {
        public bool Success { get; set; }
        public bool Updated { get; set; }
        public List<Errors> Errors { get; set; }
    }
}
