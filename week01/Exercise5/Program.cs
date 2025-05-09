using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        String userName = GetUserName();
        int userAge = GetUserAge();

        int squareAge = CalculateSquareOfAge(userAge);
        DisplayUserInfo(userName, squareAge);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Week 1 Exercise 5 program!");
    }

    static String GetUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int GetUserAge()
    {
        Console.Write("Please enter your age: ");
        return int.Parse(Console.ReadLine());
    }

    static int CalculateSquareOfAge(int age)
    {
        return age * age;
    }

    static void DisplayUserInfo(String name, int squareAge)
    {
        Console.WriteLine($"Hello {name}, the square of your age is {squareAge}.");
    }
}