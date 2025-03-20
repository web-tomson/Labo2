using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a scripture reference and text
        Reference reference = new Reference("Book of Mormon", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";

        // Create the Scripture object
        Scripture scripture = new Scripture(reference, text);

        // Loop to progressively hide words
        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords();
        }

        // Final display when all words are hidden
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are now hidden. Program ended.");
    }
}
