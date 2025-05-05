using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Grade Calculator");
        Console.Write("Enter the numeric grade: ");

        // Try to parse the input as a double
        if (double.TryParse(Console.ReadLine(), out double numericGrade)) {
            // Calculate and display the letter grade
            string letterGrade = CalculateLetterGrade(numericGrade);
            Console.WriteLine($"Letter Grade: {letterGrade}");
        } else {
            Console.WriteLine("Invalid input. Please enter a numeric value.");
        }
        
        if (numericGrade >= 70) {
            Console.WriteLine("You passed!");
        }
        else {
            Console.WriteLine("You did not pass. Please try again.");
        }
    }

    static string CalculateLetterGrade(double grade)
    {
        string letterSign = "";
        int lastDigit = (int)grade % 10;
        if (lastDigit <= 3) {
            letterSign = "-";
        } else if (lastDigit >= 7) {
            letterSign = "+";
        }

        if (grade >= 90) {
            if (letterSign != "+")
                return "A" + letterSign;
            else
                return "A";

        } else if (grade >= 80)
            return "B" + letterSign;
        else if (grade >= 70)
            return "C" + letterSign;
        else if (grade >= 60)
            return "D" + letterSign;
        else
            return "F";
    }

}