﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {
    public class Course {

        public Guid? Id { get; set; }
        public string Name { get; set; }
        public int? ValidPeriod { get; set; }
    }
}