using System;
using System.Collections.Generic;


abstract class Student
{
    public int Id;
    public string Name;
    public string Department;
    public List<Course> EnrolledCourses = new List<Course>();

    protected const int MaxCourses = 6;

    public Student(int id, string name, string department)
    {
        Id = id;
        Name = name;
        Department = department;
    }

   
    public abstract double CalculateFee(int totalCredits);

    public bool EnrollCourse(Course course)
    {
        if (EnrolledCourses.Count >= MaxCourses)
        {
            Console.WriteLine($"Cannot enroll. Maximum course limit ({MaxCourses}) reached.");
            return false;
        }

        foreach (Course c in EnrolledCourses)
        {
            if (c.CourseId == course.CourseId)
            {
                Console.WriteLine("Student is already enrolled in this course.");
                return false;
            }
        }

        EnrolledCourses.Add(course);
        return true;
    }

    public int GetTotalCredits()
    {
        int total = 0;
        foreach (Course c in EnrolledCourses)
        {
            total += c.Credits;
        }
        return total;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"Student ID   : {Id}");
        Console.WriteLine($"Name         : {Name}");
        Console.WriteLine($"Department   : {Department}");
        Console.WriteLine($"Student Type : {GetType().Name}");

        Console.WriteLine("Enrolled Courses:");
        if (EnrolledCourses.Count == 0)
        {
            Console.WriteLine("   None");
        }
        else
        {
            foreach (Course c in EnrolledCourses)
            {
                Console.WriteLine($"   - {c.CourseName} (ID: {c.CourseId}, Credits: {c.Credits})");
            }
        }

        int totalCredits = GetTotalCredits();
        Console.WriteLine($"Total Credits: {totalCredits}");
        Console.WriteLine($"Total Fee    : {CalculateFee(totalCredits):C}");
        Console.WriteLine("-----------------------------------");
    }
}