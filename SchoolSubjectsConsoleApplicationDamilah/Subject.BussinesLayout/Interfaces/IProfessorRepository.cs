using Subject.Domain.SchoolSubjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subject.BussinesLayout.Interfaces
{
    /// <summary>
    /// This is public interface for Professor
    /// </summary>
    public interface IProfessorRepository
    {
        /// <summary>
        /// This method is used to get all the professor from database asynchronously
        /// </summary>
        /// <returns>List of school professor object</returns>
        Task<IEnumerable<Professors>> GetAllProfesorssAsync();

        /// <summary>
        /// This method is used to get professor by id
        /// </summary>
        /// <param name="id">professor id</param>
        /// <returns>professor object</returns>
        Task<Professors> GetProfesorByIdAsync(int? subjectId);

        /// <summary>
        /// This method is used to get all professors for specific subject
        /// </summary>
        /// <param name="id">school subject id</param>
        /// <returns>list of professors object</returns>
        Task<IEnumerable<Professors>> GetProfesorsBySubjectId(int? id);
    }
}
