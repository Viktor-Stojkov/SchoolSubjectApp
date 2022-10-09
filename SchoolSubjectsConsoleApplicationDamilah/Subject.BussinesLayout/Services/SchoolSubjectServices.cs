using Microsoft.EntityFrameworkCore;
using Subject.BussinesLayout.Data;
using Subject.BussinesLayout.Interfaces;
using Subject.Domain.SchoolSubjectModel;

namespace Subject.BussinesLayout.Services
{
    /// <summary>
    /// This service is used for school subject actions and implements the methods from interface ISchoolSubjectRepository
    /// </summary>
    public class SchoolSubjectServices : ISchoolSubjectRepository
    {
        /// <summary>
        /// This is the database context for accessing the data base
        /// </summary>
        private readonly SchoolSubjectContext _context;

        public SchoolSubjectServices(SchoolSubjectContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method is used to get all the School subjects from database and i use async method for improving the performance 
        /// </summary>
        /// <returns>List of school subjects</returns>
        /// <exception cref="ArgumentException">This exception is thrown in case the list after fetch from db is null</exception>
        /// <exception cref="Exception">Throw exception if something failed in try block and chatched as exception</exception>
        public async Task<IEnumerable<SchoolSubject>> GetAllSubjectsAsync()
        {
            try
            {
                IEnumerable<SchoolSubject> schoolSubjects = await _context.SchoolSubject.ToListAsync();
                if (schoolSubjects == null)
                {
                    throw new ArgumentException(nameof(schoolSubjects));
                }
                return schoolSubjects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This method is used to get subject by specific id and i use async method for improving the performance 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>School subject by specifically id</returns>
        /// <exception cref="ArgumentException">This exception is thrown in case the list after fetch from db is null</exception>
        /// <exception cref="Exception">Throw exception if something failed in try block and chatched as exception</exception>
        public async Task<SchoolSubject> GetByIdAsync(int? id)
        {
            try
            {
                SchoolSubject schoolSubject = await _context.SchoolSubject.SingleOrDefaultAsync(x => x.Id == id);
                if (schoolSubject == null)
                {
                    throw new ArgumentException(nameof(schoolSubject));
                }
                return schoolSubject;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
