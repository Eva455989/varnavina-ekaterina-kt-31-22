using System.Collections.Generic;
namespace VarnavinaEkaterinaKt_31_22.Models
{
    public class AcademicGroup
    {
        public int AcademicGroupId { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
