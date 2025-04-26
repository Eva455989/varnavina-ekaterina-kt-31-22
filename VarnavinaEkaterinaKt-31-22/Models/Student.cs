using System.Collections.Generic;

namespace VarnavinaEkaterinaKt_31_22.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } // Исправлено на string
        public string LastName { get; set; } // Исправлено на string
        public string MiddleName { get; set; } // Исправлено на string
        public int GroupID { get; set; }
        public AcademicGroup Group { get; set; }
        public List<Performance> Performances { get; set; } = new List<Performance>();
    }
}