using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    public class ModuleInfo
    {
        public string ModuleName { get; set; }

        public string LecturerLName { get; set; }
        public string LecturerName { get; set; }
        public int Credits { get; set; }
        public ModuleInfo (string moduleName, string lecturerLname, string lecturerName, int credits)
        {
            ModuleName = moduleName;
            LecturerLName = lecturerLname;
            LecturerName = lecturerName;
            Credits = credits;
        }
        public ModuleInfo(string moduleName, int credits)
        {
            ModuleName = moduleName;
            Credits = credits;
        }
            

    }
}