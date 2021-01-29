using System;
using System.Collections.Generic;

namespace Lab8GetToKnowClassmates
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> students = new List<string>() { "Ramon Guarnes", "Antonio Manzari", "Joshua Carolin", "Nick D'Oria", "Jeremiah Wyeth", "Wendi Magee", "Juliana", "Nathaniel Davis", "Tommy Waalkes", "Grace Seymore", "Jeffrey Wohlfield", "Josh Gallentine", "Stephen Jedlicki" };
            List<string> homeTown = new List<string>() { "Tigard, OR", "Beverly Hills, MI", "Novi, MI", "Canton, MI", "Crystal, MI", "Detroit, MI", "Denver, CO", "Berkley, MI", "Raleigh, NC", "Mesa, AZ", "Detroit, MI", "Baldwin, MI", "The Moon" };
            List<string> favoriteFood = new List<string>() { "Burgers", "Focaccia Barese", "Naleśniki", "Tacos", "Burgers", "Salami", "Tacos", "Steak", "Chicken Curry", "Sweet potato fries", "Steak", "Falafel", "Mooncakes" };

            while (true)
            {
                int numberOfStudents = students.Count;
                Console.Write($"Enter the full name or a student number (1 - {numberOfStudents}) to learn more about the class members: ");

                int requestedStudentId = StudentValidation(students);
                string nameOfRequestedStudent = students[requestedStudentId];               

                Console.WriteLine($"Student {requestedStudentId + 1} is {nameOfRequestedStudent}");

                Console.Write($"What would you like to know about {nameOfRequestedStudent}, their home town or their favorite food? ");
                int interestInput = InterestValidation();

                string studentsHometown = homeTown[requestedStudentId];
                string studentsFavoriteFood = favoriteFood[requestedStudentId];

                DisplayInterests(interestInput, nameOfRequestedStudent, studentsHometown, studentsFavoriteFood);

                Console.Write("Would you like to learn about another student? (y/n) ");
                string anotherStudent = Console.ReadLine().ToLower();

                if (anotherStudent != "y")
                {
                    break;
                }
            }

        }

        public static int StudentValidation(List<string> students)
        {
            while (true)
            {
                string userInput = Console.ReadLine();
                int studentId;
                bool isNumber = int.TryParse(userInput, out studentId);
                bool isText = students.Contains(userInput);

                try
                {
                    if (isNumber && studentId > students.Count || studentId < students.Count)
                    {
                        throw new Exception($"Invalid student number, please enter a valid number between (1 - {students.Count}) or the student's full name: ");
                    }
                    if (isNumber)
                    {
                        return studentId - 1;
                    }
                    if (isText)
                    {
                        return students.IndexOf(userInput);
                    }
                    else
                    {
                        throw new Exception("Student doesn't exist.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Invalid input: {e.Message}");
                    continue;
                }

                    
            }
        }

        public static int InterestValidation()
        {
            while (true)
            {
                string interest = Console.ReadLine().ToLower();

                try
                {
                    if (interest == "home town" || interest == "hometown")
                    {
                        return 1;
                    }
                    else if (interest == "favorite food" || interest == "favoritefood" || interest == "fav food")
                    {
                        return 2;
                    }
                    else
                    {
                        throw new Exception("Invalid interest selection, please choose between favorite food or home town: ");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Invalid input: {e.Message}");
                    continue;
                }
            }
        }

        public static void DisplayInterests(int interestInput, string nameOfRequestedStudent, string studentsHometown, string studentsFavoriteFood)
        {
            while (true)
            {
                if (interestInput == 1)
                {
                    Console.WriteLine($"{nameOfRequestedStudent}'s home town is {studentsHometown}");
                }
                else if (interestInput == 2)
                {
                    Console.WriteLine($"{nameOfRequestedStudent}'s favorite food is {studentsFavoriteFood}");
                }

                Console.Write($"Would you like to know more about {nameOfRequestedStudent}? (y/n) ");
                string goAgain = Console.ReadLine().ToLower();

                if (goAgain == "y")
                {
                    Console.Write($"Would you like to know {nameOfRequestedStudent}'s home town or favorite food? ");
                    interestInput = InterestValidation();
                    DisplayInterests(interestInput, nameOfRequestedStudent, studentsHometown, studentsFavoriteFood);
                    break;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
