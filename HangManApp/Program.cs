namespace HangmanApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAX_TRIES = 20;
            const char FILLER = '_';

            List<string> words = new List<string> { "Allosaurus", "Brontosaurus", "Ceratosaurus", "Diplodocus" };

            Random rndWord = new Random();

            int triesCount = 0;
            int wordIndex = rndWord.Next(words.Count);
            string randomWord = words[wordIndex].ToLower();

            char[] gameState = new char[randomWord.Length];

            for (int i = 0; i < randomWord.Length; i++)
            {
                gameState[i] = FILLER;
            }
            
            Console.WriteLine("Welcome to the hangman game!");

            List<char> guessedLetters = new List<char>();

            while (triesCount < MAX_TRIES)
            {
                Console.WriteLine($"\nHidden word: {new string(gameState)}");
                Console.WriteLine($"You have {MAX_TRIES - triesCount} tries to guess the word correctly! Enter your guess:");
                Console.WriteLine($"Your guesses: ");

                foreach (char c in guessedLetters)
                {
                    Console.Write(c);
                }

                char guessLetter = Console.ReadKey().KeyChar;

                if (guessedLetters.Contains(guessLetter))
                {
                    Console.Clear();
                    Console.WriteLine("\nYou have already guessed that letter. Try again.");
                    continue;
                }

                guessedLetters.Add(guessLetter);

                for (int i = 0; i < randomWord.Length; i++)
                {
                    if (guessLetter == randomWord[i])
                    {
                        gameState[i] = guessLetter;
                    }
                }

                if (!gameState.Contains(FILLER))
                {
                    Console.WriteLine($"\nThe word was {randomWord}, you guessed correct, congratulations!");
                    Console.WriteLine($"\nYou used a total of {triesCount} tries to guess the word!");
                    return;
                }
                else
                {
                    Console.Clear ();
                }

                triesCount++;
            }

            if (triesCount == MAX_TRIES)
            {
                Console.WriteLine($"You ran out of tries, the word was {randomWord}!");
                Console.WriteLine($"Your guesses: ");

                foreach (char c in guessedLetters)
                {
                    Console.Write(c);
                }
            }
        }
    }
}
