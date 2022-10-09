using Microsoft.EntityFrameworkCore;
using Subject.Domain.SchoolSubjectModel;

namespace Subject.BussinesLayout.Data
{

    /// <summary>
    /// I am using database as third party to access all needed information about subjects. 
    /// Also, I am using code-first approach to generate the tables in database.
    /// Therefore, this context exposes DbSet properties that represent collections of the specified entities in the context. 
    /// </summary>
    public class SchoolSubjectContext : DbContext
    {
        // collection of school subject entity
        public DbSet<SchoolSubject> SchoolSubject { get; set; }

        // collection of literature entity
        public DbSet<Literature> Literature { get; set; }

        // collection of professor entity
        public DbSet<Professors> Professors { get; set; }

        // collection of subject professor entity and this is used for many-many relationship between professor and subject
        public DbSet<SubjectProfesors> SubjectProfesors { get; set; }


        // configuring what instance to be used for database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=VICTOR-LENOVO;Initial Catalog=SchoolSubjetsDamilah;Trusted_Connection=True;");
        }

        // configuring all entities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configuring SchoolSubject entity to create table SchoolSubject in database with primary key Id
            modelBuilder.Entity<SchoolSubject>()
                        .ToTable("SchoolSubject")
                        .HasKey(x => x.Id);

            // configuring SchoolSubject entity with one to many relationship between SchoolSubject and Literature
            // ( one SchoolSubject can have more Literature )
            modelBuilder.Entity<SchoolSubject>()
                .HasMany(x => x.Literature)
                .WithOne(x => x.SchoolSubject);

            // configuring Literature entity to create table Literature in database with primary key Id
            modelBuilder.Entity<Literature>()
                        .ToTable("Literature")
                        .HasKey(x => x.Id);

            // configuring Literature entity with many to one relationship between Literature and SchoolSubject
            // ( one Literature belongs to one SchoolSubject )
            modelBuilder.Entity<Literature>()
                        .HasOne(x => x.SchoolSubject)
                        .WithMany(x => x.Literature)
                        .HasForeignKey(x => x.SchoolSubjectId);

            // configuring Professors entity to create table Professors in database with primary key Id
            modelBuilder.Entity<Professors>()
                        .ToTable("Professors")
                        .HasKey(x => x.Id);

            // configuring SubjectProfessors entity with primary key Id
            modelBuilder.Entity<SubjectProfesors>()
                        .HasKey(x => x.Id);

            // next two configurations are for configuring SubjectProfessors entity as many to many relationship between Subject and Professor 
            // ( one Professor can teach one or more Subject and one Subject can have one or more Professors )

            modelBuilder.Entity<SubjectProfesors>()
                        .HasOne(x => x.Subject)
                        .WithMany(x => x.SubjectProfesors)
                        .HasForeignKey(x => x.SubjectId);

            modelBuilder.Entity<SubjectProfesors>()
                        .HasOne(x => x.Professor)
                        .WithMany(x => x.SubjectProfesors)
                        .HasForeignKey(x => x.ProfessorId);

            // populating the SchoolSubject entity with data
            modelBuilder.Entity<SchoolSubject>()
                        .HasData(
                new
                {
                    Id = 1,
                    SubjectName = "Math",
                    Description = "Mathematics is the science and study of quality, structure, space, and change. Mathematicians seek out patterns, formulate new conjectures, and establish truth by rigorous deduction from appropriately chosen axioms and definitions.",
                    NumberOfWeeklyClasses = 3
                },
                new
                {
                    Id = 2,
                    SubjectName = "English",
                    Description = "The subject shall help build up general language proficiency through listening,speaking,reading and writing,and provide the opportunity to acquire information and specialised knowledge through the English language.",
                    NumberOfWeeklyClasses = 3
                },
                new
                {
                    Id = 3,
                    SubjectName = "Art",
                    Description = "The term subjects in art refers to the main idea that is represented in the artwork. The subject in art is basically the essence of the piece. To determine subject matter in a particular piece of art, ask yourself: What is actually depicted in this artwork?",
                    NumberOfWeeklyClasses = 2
                },
                new
                {
                    Id = 4,
                    SubjectName = "Geography",
                    Description = "Geography is the study of places and the relationships between people and their environments. Geographers explore both the physical properties of Earth's surface and the human societies spread across it.",
                    NumberOfWeeklyClasses = 2
                },
                new
                {
                    Id = 5,
                    SubjectName = "History",
                    Description = "History is the study of life in society in the past, in all its aspect, in relation to present developments and future hopes. It is the story of man in time, an inquiry into the past based on evidence. Indeed, evidence is the raw material of history teaching and learning.",
                    NumberOfWeeklyClasses = 4

                },
                new
                {
                    Id = 6,
                    SubjectName = "Psychology",
                    Description = "This course is a study of theory and research of the normal personality including basic concepts, techniques of measurement, and relevant findings. This course surveys the major theories of personality, including trait, psychodynamic, humanistic, cognitive, and behavioral perspectives.",
                    NumberOfWeeklyClasses = 2
                }
            );

