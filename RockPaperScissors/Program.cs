// See https://aka.ms/new-console-template for more information
namespace RockPaperScissors
{
    class Program
    {

        // Method for getting User's choice
        static string GetChoice(String choice)
        {

            switch (choice)
            {
                case "R":
                    choice += "ock".ToUpper();
                    break;
                case "P":
                    choice += "aper".ToUpper();
                    break;

                case "S":
                    choice += "cissors".ToUpper();
                    break;

                default:
                    choice = "w".ToUpper();
                    break;
            }
            return choice;
        }


        //Method for getting Computer's choice
        static string GetCompChoice(String compChoice, int determinant)
        {
            switch (determinant)
            {
                case 1:
                    compChoice = "ROCK";
                    break;

                case 2:
                    compChoice = "PAPER";
                    break;

                case 3:
                    compChoice = "SCISSORS";
                    break;
            }
            return compChoice;
        }


        // Method for showing game outcome
        static void GameLogic(String choice, String compChoice)
        {
            Console.WriteLine("\nYou have chosen " + choice);
            Console.WriteLine("Computer has selected " + compChoice);

            if ((compChoice == "ROCK" && choice == "ROCK") || (compChoice == "PAPER" && choice == "PAPER") || (compChoice == "SCISSORS" && choice == "SCISSORS"))
            {
                Console.WriteLine("DRAW!");
            }
            else if ((compChoice == "ROCK" && choice == "SCISSORS") || (compChoice == "SCISSORS" && choice == "PAPER") || (compChoice == "PAPER" && choice == "ROCK"))
            {
                Console.WriteLine("Computer wins because " + compChoice + " beats " + choice + "!");
            }
            else
            {
                Console.WriteLine("You win because " + choice + " beats " + compChoice + "!");
            }
        }


        // Method for playing again
        static bool Replay(bool running, String playAgain) 
        {
            while (true)
            {
                Console.WriteLine("\nPlay Again? (y/n)");
                Console.WriteLine("$> ");
                playAgain = Console.ReadLine().ToUpper();
                Console.WriteLine();

                if (playAgain == "Y")
                {
                    break;
                }
                else if (playAgain == "N")
                {
                    Console.WriteLine("Thanks for playing!");
                    running = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect option. You must choose 'y' or 'n'.\nPlease try again.\n");
                    continue;
                }
            }
            return running;
        }

        // Main Method
        static void Main(string[] args)
        {
            Random rnd = new Random();
            String choice = "";
            String compChoice = "";
            String playAgain = "";

            bool running = true;

            Console.WriteLine("Welcome to Rock, Paper, Scissors!");

            // Loop for game logic
            while (running)
            {
                // Welcome to the game
                Console.WriteLine("Choose either Rock, Paper, or Scissors (R/P/S): ");
                Console.Write("$> ");

                // User's input for their choice
                choice = Console.ReadLine();
                choice = choice.ToUpper();
                choice = GetChoice(choice);

                if (choice == "W")
                {
                    Console.WriteLine("Incorrect choice.\nTry again.\n");
                    continue;
                }

                int determinant = rnd.Next(1, 4);

                compChoice = GetCompChoice(compChoice, determinant);

                GameLogic(choice, compChoice);

                running = Replay(running, playAgain);
            }

        }
    }
}
