using SimpleMastermind;

namespace Projects;

class Program
{
    private static int counter = 0;

    static void Main(string[] args)
    {
        HandleRules();
        Console.WriteLine("Do you want to start? Yes or No");
        string? start = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(start))
            start = "";
        bool res = (start.Equals("yes", StringComparison.CurrentCultureIgnoreCase));
        string combination = GetCombination();
        HandleGame(res, combination);
      
    }
    public static void HandleRules() {
        Console.WriteLine("The point of this game is to guess the 4 digit combination. ");
        Console.WriteLine("In order to pass you will have your guess will have to be an exact match");
        Console.WriteLine("You will get 10 guesses to come up with the correct combination.");
        Console.WriteLine("A minus sign (-) will be printed for every digit that is correct but not in the right position");
        Console.WriteLine("A plus sign (+) will be printed for every digit that is both part of the combination and in the right position");
        Console.WriteLine("Your guess is limited to a length of 4 characters");
    }
    public static string GetCombination(){
        string val = "";
        Random rnd = new();
        for(int x = 0;x<4;x++)
            val+= rnd.Next(1,7).ToString();
        return val;
    }
    private static void HandleGame(bool res, string combination) {
        if (!res)
            Console.WriteLine("Please enter yes to start");
        else
        {
            counter = 10;
            Console.WriteLine("Starting game. You have " + counter + " guesses remaining.");
            while (counter > 0)
            {
                string? input = Console.ReadLine();
                counter--;
                if (!string.IsNullOrWhiteSpace(input))
                {
                    string guess = (input.Length > 4) ? input.Substring(0, 4) : input;
                    if (guess == combination)
                    {
                        Console.WriteLine("++++");
                        Console.WriteLine("You Win! Guesses left: " + counter);
                        break;
                    }
                    else
                        CheckGuess(guess, combination);
                }
                else
                    Console.WriteLine($"Guesses left: {counter}");
            }
        }
    }
    private static void CheckGuess(string guess, string combination) {
        if (!string.IsNullOrWhiteSpace(guess))
        {
            List<char> guessCombos = guess.ToCharArray().ToList();
            List<char> combos = combination.ToCharArray().ToList();
            List<CheckResult> list = [];
            for (int x = 0; x < guessCombos.Count; x++)
            {
                char digit = guessCombos[x];
                int index = combos.IndexOf(digit);
                list.Add(new()
                {
                    Value = digit.ToString(),
                    GuessIndex = x,
                    CombinationIndex = index,
                    CorrentIndex = index == x,
                    CorrectValue = combos.Contains(digit)
                });
            }

            List<CheckResult> correctOccurences = list.Where(x => x.CorrectValue && x.CorrentIndex).ToList();
            List<CheckResult> almostOccurences = list.Where(x => x.CorrectValue && !x.CorrentIndex).ToList();
            string minuses = "";
            string pluses = "";
            correctOccurences.ForEach(x => pluses += "+");
            correctOccurences.ForEach(x => minuses += "-");
            Console.WriteLine(pluses + minuses + $" Guesses left: {counter}");
        }
    }
}
