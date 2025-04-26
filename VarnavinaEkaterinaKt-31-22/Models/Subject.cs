namespace VarnavinaEkaterinaKt_31_22.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public List<Performance> Performances { get; set; } = new List<Performance>();
    }
}
