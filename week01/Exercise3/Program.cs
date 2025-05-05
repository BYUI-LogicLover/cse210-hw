using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("This is a number guessing game!");
        Console.WriteLine("I have selected a number between 1 and 100.");

        Random random = new Random();
        int secretNumber = random.Next(1, 101);
        int guess = 0;
        int attempts = 0;
        bool isCorrect = false;

        while (!isCorrect) {
            Console.Write("Enter your guess (1-100): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out guess)) {
                attempts++;

                if (guess < 1 || guess > 100) {
                    Console.WriteLine("Please enter a number between 1 and 100.");
                } else if (guess < secretNumber) {
                    Console.WriteLine("Too low! Try again.");
                } else if (guess > secretNumber) {
                    Console.WriteLine("Too high! Try again.");
                } else {
                    isCorrect = true;
                    Console.WriteLine(
                        $"Congratulations! You've guessed the number {secretNumber} in {attempts} attempts.");
                    
                    Console.WriteLine("Would you like to play again? (y/n)");
                    string playAgain = Console.ReadLine().ToLower();
                    if (playAgain == "y") {
                        Main(args); // Restart the game
                    } else {
                        Console.WriteLine("Thank you for playing!");
                    }
                }
            } else {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}