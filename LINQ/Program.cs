namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student{ID=1, First= "Jane", Last = "Doe", Major = "Cyber Ops", GPA=3.75},
                new Student{ID=2, First= "Johh", Last = "Doe", Major = "Computer Science", GPA=2.81},
                new Student{ID=3, First= "Kevin", Last = "Spacey", Major = "Finance", GPA=4},
                new Student{ID=4, First= "Peter", Last = "Parker", Major = "Undecided", GPA=1.4}

            };

            List<Enrollemnt> enrollemnts = new List<Enrollemnt> 
            {
                new Enrollemnt{StudentID=1, Course="CSC250" },
                new Enrollemnt{StudentID=2, Course="CSC250" },
                new Enrollemnt{StudentID=3, Course="CSC260" },
            };

            /*
            List<Student> honorRoll = new List<Student>();
            foreach (var s in students)
            {
                if (s.GPA >= 3)
                    honorRoll.Add(s);
            }
            */

//creates a list of students that meet certain requirements specified by the where clause
//& format with select cluase
            var honorRoll = students
                .Where(s => (s.GPA >= 3))
                .Select(s => $"{s.First}: {s.GPA*2}" )
                .ToList();

            //Console.WriteLine(honorRoll.GetType());
            honorRoll.ForEach(s => Console.WriteLine(s));

            Console.WriteLine(students.Count(s => (s.GPA >= 3)));

            var result =
                from s in students
                join e in enrollemnts
                on s.ID equals e.StudentID
                select new { s.First, s.Last, e.Course };

           foreach(var r in result)
            {
                Console.WriteLine($"{r.First} {r.Last} is enrolled in {r.Course}");
            }

            var sorted = students
                 .OrderBy(s => s.Last)
                 .ThenBy(s => s.First);
              
            foreach(var s in sorted)
            {
                Console.WriteLine($"{s.Last} {s.First}");
            }
        }
    }
}
