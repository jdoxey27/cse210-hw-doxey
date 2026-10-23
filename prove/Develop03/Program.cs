using System;
using System.Collections.Generic;

class Program
{
    // Exceeds the core requirements by providing a small library of scriptures and choosing
    // one at random for the user each round. This adds variety and makes the memorizer more engaging.
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."
            ),
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him " +
                "should not perish, but have everlasting life."
            ),
            new Scripture(
                new Reference("Alma", 32, 21),
                "If ye have faith ye hope for things which are not seen, which are true."
            )
        };

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (!scripture.IsCompletelyHidden())
        {

            Console.WriteLine("Scripture Memorizer");
            Console.WriteLine();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine() ?? "";

            if (input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            if (input.Length == 0)
            {
                scripture.HideRandomWords(3);
            }
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        if (scripture.IsCompletelyHidden())
        {
            Console.WriteLine();
            Console.WriteLine("You did it!");
        }
    }
}
