using Subject.Domain.SchoolSubjectModel;

namespace Subject.BussinesLayout.Interfaces
{
    /// <summary>
    /// This is public interface for Literature
    /// </summary>
    public interface ILiteratureRepository
    {
        /// <summary>
        /// This method is used to get literature by school subjet id
        /// </summary>
        /// <param name="id">school subject id</param>
        /// <returns>literature object</returns>
        Task<IEnumerable<Literature>> GetLiteratureByIdAsync(int? id);
    }
}
