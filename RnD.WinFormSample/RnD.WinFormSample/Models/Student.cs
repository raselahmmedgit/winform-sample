using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RnD.WinFormSample.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentAddress { get; set; }
        public string StudentMobile { get; set; }
        public string StudentEmail { get; set; }
        public int BatchId { get; set; }
        public int SubjectId { get; set; }
    }
}
