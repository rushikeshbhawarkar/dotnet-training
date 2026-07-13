using System;
class Course
{
    public int CourseId;
    public string CourseName;
    public int Credits;

    public Course(int courseId, string courseName, int credits)
    {
        CourseId = courseId;
        CourseName = courseName;
        Credits = credits;
    }

    public void DisplayCourse()
    {
        Console.WriteLine($"Course ID: {CourseId}, Name: {CourseName}, Credits: {Credits}");
    }
}