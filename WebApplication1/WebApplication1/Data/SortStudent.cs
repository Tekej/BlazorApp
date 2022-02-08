using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class IndexModel : PageModel
    {
        private Student[] _students;
    
        protected async Task OnInitializedAsync()
        {
            _students = await Students.GetStudentsAsync(DateTime.Now);
        }
        public string FirstNameSort { get; set; }
        public string LastNameSort { get; set; }
        public string StudiaSort { get; set; } 
        public string BirthdateSort { get; set; }

        public IList<Student> students { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // using System;
            FirstNameSort = string.IsNullOrEmpty(sortOrder) ? "Firstname_desc" : "Firstname";
            LastNameSort = string.IsNullOrEmpty(sortOrder) ? "LastName_desc" : "LastName";
            StudiaSort = string.IsNullOrEmpty(sortOrder) ? "Studia_desc" : "Studia";
            BirthdateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IEnumerable<Student> students =  from s in _students
                select s;

            switch (sortOrder)
            {
                case "Firstname_desc":
                    students = students.OrderByDescending(s => s.FirstName);
                    break;
                case "Firstname":
                    students = students.OrderBy(s => s.FirstName);
                    break;
                case "LastName_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "LastName":
                    students = students.OrderBy(s => s.LastName);
                    break;
                case "Studia_desc":
                    students = students.OrderByDescending(s => s.Studies);
                    break;
                case "Studia":
                    students = students.OrderBy(s => s.Studies);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.Birthdate);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.Birthdate);
                    break;
            
            
            }

            students = students.ToList();
        }
    }
}