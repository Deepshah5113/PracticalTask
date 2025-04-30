using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticalTask.Models
{
    public class SubjectHoursModel
    {
        public List<SubjectHour> SubjectHours { get; set; }
        public int TotalHours { get; set; }
    }

    public class SubjectHour
    {
        public string SubjectName { get; set; }
        public int Hours { get; set; }
    }
}