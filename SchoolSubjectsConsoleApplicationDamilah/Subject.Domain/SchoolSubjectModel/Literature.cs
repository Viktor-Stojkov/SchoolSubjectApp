namespace Subject.Domain.SchoolSubjectModel
{
    public class Literature
    {
        public int Id { get; set; }
        public int? SchoolSubjectId { get; set; } // Foreign Key
        public SchoolSubject SchoolSubject { get; set; }
        public string LiteratureName { get; set; }
        public string AuthorName { get; set; }
    }
}
