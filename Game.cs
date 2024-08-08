
using System.Runtime;
using System.Text;

namespace NumberGuess;

public class Game
{

    private int[] _target;
    HashSet<char> _targetSet = new HashSet<char>();
    private Game(int guesses, int nDigits)
    {
        GuessesRemaining = guesses;
        _target = GetRandomNumber(nDigits);
    }
    
    public int GuessesRemaining {get; private set;}

    public static Game StartNewGame()
    {
        return new Game(10,4);
    }

    private int[] GetRandomNumber(int n = 4)
    {
        int[] target = new int[n];
        _targetSet.Clear();
        for (int i = 0; i < n; i++)
        {
            target[i] = new Random().Next(1, 7);
            _targetSet.Add((target[i].ToString())[0]);
        }
        return target;
    }

    public string MakeGuess(char[] guess)
    {
        if(new string(guess) == "debug")
        {
            return string.Join("", _target);
        }
        if(GuessesRemaining < 1)
        {
            throw new InvalidOperationException("No guesses remaining");
        }
        if(!IsValidGuess(guess))
        {
            throw new ArgumentException("Invalid guess");
        }
        int plusses = 0;
        int minuses = 0;
        StringBuilder sb = new StringBuilder();
        for(int i=0; i<guess.Length; i++)
        {
            if(guess[i] == _target[i].ToString()[0])
            {
                plusses++;
            }
            else if(_targetSet.Contains(guess[i]))
            {
                minuses++;
            }
        }
        for(int i=0; i<plusses; i++)
        {
            sb.Append('+');
        }
        for(int i=0; i<minuses; i++)
        {
            sb.Append('-');
        }
        GuessesRemaining--;
        return sb.ToString();   

    }

    private bool IsValidGuess(char[] guess)
    {
        if (guess.Length != _target.Length)
        {
            return false;
        }
        foreach (var c in guess)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }

}