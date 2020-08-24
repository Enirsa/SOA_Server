using System;

namespace SOA_Server.Models
{
    [Serializable]
    public class Student
    {
        public string FirstName { set; get; }

        public string LastName { set; get; }

        public float AverageMark { set; get; }
    }
}
