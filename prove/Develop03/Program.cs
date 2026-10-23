using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference(
            "Proverbs", 3, 5, 6
        );

        string text = 
            "Trust in the Lord with all thine heart; " +
            "and lean not unto think own understanding. " +
            "In all thy ways acknowledge him, " +
            "and he shall direct thy paths.";

        Scripture scripture = new Scripture(reference, text);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine("Scripture Memorizer");
            Console.WriteLine();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            Console.WriteLine(
                "Press Enter to hide words or type 'quit' to exit."
            );

            string input = Console.ReadLine() ?? "";

            if (input.Trim().Equals(
                "quit",
                StringComparison.OrdinalIgnoreCase))
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