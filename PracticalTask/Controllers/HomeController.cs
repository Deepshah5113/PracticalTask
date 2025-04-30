using PracticalTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticalTask.Controllers
{
    public class HomeController : Controller
    {
        private static InputModel StoredInput;
        private static SubjectHoursModel StoredSubjectHours;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(InputModel model)
        {
            if (ModelState.IsValid)
            {
                StoredInput = model;
                return RedirectToAction("SubjectHours");
            }
            return View(model);
        }

        public ActionResult SubjectHours()
        {
            var model = new SubjectHoursModel
            {
                SubjectHours = new List<SubjectHour>(),
                TotalHours = StoredInput.TotalHours
            };

            for (int i = 0; i < StoredInput.TotalSubjects; i++)
            {
                model.SubjectHours.Add(new SubjectHour { SubjectName = $"Subject{i + 1}", Hours = 0 });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SubjectHours(SubjectHoursModel model)
        {
            int total = model.SubjectHours.Sum(s => s.Hours);
            if (total != StoredInput.TotalHours)
            {
                ModelState.AddModelError("", $"Total subject hours must equal {StoredInput.TotalHours}");
                return View(model);
            }

            StoredSubjectHours = model;
            return RedirectToAction("Generate");
        }

        public ActionResult Generate()
        {
            var subjects = new List<string>();
            foreach (var subject in StoredSubjectHours.SubjectHours)
            {
                for (int i = 0; i < subject.Hours; i++)
                {
                    subjects.Add(subject.SubjectName);
                }
            }

            // Shuffle the list randomly
            var rnd = new Random();
            var shuffled = subjects.OrderBy(x => rnd.Next()).ToList();

            var model = new TimeTableModel
            {
                Subjects = shuffled,
                WorkingDays = StoredInput.WorkingDays,
                SubjectsPerDay = StoredInput.SubjectsPerDay
            };

            return View(model);
        }
    }
}