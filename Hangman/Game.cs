using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Game
    {
        public void Start()
        {
            string[] database = new string[20]
            {
                "bonbons",
                "lovesick", "flirt", "cute", "soulmate", "crush", "serenade", "admire", "romantic", "darling",
                "eternal", "dreamboy", "whisper", "honeybun", "everlasting", "beloved", "bewitched", "handsome", "romance", "special"
            };
            Random randomGen = new Random();
            int randomizer = randomGen.Next(0, database.Length);
            string pickedWord = database[randomizer];
            string displayedWord = "";
            for (int i = 0; i < pickedWord.Length; i++)
            {
                displayedWord += "_";
            }
            int round = 1;
            int mistake = 0;
            int possibleMistakes = 10;
            string usedLetters = "";
            char key = '1';

            Console.WriteLine("Hello to my Hangman");
            while (mistake < possibleMistakes && displayedWord != pickedWord)
            {
                Console.WriteLine("This is your {0} round, you still can make {1} mistakes.", round, possibleMistakes - mistake);
                Console.WriteLine();
                for (int i = 0; i < displayedWord.Length; i++)
                {
                    Console.Write("{0} ", displayedWord[i]);
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You can guess a letter or a whole word");
                Console.WriteLine();
                string yourTry = Console.ReadLine();
                if (yourTry.Length != 1)
                {
                    if (yourTry == pickedWord)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Oh, wow, you did it");
                        displayedWord = yourTry;
                    }
                    else
                    {
                        Console.WriteLine("God, not good");
                        mistake++;
                    }
                }
                else
                {
                    char guessedLetter = yourTry[0];
                    if (pickedWord.Contains(guessedLetter))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Yay, you guessed one letter");
                        usedLetters += guessedLetter;
                        for (int i = 0; i < pickedWord.Length; i++)
                        {
                            if (pickedWord[i] == guessedLetter)
                            {
                                displayedWord = displayedWord.Remove(i, 1);
                                displayedWord = displayedWord.Insert(i, guessedLetter.ToString());
                            }
                        }
                    }
                    else if (!pickedWord.Contains(guessedLetter) && !(guessedLetter == key))
                    {
                        usedLetters += guessedLetter;
                        mistake++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Well, mistake. Keep trying.");
                    }
                    round++;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Used letters: {0}", usedLetters);
                    Console.ResetColor();
                }
            }

            if (displayedWord == pickedWord)
            {
                Console.WriteLine("Congrats, you guessed the word correctly. This was {0}", displayedWord);
            }
            else
            {
                Console.WriteLine("It seems that you lost. You guessed only {0}. The actual word was {1}.", displayedWord, pickedWord);
            }
            Console.ResetColor();
        }
    }
}
