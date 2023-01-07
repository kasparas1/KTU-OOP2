using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    public class StudentM
    {
        public string Module { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public StudentM(string module, string lastName, string name, string group)
        {
            Module = module;
            LastName = lastName;
            Name = name;
            Group = group;
        }
        public StudentM(string group)
        {
            Group = group;
        }
    }
}