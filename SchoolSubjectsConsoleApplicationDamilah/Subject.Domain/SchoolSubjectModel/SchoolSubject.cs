namespace Subject.Domain.SchoolSubjectModel
{
    /// <summary>
    /// This is 
    /// </summary>
    public class SchoolSubject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public int? NumberOfWeeklyClasses { get; set; }
        public IEnumerable<Literature> Literature { get; set; }
        public IEnumerable<SubjectProfesors> SubjectProfesors { get; set; }
    }
}
