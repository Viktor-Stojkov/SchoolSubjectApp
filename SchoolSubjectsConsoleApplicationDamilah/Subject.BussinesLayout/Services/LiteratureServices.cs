using Microsoft.EntityFrameworkCore;
using Subject.BussinesLayout.Data;
using Subject.BussinesLayout.Interfaces;
using Subject.Domain.SchoolSubjectModel;

namespace Subject.BussinesLayout.Services
{
    /// <summary>
    /// This service is used for literature actions and implements the methods from interface ILiteratureRepository
    /// </summary>
    public class LiteratureServices : ILiteratureRepository
    {
        /// <summary>
        /// This is the database context for accessing the data base
        /// </summary>
        private readonly SchoolSubjectContext _context;

        public LiteratureServices(SchoolSubjectContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This function is about getting the list of literatures for specific school subject by specific id and i use async method for improving the performance 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of literatures by specifically id</returns>
        /// <exception cref="ArgumentException">This exception is thrown in case the list after fetch from db is null</exception>
        /// <exception cref="Exception">Throw exception if something failed in try block and chatched as exception</exception>
        public async Task<IEnumerable<Literature>> GetLiteratureByIdAsync(int? id)
        {
            try
            {
                IEnumerable<Literature> literature = await _context.Literature.Where(x => x.SchoolSubjectId == id).ToListAsync();
                if (literature == null)
                {
                    throw new ArgumentException(nameof(literature));
                }
                return literature;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
