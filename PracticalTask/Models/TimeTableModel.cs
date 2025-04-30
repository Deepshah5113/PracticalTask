using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticalTask.Models
{
    public class TimeTableModel
    {
        public List<string> Subjects { get; set; }
        public int WorkingDays { get; set; }
        public int SubjectsPerDay { get; set; }
    }
}