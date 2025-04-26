namespace VarnavinaEkaterinaKt_31_22.Models
{
    public class Performance
    {
        public int PerformanceId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public double Grade { get; set; }
        public bool IsPassed { get; set; }
    }
}
