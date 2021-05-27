/* Lab 8
* 
* Diana Guerrero
* Professor Aydin
* BCS 426 
* 4/23/21
* 
* Partner(s): Patrick Adams
* Resource(s): 
* 1. https://drive.google.com/drive/folders/1p5jGfHa6Wqd8gfZ1u_jnposXg6bg2Ysk
* 2. https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.tolookup?view=net-5.0
* 3. https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netcore-3.1
* 4. https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2?view=netcore-3.1
* 5. https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=netcore-3.1
*/

using System;
using System.Linq;
using System.Collections.Generic;

namespace BCS426Lab8
{
    class Program
    {
        public class Student : IComparable<Student> , IEquatable<Student>
        {
            public Student(int id, string name, string year, string state)
            {
                Id = id;
                Name = name;
                Year = year;
                State = state;
            }

            public int Id
            {
                get;
                set;
            }

            public string Name
            {
                get;
            }

            public string Year
            {
                get;
            }

            public string State
            {
                get;
            }

            // Display Name of Students for 1a & 1b
            public override string ToString() => $"{Name}";

            // Compare Class
            public int CompareTo(Student other)
            {
                int result;

                result = Id.CompareTo(other.Id);

                return result;
            }

            // HashCode & Such
            public bool Equals(Student other) => Id == other.Id;

            public override bool Equals(object obj) => Equals((Student)(obj));

            public override int GetHashCode() => (Id ^ Id << 16) * 0x1505_1505;

        }
        static void Main(string[] args)
        {
            // Student Properties
            var students = new List<Student>();
            students.Add(new Student(2000, "Mike Smith", "Freshman", "NY"));
            students.Add(new Student(4444, "Alice Smith", "Sophomore", "NC"));
            students.Add(new Student(2002, "Tom Brown", "Freshman", "NY"));
            students.Add(new Student(3000, "Sarah Smith", "Senior", "NY"));
            students.Add(new Student(1001, "Samantha Green", "Junior", "MD"));
            students.Add(new Student(4004, "Diana Guerrero", "Junior", "NJ"));
            students.Add(new Student(1000, "Daniel Moore", "Freshman", "NJ"));

            // 1a. Lookup Students who are Freshman
            Console.WriteLine("1a. Students In Their Freshman Year: \n");
            var lookupYears = students.ToLookup(s => s.Year);

            foreach (Student s in lookupYears["Freshman"])
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("");

            // 1b. Lookup Students who are from NY
            Console.WriteLine("1b. Students From NY State: \n");
            var lookupStates = students.ToLookup(s => s.State);

            foreach (Student s in lookupStates["NY"])
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("");

            // Sorted Student Properties
            var sortedStudents = new SortedList<int, Student>();
            sortedStudents.Add(2000, new Student(2000, "Mike Smith", "Freshman", "NY"));
            sortedStudents.Add(4444, new Student(4444, "Alice Smith", "Sophomore", "NC"));
            sortedStudents.Add(2002, new Student(2002, "Tom Brown", "Freshman", "NY"));
            sortedStudents.Add(3000, new Student(3000, "Sarah Smith", "Senior", "NY"));
            sortedStudents.Add(1001, new Student(1001, "Samantha Green", "Junior", "MD"));
            sortedStudents.Add(4004, new Student(4004, "Diana Guerrero", "Junior", "NJ"));
            sortedStudents.Add(1000, new Student(1000, "Daniel Moore", "Freshman", "NJ"));

            // 2a. List Students Sorted by ID
            Console.WriteLine("2a. Students Sorted by ID: \n");
            //var lookupIDs = students.ToLookup(s => s.Id);

            foreach (KeyValuePair<int, Student> student in sortedStudents)
            {
                Console.WriteLine($"Key: {student.Key}, Value: {student.Value}\n");
            }

            Console.WriteLine("");

            // 2b. Ask User to Input an ID, Look It Up In the Collection, If it's Found Display ID, If not Display Error

            int userInput;
            Console.WriteLine("2b. Enter an ID: \n");
            userInput = Convert.ToInt32(Console.ReadLine());

            if (!sortedStudents.TryGetValue(userInput, out Student value))
            {
                Console.WriteLine($"{userInput} ID Not Found \n");
            }
            else
            {
                Console.WriteLine($"{userInput}, {value}");
            }

            var studentDictionary = new SortedDictionary<int, Student>();
            {
            studentDictionary.Add(2000, new Student(2000, "Mike Smith", "Freshman", "NY"));
            studentDictionary.Add(4444, new Student(4444, "Alice Smith", "Sophomore", "NC"));
            studentDictionary.Add(2002, new Student(2002, "Tom Brown", "Freshman", "NY"));
            studentDictionary.Add(3000, new Student(3000, "Sarah Smith", "Senior", "NY"));
            studentDictionary.Add(1001, new Student(1001, "Samantha Green", "Junior", "MD"));
            studentDictionary.Add(4004, new Student(4004, "Diana Guerrero", "Junior", "NJ"));
            studentDictionary.Add(1000, new Student(1000, "Daniel Moore", "Freshman", "NJ"));
            }

            Console.WriteLine("");

            // 3a. All of Student Data Sorted by ID
            Console.WriteLine("3a. Students Sorted by ID: \n");

            foreach (var student in studentDictionary.Values)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("");

            // 3b. Ask User to Input an ID, Look It Up In the Collection, If it's Found Display ID, If not Display Error
            int userInput2;
            Console.Write("3b. Enter an ID: \n");
            userInput2 = Convert.ToInt32(Console.ReadLine());

            if (!studentDictionary.TryGetValue(userInput2, out Student value2))
            {
                Console.WriteLine($"{userInput2} ID Not Found \n");
            }

            else
            {
                Console.WriteLine($"{value}");
            }
        }
    }
}