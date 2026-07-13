using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();
        List<Course> courses = new List<Course>();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("========= Student Management System =========");
            Console.WriteLine("1. Register Student");
            Console.WriteLine("2. Add Course");
            Console.WriteLine("3. View All Students");
            Console.WriteLine("4. View All Courses");
            Console.WriteLine("5. Search Student by ID");
            Console.WriteLine("6. Enroll Student in Course(s)");
            Console.WriteLine("7. Display Student Details (with fees)");
            Console.WriteLine("8. Exit");
            Console.Write("Enter a choice 1-8: ");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Student ID = ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        bool exists = false;
                        foreach (Student s in students)
                        {
                            if (s.Id == id)
                            {
                                exists = true;
                                break;
                            }
                        }
                        if (exists)
                        {
                            Console.WriteLine("Student already exists.");
                            break;
                        }

                        Console.Write("Enter Name = ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Department = ");
                        string dept = Console.ReadLine();

                        Console.WriteLine("Select Student Type:");
                        Console.WriteLine("1. Regular");
                        Console.WriteLine("2. Scholarship");
                        Console.WriteLine("3. Part-Time");
                        Console.Write("Enter choice = ");
                        int typeChoice = Convert.ToInt32(Console.ReadLine());

                        Student newStudent;
                        switch (typeChoice)
                        {
                            case 1:
                                newStudent = new RegularStudent(id, name, dept);
                                break;
                            case 2:
                                newStudent = new ScholarshipStudent(id, name, dept);
                                break;
                            case 3:
                                newStudent = new PartTimeStudent(id, name, dept);
                                break;
                            default:
                                Console.WriteLine("Invalid student type. Defaulting to Regular.");
                                newStudent = new RegularStudent(id, name, dept);
                                break;
                        }

                        students.Add(newStudent);
                        Console.WriteLine("Student registered successfully.");
                        break;

                    case 2:
                        Console.Write("Enter Course ID = ");
                        int cid = Convert.ToInt32(Console.ReadLine());

                        bool courseExists = false;
                        foreach (Course c in courses)
                        {
                            if (c.CourseId == cid)
                            {
                                courseExists = true;
                                break;
                            }
                        }
                        if (courseExists)
                        {
                            Console.WriteLine("Course already exists.");
                            break;
                        }

                        Console.Write("Enter Course Name = ");
                        string cname = Console.ReadLine();
                        Console.Write("Enter Credits = ");
                        int credits = Convert.ToInt32(Console.ReadLine());

                        Course newCourse = new Course(cid, cname, credits);
                        courses.Add(newCourse);
                        Console.WriteLine("Course added successfully.");
                        break;

                    case 3:
                        if (students.Count == 0)
                        {
                            Console.WriteLine("No students registered.");
                        }
                        else
                        {
                            foreach (Student s in students)
                            {
                                Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Department: {s.Department}, Type: {s.GetType().Name}");
                            }
                        }
                        break;

                    case 4:
                        if (courses.Count == 0)
                        {
                            Console.WriteLine("No courses available.");
                        }
                        else
                        {
                            foreach (Course c in courses)
                            {
                                c.DisplayCourse();
                            }
                        }
                        break;

                    case 5:
                        Console.Write("Enter Student ID = ");
                        int searchId = Convert.ToInt32(Console.ReadLine());
                        bool found = false;
                        foreach (Student s in students)
                        {
                            if (s.Id == searchId)
                            {
                                Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Department: {s.Department}, Type: {s.GetType().Name}");
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Student not found.");
                        }
                        break;

                    case 6:
                        Console.Write("Enter Student ID = ");
                        int enrollId = Convert.ToInt32(Console.ReadLine());
                        Student targetStudent = null;
                        foreach (Student s in students)
                        {
                            if (s.Id == enrollId)
                            {
                                targetStudent = s;
                                break;
                            }
                        }
                        if (targetStudent == null)
                        {
                            Console.WriteLine("Student not found.");
                            break;
                        }

                        if (courses.Count == 0)
                        {
                            Console.WriteLine("No courses available to enroll in.");
                            break;
                        }

                        bool enrolling = true;
                        while (enrolling)
                        {
                            Console.Write("Enter Course ID to enroll = ");
                            int courseIdToEnroll = Convert.ToInt32(Console.ReadLine());

                            Course courseToEnroll = null;
                            foreach (Course c in courses)
                            {
                                if (c.CourseId == courseIdToEnroll)
                                {
                                    courseToEnroll = c;
                                    break;
                                }
                            }

                            if (courseToEnroll == null)
                            {
                                Console.WriteLine("Course not found.");
                            }
                            else
                            {
                                bool success = targetStudent.EnrollCourse(courseToEnroll);
                                if (success)
                                {
                                    Console.WriteLine("Enrolled successfully.");
                                }
                            }

                            Console.Write("Enroll in another course? (y/n) = ");
                            string more = Console.ReadLine();
                            if (more == null || more.ToLower() != "y")
                            {
                                enrolling = false;
                            }
                        }
                        break;

                    case 7:
                        Console.Write("Enter Student ID = ");
                        int detailId = Convert.ToInt32(Console.ReadLine());
                        Student detailStudent = null;
                        foreach (Student s in students)
                        {
                            if (s.Id == detailId)
                            {
                                detailStudent = s;
                                break;
                            }
                        }
                        if (detailStudent == null)
                        {
                            Console.WriteLine("Student not found.");
                        }
                        else
                        {
                            detailStudent.DisplayDetails();
                        }
                        break;

                    case 8:
                        Console.WriteLine("Exiting application. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a number only.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}