using System.Diagnostics.Metrics;
namespace HangmanApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAX_TRIES = 20;
            const char FILLER = '_';

            List<char> guessedLettersList = new List<char>();
            List<string> words = new List<string> { "Allosaurus", "Brontosaurus", "Ceratosaurus", "Diplodocus" };

            Random randomList = new Random();

            int triesCount = 0;
            int wordIndex = randomList.Next(words.Count);
            string randomWord = words[wordIndex].ToLower();
            char[] arrayRandomWord = new char[randomWord.Length];


            Console.WriteLine("Welcome to the hangman game!");

            for (int i = 0; i < randomWord.Length; i++)
            {
                arrayRandomWord[i] = FILLER;
            }

            while (triesCount < MAX_TRIES)
            {
                Console.WriteLine($"\nHidden word: {new string(arrayRandomWord)}");
                Console.WriteLine($"You have {MAX_TRIES - triesCount} tries to guess the word correctly! Enter your guess:");
                Console.WriteLine($"Your guesses: ");

                foreach (char c in guessedLettersList)
                {
                    Console.Write(c);
                }

                char guessLetter = Console.ReadKey().KeyChar;

                if (guessedLettersList.Contains(guessLetter))
                {
                    Console.Clear();
                    Console.WriteLine("\nYou have already guessed that letter. Try again.");
                    continue;
                }

                guessedLettersList.Add(guessLetter);

                for (int i = 0; i < randomWord.Length; i++)
                {
                    if (guessLetter == randomWord[i])
                    {
                        arrayRandomWord[i] = guessLetter;
                    }
                }

                if (!arrayRandomWord.Contains(FILLER))
                {
                    triesCount++;
                    Console.WriteLine($"\nThe word was {randomWord}, you guessed correct, congratulations!");
                    Console.WriteLine($"\nYou used a total of {triesCount} tries to guess the word!");
                    return;
                }
                else
                {
                    Console.Clear ();
                    triesCount++;
                    continue;
                }
            }

            if (triesCount == MAX_TRIES)
            {
                Console.WriteLine($"You ran out of tries, the word was {randomWord}!");
                Console.WriteLine($"Your guesses: ");

                foreach (char c in guessedLettersList)
                {
                    Console.Write(c);
                }
            }
        }
    }
}
