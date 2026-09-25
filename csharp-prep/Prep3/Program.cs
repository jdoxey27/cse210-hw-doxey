using System;
using System.Security.Cryptography;
using System.Threading.Channels;

class Program
{
    static void Main(string[] args)
    {
       Random RandomGenerator = new Random();
       int wonder_number = RandomGenerator.Next(1,101);

       int guess = -1;

       while (guess != wonder_number)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (wonder_number > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (wonder_number < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("That is Correct!");
            }
        }

    }
}