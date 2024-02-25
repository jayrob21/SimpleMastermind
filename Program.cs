using System.Linq;
using System.Collections.Generic;

namespace Projects;

class Program
{
    private static int counter = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("The point of this game is to guess the 4 digit combination. ");
        Console.WriteLine("In order to pass you will have your guess will have to be an exact match");
        Console.WriteLine("You will get 10 guesses to come up with the correct combination.");
        Console.WriteLine("A minus sign (-) will be printed for every digit that is correct but not in the right position");
        Console.WriteLine("A plus sign (+) will be printed for every digit that is both part of the combination and in the right position");
        Console.WriteLine("Your guess is limited to a length of 4 characters");
        Console.WriteLine("Do you want to start? Yes or No");
        string start = Console.ReadLine();
        bool res = (start.ToLower()=="yes")?true:false;
        string combination = GetCombination();
        if(!res)
            Console.WriteLine("Please enter yes to start");
        else{
            counter = 10;
            Console.WriteLine("Starting game. You have "+counter+" guesses remaining.");
            Console.WriteLine(combination);
            while(counter>0){
                string guess = Console.ReadLine().SubString(0,4);
                counter--;
                if(guess==combination){
                    Console.WriteLine("++++");
                    Console.WriteLine("You Win! Guesses left: "+counter);
                    break;
                }
                else{
                    if(!string.isNullOrWhiteSpace(guess)){
                        char[] guessCombos = guess.ToCharArray();
                        char[] combos = combination.ToCharArray();
                        string minusOutput = "";
                        for(int x = 0;x<combos.length;x++){
                            
                        }
                    }
                }
            }
        }
    }
    public static string GetCombination(){
        string val = "";
        Random rnd = new();
        for(int x = 0;x<4;x++)
            val+= rnd.Next(1,7).ToString();
        return val;
    }
    public static void Match(string guess){
        if(counter>0){
            //if(int.tryParse())
        }
    }
}
