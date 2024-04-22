namespace Lab4Web.Services.Linq
{
    public class Student
    {
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    // 3 a
    public class Teacher
    {
        public Teacher(string name, int age, int yearsOfExperience, string subject, int students)
        {
            Name = name;
            Age = age;
            YearsOfExperience = yearsOfExperience;
            Subject = subject;
            Students = students;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int YearsOfExperience { get; set; }
        public string Subject { get; set; }
        public int Students { get; set; }
    }

    // 3 b
    public static class SchoolTeachers
    {
        public static List<Teacher> Teachers { get; private set; }

        static SchoolTeachers()
        {
            Teachers = new List<Teacher>
        {
            new Teacher("Crstian P", 35, 10, "Matematica", 100),
            new Teacher("Ana F", 40, 15, "Romana", 101),
            new Teacher("Maria A", 30, 5, "Engleza", 76),
            new Teacher("Vasile B", 50, 25, "Fizica", 32),
            new Teacher("Florian E", 45, 20, "Geografie", 54),
            new Teacher("Costin R", 55, 30, "Istorie", 43),
            new Teacher("Dan M", 38, 12, "Muzica", 56),
            new Teacher("Madalina A", 42, 18, "Biologie", 54),
            new Teacher("Raluca T", 28, 3, "Informatica", 76),
            new Teacher("Alexandru I", 48, 22, "Chimie", 54)
        };
        }
    }

    public class LinqService : ILinqService
    {
        public List<Student> stUdents = new List<Student>()
        {
            new Student("T1", 25),
            new Student("T2", 29),
            new Student("T3", 33),
        };

        public int Test1(int value)
        {
            //Query-expression
            //var query = from student in stUdents
            //            where student.Age >= value
            //                select student;

            //return query.Count();

            //Method-expression 
            return stUdents.Count(student => student.Age >= value);
        }

        // 3 c i
        public List<Teacher> Test2(string subject)
        {
            return SchoolTeachers.Teachers.Where(teacher => teacher.Subject == subject).ToList();
        }

        // 3 c ii
        public List<string> Test3()
        {
            var query = from teacher in SchoolTeachers.Teachers
                        select teacher.Name;

            return query.ToList();
        }

        // 3 c iii
        public int Test4()
        {
            var query = from teacher in SchoolTeachers.Teachers
                        select teacher;

            return query.Count();
        }

        // 3 d i
        public List<Teacher> Test5(string name)
        {
            var query = from teacher in SchoolTeachers.Teachers
                        where teacher.Name == name
                        select teacher;

            return query.ToList();
        }

        // 3 d ii
        public List<string> Test6()
        {
            var subjects = new List<string> { "Matematica", "Istorie", "Chimie", "Fizica" };

            var query = from teacher in SchoolTeachers.Teachers
                        join subject in subjects on teacher.Subject equals subject
                        select $"{teacher.Name} preda {subject}";

            return query.ToList();
        }

        // 3 d iii
        public Dictionary<int, List<Teacher>> Test7()
        {
            var query = from teacher in SchoolTeachers.Teachers
                        group teacher by teacher.Age into ageGroup
                        orderby ageGroup.Key
                        select ageGroup;

            return query.ToDictionary(group => group.Key, group => group.ToList());
        }
    }
}
