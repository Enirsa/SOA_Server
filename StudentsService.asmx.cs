﻿using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml.Serialization;

using SOA_Server.Models;

namespace SOA_Server
{
    [ScriptService]
    [WebService(Namespace = "http://gorkavchuk.me/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class StudentsService : System.Web.Services.WebService
    {
        const string STUDENTS_PATH = "~/students.xml";

        [WebMethod]
        public Student[] GetAllStudents()
        {
            return LoadStudents();
        }

        [WebMethod]
        public Student[] GetStudentsByAverageMark(float minMark, float maxMark)
        {
            return LoadStudents().Where(s =>
                s.AverageMark >= minMark
                && s.AverageMark <= maxMark
            ).ToArray();
        }

        private Student[] LoadStudents()
        {
            var path = HostingEnvironment.MapPath(STUDENTS_PATH);
            var formatter = new XmlSerializer(typeof(Student[]));

            Student[] students;
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                students = (Student[])formatter.Deserialize(fs);
            }

            return students.ToArray();
        }
    }
}
