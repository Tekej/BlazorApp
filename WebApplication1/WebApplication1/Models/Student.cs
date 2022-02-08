using System;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.Models
{
    public class Student
    {
        public string Avatars { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Studies { get; set; }
        public DateTime Birthdate { get; set; }

        public string Index { get; set; }

        public override string ToString()
        {
            return Avatars + "," + FirstName + "," + LastName + "," + Studies + "," + Birthdate + "," + Index + "\n";
        }
    }
}
