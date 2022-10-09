using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subject.Domain.SchoolSubjectModel
{
    public class SubjectProfesors
    {
        public int Id { get; set; }
        public int ProfessorId { get; set; }
        public int SubjectId { get; set; }
        public Professors Professor { get; set; }
        public SchoolSubject Subject { get; set; }
    }
}
