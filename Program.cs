using Microsoft.EntityFrameworkCore;
using SchoolSystem_Labb3.Models;
using System.Data.Entity;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new SchoolsystemContext())
        {
            // Skapa en bool-variabel för att styra loopen
            bool showMenu = true;

            // Loopa så länge showMenu är true
            while (showMenu)
            {
                // Anropa showMenu-metoden och tilldela resultatet till showMenu
                showMenu = ShowMenu(context);
            }
        }
        static bool ShowMenu(SchoolsystemContext context)
        {
            // Rensa konsolen
            Console.Clear();

            // Skriv ut menyalternativen
            Console.WriteLine("Choose a option:");
            Console.WriteLine("1) Get all staffs");
            Console.WriteLine("2) Get all students");
            Console.WriteLine("3) Get all student in a special class");  
            Console.WriteLine("4) Get all grades in the last month");      
            Console.WriteLine("5) Get a list with all courses and the AverageGrade");   
            Console.WriteLine("6) Add new students");
            Console.WriteLine("7) Add new staffs");
            Console.WriteLine("8) Exit");

            // Läs in användarens val
            string choise = Console.ReadLine();

            // Använd en switch-sats för att avgöra vilken metod som ska anropas
            switch (choise)
            {
                case "1":
                    // Anropa metoden för att hämta personal
                    GetStaff(context);
                    // Returnera true för att fortsätta loopen
                    return true;
                case "2":
                    // Anropa metoden för att hämta alla elever
                    GetStudents(context);
                    // Returnera true för att fortsätta loopen
                    return true;
                case "3":
                    // Anropa metoden för att hämta alla elever i en viss klass
                    GetStudentsInAClass(context);
                    // Returnera true för att fortsätta loopen
                    return true;
                case "4":
                    // Anropa metoden för att hämta alla betyg som satts den senaste månaden
                    GetAllGradesInThisMonth(context);
                    // Returnera true för att fortsätta loopen
                    return true;
                case "5":
                    // Anropa metoden för att hämta en lista med alla kurser och det snittbetyg som eleverna fått på den kursen samt det högsta och lägsta betyget som någon fått i kursen
                    GetAListWithGradesAndCourses(context);
                    // Returnera true för att fortsätta loopen
                    return true;
                case "6":
                    // Anropa metoden för att lägga till nya elever
                    AddNewStudent(context);
                    // Returnera true för att fortsätta loopen
                    return true;
                case "7":
                    // Anropa metoden för att lägga till ny personal
                    AddNewStaff(context);
                    // Returnera true för att fortsätta loopen
                    return true;
                case "8":
                    // Returnera false för att avsluta loopen och programmet
                    return false;
                default:
                    // Returnera true för att fortsätta loopen om användaren matar in ett ogiltigt val
                    return true;
            }
        }

    }

    static void GetStaff(SchoolsystemContext context)
    {
        Console.Clear();
        // Skriv ut ett meddelande till användaren
        Console.WriteLine("Do you wanna see all staffs or just in one catagory?");

        // Skriv ut kategorierna
        Console.WriteLine("1) All");
        Console.WriteLine("2) Teacher");
        Console.WriteLine("3) Administrator");
        Console.WriteLine("4) Janitor");
        Console.WriteLine("5) Cleaner");
        Console.WriteLine("6) Principal");

        // Läs in användarens val
        string choise = Console.ReadLine();

        // Deklarera en lista med personalobjekt
        List<Staff> Staffs;

        // Använd en switch-sats för att avgöra vilken fråga som ska utföras
        switch (choise)
        {
            case "1":
                // Hämta alla anställda från databasen
                Staffs = context.Staff.ToList();
                break;
            case "2":
                // Hämta alla anställda som har positionen "Lärare"
                Staffs = context.Staff.Where(s => s.Position == "Techer").ToList();
                break;
            case "3":
                // Hämta alla anställda som har positionen "Administratör"
                Staffs = context.Staff.Where(s => s.Position == "Administrator").ToList();
                break;
            case "4":
                // Hämta alla anställda som har positionen "Vaktmästare"
                Staffs = context.Staff.Where(s => s.Position == "Janitor").ToList();
                break;
            case "5":
                Staffs = context.Staff.Where(s => s.Position == "Cleaner").ToList();
                break;
            case "6":
                Staffs = context.Staff.Where(s => s.Position == "Principal").ToList();
                break;
            default:
                // Hämta en tom lista om användaren matar in ett ogiltigt val
                Staffs = new List<Staff>();
                break;
        }
        // Skriv ut antalet anställda som hämtades
        Console.WriteLine($"Got {Staffs.Count} staffs.");
        Console.ReadKey();

        // Loopa igenom listan och skriv ut varje anställds information
        foreach (var p in Staffs)
        {
            Console.WriteLine($"Id: {p.StaffId}, Name: {p.FirstName} {p.LastName}, Position: {p.Position}");
        }

        // Vänta på att användaren trycker på en tangent innan du återgår till menyn
        Console.WriteLine("Press any key to return to the menu.");       
        Console.ReadKey();
    }  
    static void GetStudents(SchoolsystemContext context)
    {
        Console.Clear();
        // Skriv ut ett meddelande till användaren
        Console.WriteLine("Do you want to sort students by first or last name??");

        // Skriv ut alternativen
        Console.WriteLine("1) Firstname");
        Console.WriteLine("2) Lastname");

        // Läs in användarens val
        string choise = Console.ReadLine();

        // Deklarera en lista med elev
        List<Student> students;

        // Använd en switch-sats för att avgöra vilken fråga som ska utföras
        switch (choise)
        {
            case "1":
                Console.Clear();
                // Skriv ut ett meddelande till användaren
                Console.WriteLine("Do you want to sort the students in rising or falling order?");

                // Skriv ut alternativen
                Console.WriteLine("1) Rising");
                Console.WriteLine("2) Falling");

                // Läs in användarens val
                string choise2 = Console.ReadLine();

                // Använd en switch-sats för att avgöra vilken sortering som ska användas
                switch (choise2)
                {
                    case "1":
                        // Hämta alla elever från databasen och sortera dem efter förnamn i stigande ordning
                        students = context.Students.OrderBy(s => s.FirstName).ToList();
                        break;
                    case "2":
                        // Hämta alla elever från databasen och sortera dem efter förnamn i fallande ordning
                        students = context.Students.OrderByDescending(s => s.FirstName).ToList();
                        break;
                    default:
                        // Hämta en tom lista om användaren matar in ett ogiltigt val
                        students = new List<Student>();
                        break;
                }
                break;
            case "2":
                Console.Clear();
                // Skriv ut ett meddelande till användaren
                Console.WriteLine("Do you want to sort the students in rising or falling order?");

                // Skriv ut alternativen
                Console.WriteLine("1) Rising");
                Console.WriteLine("2) Falling");

                // Läs in användarens val
                string choise3 = Console.ReadLine();

                // Använd en switch-sats för att avgöra vilken sortering som ska användas
                switch (choise3)
                {
                    case "1":
                        // Hämta alla elever från databasen och sortera dem efter efternamn i stigande ordning
                        students = context.Students.OrderBy(s => s.LastName).ToList();
                        break;
                    case "2":
                        // Hämta alla elever från databasen och sortera dem efter efternamn i fallande ordning
                        students = context.Students.OrderByDescending(s => s.LastName).ToList();
                        break;
                    default:
                        // Hämta en tom lista om användaren matar in ett ogiltigt val
                        students = new List<Student>();
                        break;
                }
                break;
            default:
                // Hämta en tom lista om användaren matar in ett ogiltigt val
                students = new List<Student>();
                break;
        }

        // Skriv ut antalet elever som hämtades
        Console.WriteLine($"Got {students.Count} students.");
        Console.ReadKey();

        // Loopa igenom listan och skriv ut varje elevs information
        foreach (var e in students)
        {
            Console.WriteLine($"Id: {e.StudentID}, Name: {e.FirstName} {e.LastName}, class: {e.FkclassId}");
        }
        // Vänta på att användaren trycker på en tangent innan du återgår till menyn
        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }

    static void GetStudentsInAClass(SchoolsystemContext context)
    {
        Console.Clear();
        // Skriv ut ett meddelande till användaren
        Console.WriteLine("Which class do you want to see students in?");

        // Hämta alla klasser från databasen och lagra dem i en lista
        var classes = context.Classes.ToList();

        // Loopa igenom listan och skriv ut varje klassens namn och id
        foreach (var k in classes)
        {
            Console.WriteLine($"{k.ClassId}) {k.ClassName}");
        }

        // Läs in användarens val
        string choise = Console.ReadLine();

        // Konvertera användarens val till ett heltal
        int classId = int.Parse(choise);

        // Hämta den valda klassen från databasen
        var chosenClass = context.Classes.Single(c => c.ClassId == classId);

        // Ladda klassens elever från databasen med Load-metoden
        context.Entry(chosenClass).Collection(c => c.Students).Load();

        // Skriv ut klassens namn
        Console.WriteLine($"Student in the chosen class: {chosenClass.ClassName}:");

        // Skriv ut antalet elever som laddades
        Console.WriteLine($"Loaded {chosenClass.Students.Count} students.");

        // Loopa igenom klassens elever och skriv ut varje elevs information
        foreach (var e in chosenClass.Students)
        {
            Console.WriteLine($"Id: {e.StudentID}, Name: {e.FirstName} {e.LastName}");
        }

        // Vänta på att användaren trycker på en tangent innan du återgår till menyn
        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }

    static void GetAllGradesInThisMonth(SchoolsystemContext context)
    {
        Console.Clear();
        Console.WriteLine("Here are all the grades set in the last month:");
        var students = context.Students.ToList();
        var courses = context.Courses.ToList();
        var grades = new List<Grade>();
        foreach (var e in students)
        {
            var latestGrade = context.Grades.Where(g => g.FkstudentId == e.StudentID && g.Dates > DateTime.Now.AddMonths(-1)).ToList();
            grades.AddRange(latestGrade);
        }
        Console.WriteLine($"got {grades.Count} grades");
        foreach (var s in students)
        {
            foreach (var b in grades)
            {
               foreach (var c in courses)
                {
                    if (b.FkstudentId == s.StudentID && b.FkcourseId == c.CourseId)
                    {
                        Console.WriteLine($"Student: {s.FirstName} {s.LastName}, Course: {c.CourseName}, Grade: {b.Grade1}, Date: {b.Dates.ToShortDateString()}");
                    }
                }
            }
        }

        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }
    static void GetAListWithGradesAndCourses(SchoolsystemContext context)
    {
        Console.Clear();
        var gradeMap = new Dictionary<string, int>
{
    {"A", 5},
    {"B", 4},
    {"C", 3},
    {"D", 2},
    {"E", 1},
    {"F", 0}
};

        // Skriv ut ett meddelande till användaren
        Console.WriteLine("Here is a list of all the courses and the average grade that students received on that course as well as the highest and lowest grade that someone received in the course:");

        // Hämta alla kurser från databasen och lagra dem i en lista
        var courses = context.Courses.ToList();

        // Loopa igenom listan och beräkna de olika värdena för varje kurs
        foreach (var k in courses)
        {
            // Hämta alla betyg som hör till kursen och lagra dem i en lista
            var grades = context.Grades.Where(g => g.FkcourseId == k.CourseId).ToList();

            // Beräkna snittbetyget, det högsta betyget och det lägsta betyget för kursen
            // Använd gradeMap för att konvertera betygen från bokstäver till siffror
            var average = grades.Average(g => gradeMap[g.Grade1]);
            var max = grades.Max(g => gradeMap[g.Grade1]);
            var min = grades.Min(g => gradeMap[g.Grade1]);

            // Skriv ut kursens information och de beräknade värdena
            Console.WriteLine($"course: {k.CourseName}, Averagegrade: {average}, Maxgrades: {max}, mingrades: {min}");
        }

        // Vänta på att användaren trycker på en tangent innan du återgår till menyn
        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }
    
       
     static void AddNewStudent(SchoolsystemContext context)
        {
        Console.Clear();
        // Skriv ut ett meddelande till användaren
        Console.WriteLine("Enter information about a new student:");
             Console.Write("StudentID: (100>1000) ");
             int studentID = int.Parse(Console.ReadLine());

             // Läs in elevens förnamn
             Console.Write("Firstname: ");
            string firstname = Console.ReadLine();

            // Läs in elevens efternamn
            Console.Write("Lastname: ");
            string lastname = Console.ReadLine();

            // Läs in elevens klassid
            Console.Write("Classid: ");
            int classid = int.Parse(Console.ReadLine());
           
            // Skapa ett nytt elevobjekt med de inmatade uppgifterna
        var student = new Student
            {
                StudentID = studentID,
                FirstName = firstname,
                LastName = lastname,
                FkclassId = classid
            };

            // Lägg till det nya elevobjektet till kontexten
            context.Students.Add(student);

        // Spara ändringarna till databasen
        context.SaveChanges();
        Console.WriteLine($"Add {student.StudentID} {student.FirstName} {student.LastName} to {student.FkclassId} in database.");
        Console.ReadKey();


    }

    static void AddNewStaff(SchoolsystemContext context)
    {
        Console.Clear();
            // Skriv ut ett meddelande till användaren
            Console.WriteLine("Enter the details of a new employee:");
        Console.WriteLine("StaffID: (100>1000)");
        int staffID = int.Parse(Console.ReadLine());

        // Läs in den anställdes förnamn
        Console.Write("Firstname: ");
        string firstname = Console.ReadLine();

        // Läs in den anställdes efternamn
        Console.Write("Lastname: ");
        string lastname = Console.ReadLine();

        // Läs in den anställdes position
        Console.Write("Position: ");
        string position = Console.ReadLine();

        // Skapa ett nytt personalobjekt med de inmatade uppgifterna
        var staff = new Staff
        {
            StaffId = staffID,
            FirstName = firstname,
            LastName = lastname,
            Position = position
        };

        // Lägg till det nya personalobjektet till kontexten
        context.Staff.Add(staff);

        // Spara ändringarna till databasen
        context.SaveChanges();

        // Skriv ut ett bekräftelsemeddelande till användaren
        Console.WriteLine($"Add {staff.StaffId} {staff.FirstName} {staff.LastName} to {staff.Position} in database.");
        Console.ReadKey();
    }

}
