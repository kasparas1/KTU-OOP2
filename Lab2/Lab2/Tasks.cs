using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    public class Tasks
    {
        public static List<string> FindLecturerWithMostModules(ModuleList modules)
        {
            Dictionary<string, int> ModuleInfo = new Dictionary<string, int>();
            foreach (ModuleInfo module in modules)
            {
                if (!ModuleInfo.ContainsKey(module.LecturerLName))
                {
                    ModuleInfo.Add(module.LecturerLName, module.Credits);
                }
                else
                {
                    ModuleInfo[module.LecturerLName] += module.Credits;
                }
            }

            List<string> LWMM = new List<string>();
            int LWMMCount = 0;
            foreach (string module in ModuleInfo.Keys)
            {
                int count = ModuleInfo[module];
                if (count > LWMMCount)
                {
                    LWMMCount = count;
                    LWMM = new List<string> { module };
                }
                else if (count == LWMMCount)
                {
                    LWMM.Add(module);
                }
            }

            return LWMM;
        }
        public static ModuleList FilterModulesByLector(ModuleList Modules)
        {
            ModuleList SelectedModules = new ModuleList();
            List<string> Module = FindLecturerWithMostModules(Modules);
            foreach (string module in Module)
            {
                foreach (ModuleInfo modules in Modules)
                    if (module.Contains(modules.LecturerLName))
                        SelectedModules.AddToEnd(new ModuleInfo(modules.ModuleName, modules.Credits));
            }
            return SelectedModules;
        }
        public static StudentList IfModuleIsSelectedByStudents(ModuleList Modules, StudentList Students)
        {
            string NotSame = " ";
            StudentList StudentsWhoDidintChoose = new StudentList();
            foreach (var student in Students)
                foreach (var module in Tasks.FilterModulesByLector(Modules))
                    if (module.ModuleName == student.Module && NotSame != student.Group)
                    {
                        NotSame = student.Group;
                        StudentsWhoDidintChoose.AddToEnd(new StudentM(student.Group));
                    }
            return StudentsWhoDidintChoose;
        }
        public static StudentList StudentsWithSpecificModule(string Module, StudentList Students)
        {
            StudentList SpecStudentList = new StudentList();
            foreach (StudentM student in Students)
                if (Module == student.Module)
                    SpecStudentList.AddToEnd(student);
            return SpecStudentList;
        }
    }
}