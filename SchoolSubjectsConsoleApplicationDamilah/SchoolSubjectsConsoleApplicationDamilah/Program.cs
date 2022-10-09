using Subject.BussinesLayout.Data;
using Subject.BussinesLayout.Services;

//Loop the app while 'no' typed
while (true)
{
    // Create instance from context for accesing Db
    SchoolSubjectContext _context = new SchoolSubjectContext();

    // Create instance from SchoolSubjectServices for accessing methods
    SchoolSubjectServices schoolSubjectServices = new SchoolSubjectServices(_context);

    // Get all subjects
    var getAllSubject = await schoolSubjectServices.GetAllSubjectsAsync();

    Console.WriteLine("\nPlease select one subject to see the descsription.\n");

    //printing every subject with id and name
    foreach (var subject in getAllSubject)
    {
        Console.WriteLine(subject.Id + ". " + subject.SubjectName + "\n");
    }

    //parse user's choice to integer
    var findSubjectId = Console.ReadLine();
    var IsCharOrText = int.TryParse(findSubjectId, out int isNumericString);

    //if not id selected, print message
    if (!IsCharOrText)
    {
        Console.WriteLine("\nPlease select the Subject number!");
        continue;
    }

    else
    {
        int subjectId = Int32.Parse(findSubjectId);

        //if the user's choice is not one of the list of subjects, print message
        if (!getAllSubject.Any(x => x.Id == subjectId))
        {
            Console.WriteLine("\nPlease, select a Subject from the list above.");
            continue;
        }

        // get subject by id
        var subject = await schoolSubjectServices.GetByIdAsync(subjectId);

        Console.WriteLine($"\nYour choice: {subject.Id}. {subject.SubjectName} subject\n");

        //asking the user if he likes to see more details for choosen subject
        Console.WriteLine($"Do you like to see details for {subject.SubjectName} subject? Y or N?");
        string details = Console.ReadLine().ToLower();

        //if yes
        if (details == "y")
        {
            //print subject details
            Console.WriteLine($"Number of Weekly Classes: {subject.NumberOfWeeklyClasses}");
            Console.WriteLine($"Description: {subject.Description}");

            // Create instance from LiteratureServices for accessing methods
            LiteratureServices literatureServices = new LiteratureServices(_context);

            //get literatuses by school subject id
            var listOfLiteratures = await literatureServices.GetLiteratureByIdAsync(subjectId);

            //if any literatures exists
            if (listOfLiteratures.Any())
            {

                Console.WriteLine("\nLiteratures:\n");

                int counter = 0;

                //print every literature
                foreach (var literature in listOfLiteratures)
                {
                    counter++;
                    Console.WriteLine($"{counter}. {literature.LiteratureName} by {literature.AuthorName}");
                }
            }

            // Create instance from ProfessorServices for accessing methods
            ProfessorServices professorServices = new ProfessorServices(_context);

            // get list of professors by subject
            var professorsBySubject = await professorServices.GetProfesorsBySubjectId(subjectId);

            //if any professors exist
            if (professorsBySubject.Any())
            {
                Console.WriteLine("\nProfessors:\n");

                //print each professor details
                foreach (var professor in professorsBySubject)
                {
                    Console.WriteLine($"Name: {professor.FirstName} {professor.LastName}");
                    Console.WriteLine($"Years of expirience: {professor.YearsOfExpirience} years");
                    Console.WriteLine($"Description: {professor.ProfessorDescription}\n");
                }
            }
        }

        // Closing the app if no selected
        Console.WriteLine("\nIf you like to see another subject type any case but if you doesnt like type NO.");
        string tryAgain = Console.ReadLine().ToLower();
        if (tryAgain == "no")
        {
            break;
        }
    }
}