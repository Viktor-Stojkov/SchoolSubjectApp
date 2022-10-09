using Microsoft.EntityFrameworkCore;
using Subject.BussinesLayout.Data;
using Subject.BussinesLayout.Interfaces;
using Subject.Domain.SchoolSubjectModel;

namespace Subject.BussinesLayout.Services
{
    /// <summary>
    /// This service is used for professors actions and implements the methods from interface IProfessorRepository
    /// </summary>
    public class ProfessorServices : IProfessorRepository
    {

        /// <summary>
        /// This is the database context for accessing the data base
        /// </summary>
        private readonly SchoolSubjectContext _context;
        public ProfessorServices(SchoolSubjectContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method is used to get all the professors from database and i use async method for improving the performance 
        /// </summary>
        /// <returns>List of professors</returns>
        /// <exception cref="ArgumentException">This exception is thrown in case the list after fetch from db is null</exception>
        /// <exception cref="Exception">Throw exception if something failed in try block and chatched as exception</exception>
        public async Task<IEnumerable<Professors>> GetAllProfesorssAsync()
        {
            try
            {
                IEnumerable<Professors> professors = await _context.Professors.ToListAsync();
                if (professors == null)
                {
                    throw new ArgumentException(nameof(professors));
                }
                return professors;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This method is used to get professor by by specific id and i use async method for improving the performance 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Professor by specifically id</returns>
        /// <exception cref="ArgumentException">This exception is thrown in case the list after fetch from db is null</exception>
        /// <exception cref="Exception">Throw exception if something failed in try block and chatched as exception</exception>
        public async Task<Professors> GetProfesorByIdAsync(int? id)
        {
            try
            {
                Professors getProfessorById = await _context.Professors.SingleOrDefaultAsync(x => x.Id == id);
                if (getProfessorById == null)
                {
                    throw new ArgumentException(nameof(getProfessorById));
                }
                return getProfessorById;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This method is used for getting a list of professors for some specific subject and i use async method for improving the performance 
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns>List of professors</returns>
        /// <exception cref="ArgumentException">This exception is thrown in case the list after fetch from db is null</exception>
        /// <exception cref="Exception">Throw exception if something failed in try block and chatched as exception</exception>
        public async Task<IEnumerable<Professors>> GetProfesorsBySubjectId(int? subjectId)
        {
            try
            {

            IEnumerable<Professors> getProfessorsBySubject = await _context.SubjectProfesors
                                                                                .Include(x => x.Professor)
                                                                                .Where(x => x.SubjectId == subjectId)
                                                                                .Select(x => x.Professor)
                                                                                .ToListAsync();

            if(getProfessorsBySubject == null)
            {
                throw new ArgumentException(nameof(getProfessorsBySubject));
            }

            return getProfessorsBySubject;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
