using System;
public class InvalidAgeExeption : Exception
{
    public InvalidAgeExeption(string message): base(message);
}