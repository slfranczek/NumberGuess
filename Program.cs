namespace NumberGuess;

class Program
{
    static void Main(string[] args)
    {
        while(true)
        {
            Console.WriteLine("Hello! Want to start a new game? (y/n)");
            char response = Console.ReadKey().KeyChar;
            if(response == 'n')
            {
                break;
            }
            else if(response == 'y')
            {
                Game game = Game.StartNewGame();
                Console.WriteLine("New game started!");
                while(game.GuessesRemaining > 0)
                {
                    Console.WriteLine("Enter your guess:");
                    string guess = Console.ReadLine();
                    string result = String.Empty;
                    try{
                        result = game.MakeGuess(guess.ToCharArray());
                    }
                    catch(ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                    catch(InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                    Console.WriteLine(result);
                    if(result == "++++")
                    {
                        Console.WriteLine("Congratulations! You won!");
                        break;
                    }
                    Console.WriteLine($"Guesses remaining: {game.GuessesRemaining}");
                }
                if(game.GuessesRemaining == 0)
                {
                    Console.WriteLine("No guesses remaining. Game over!");
                }
            }
            else
            {
                Console.WriteLine("Invalid response. Please enter 'y' or 'n'.");
            }

        }
        
        
    }
}
