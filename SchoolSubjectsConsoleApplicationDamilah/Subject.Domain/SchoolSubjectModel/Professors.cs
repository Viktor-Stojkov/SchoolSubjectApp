using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subject.Domain.SchoolSubjectModel
{
    public class Professors
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? YearsOfExpirience{ get; set; }
        public string ProfessorDescription { get; set; }
        public IEnumerable<SubjectProfesors> SubjectProfesors { get; set; }
    }
}
