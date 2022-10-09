using Subject.Domain.SchoolSubjectModel;

namespace Subject.BussinesLayout.Interfaces
{
    /// <summary>
    /// This is public interface for school subject
    /// </summary>
    public interface ISchoolSubjectRepository
    {
        /// <summary>
        /// This method is used to get all the school subject from database asynchronously
        /// </summary>
        /// <returns>List of school subject object</returns>
        Task<IEnumerable<SchoolSubject>> GetAllSubjectsAsync();

        /// <summary>
        /// This method is used to get subject by id
        /// </summary>
        /// <param name="id">school subject id</param>
        /// <returns>school subject object</returns>
        Task<SchoolSubject> GetByIdAsync(int? id);
    }
}