            // populating the Literature entity with data
            modelBuilder.Entity<Literature>()
                        .HasData(
                new
                {
                    Id = 1,
                    SchoolSubjectId = 1,
                    LiteratureName = "Essential Calculus Skills Practice Workbook with Full Solutions",
                    AuthorName = "Chris McMullen"
                },
                new
                {
                    Id = 2,
                    SchoolSubjectId = 1,
                    LiteratureName = "Algebra Essentials Practice Workbook with Answers: Linear & Quadratic Equations, Cross Multiplying, and Systems of Equations: Improve Your Math Fluency Series",
                    AuthorName = "Chris McMullen"
                },
                new
                {
                    Id = 3,
                    SchoolSubjectId = 2,
                    LiteratureName = "Oxford Advanced Learner’s Dictionary (OALD)",
                    AuthorName = "Oxford"
                },
                new
                {
                    Id = 4,
                    SchoolSubjectId = 3,
                    LiteratureName = "Artists’ Master Series: Color and Light",
                    AuthorName = "3dtotal Publishing"
                },
                new
                {
                    Id = 5,
                    SchoolSubjectId = 3,
                    LiteratureName = "Anatomy and Drawing (Dover Art Instruction)",
                    AuthorName = "Victor Perard"
                },
                new
                {
                    Id = 6,
                    SchoolSubjectId = 4,
                    LiteratureName = "Adriatic: A Concert of Civilizations at the End of the Modern Age",
                    AuthorName = "Robert D. Kaplan"
                },
                new
                {
                    Id = 7,
                    SchoolSubjectId = 5,
                    LiteratureName = "What Is History?",
                    AuthorName = "Edward Hallett Carr"
                },
                new
                {
                    Id = 8,
                    SchoolSubjectId = 5,
                    LiteratureName = "1491",
                    AuthorName = "Charles C. Mann"
                },
                new
                {
                    Id = 9,
                    SchoolSubjectId = 6,
                    LiteratureName = "An Ishmael of Syria (Paperback)",
                    AuthorName = "Asaad Almohammad"
                },
                new
                {
                    Id = 10,
                    SchoolSubjectId = 6,
                    LiteratureName = "The Silent Patient (Hardcover)",
                    AuthorName = "Alex Michaelides"
                }
            );

            // populating the Professors entity with data
            modelBuilder.Entity<Professors>()
                        .HasData(
                new
                {
                    Id = 1,
                    FirstName = "Johnny",
                    LastName = "Depp",
                    YearsOfExpirience = 15,
                    ProfessorDescription = "Teach one or more university subjects to undergraduate and graduate students. Prepare and deliver lectures to students and conduct laboratory sessions or discussion groups. Prepare, administer and grade examinations, laboratory assignments and reports. Advise students on course and academic matters and career decisions."
                },
                new
                {
                    Id = 2,
                    FirstName = "Jessica",
                    LastName = "Alba",
                    YearsOfExpirience = 12,
                    ProfessorDescription = "Teach one or more university subjects to undergraduate and graduate students. Prepare and deliver lectures to students and conduct laboratory sessions or discussion groups. Prepare, administer and grade examinations, laboratory assignments and reports. Advise students on course and academic matters and career decisions."
                },
                new
                {
                    Id = 3,
                    FirstName = "Angelina",
                    LastName = "Joly",
                    YearsOfExpirience = 30,
                    ProfessorDescription = "Teach one or more university subjects to undergraduate and graduate students. Prepare and deliver lectures to students and conduct laboratory sessions or discussion groups. Prepare, administer and grade examinations, laboratory assignments and reports. Advise students on course and academic matters and career decisions."
                },
                new
                {
                    Id = 4,
                    FirstName = "Luise",
                    LastName = "Armstrong",
                    YearsOfExpirience = 24,
                    ProfessorDescription = "Teach one or more university subjects to undergraduate and graduate students. Prepare and deliver lectures to students and conduct laboratory sessions or discussion groups. Prepare, administer and grade examinations, laboratory assignments and reports. Advise students on course and academic matters and career decisions."
                },
                new
                {
                    Id = 5,
                    FirstName = "Tony",
                    LastName = "Montana",
                    YearsOfExpirience = 32,
                    ProfessorDescription = "Teach one or more university subjects to undergraduate and graduate students. Prepare and deliver lectures to students and conduct laboratory sessions or discussion groups. Prepare, administer and grade examinations, laboratory assignments and reports. Advise students on course and academic matters and career decisions."
                },
                new
                {
                    Id = 6,
                    FirstName = "Tonny",
                    LastName = "Stark",
                    YearsOfExpirience = 15,
                    ProfessorDescription = "Teach one or more university subjects to undergraduate and graduate students. Prepare and deliver lectures to students and conduct laboratory sessions or discussion groups. Prepare, administer and grade examinations, laboratory assignments and reports. Advise students on course and academic matters and career decisions."
                }
            );

            // populating the SubjectProfessors entity with data
            modelBuilder.Entity<SubjectProfesors>()
                        .HasData(
                new
                {
                    Id = 1,
                    ProfessorId = 1,
                    SubjectId = 1
                },
                new
                {
                    Id = 2,
                    ProfessorId = 2,
                    SubjectId = 2
                },
                new
                {
                    Id = 3,
                    ProfessorId = 3,
                    SubjectId = 3
                },
                new
                {
                    Id = 4,
                    ProfessorId = 6,
                    SubjectId = 4
                },
                new
                {
                    Id = 5,
                    ProfessorId = 6,
                    SubjectId = 5
                },
                new
                {
                    Id = 6,
                    ProfessorId = 5,
                    SubjectId = 6
                },
                new
                {
                    Id = 7,
                    ProfessorId = 3,
                    SubjectId = 5
                }
            );
        }
    }
}
