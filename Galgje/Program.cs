using System;
using System.Collections.Generic;

namespace Galgje
{
    class Program
    {


        public static Char[] word = new Char[100];
        public static Char[] guessed = new char[100];
        public static int chances = 5;
        public static int guesstimes = 0;
        public static int tips = 3;

        static void Main()
        {


            String randomWordString = GetRandomWord();
            Char[] randomWordArray = randomWordString.ToCharArray();
            //DEFINE LENGTH OF CHAR ARRAYS
            word = new Char[randomWordArray.Length];
            guessed = new Char[randomWordArray.Length];


            //DEFINE CHAR ARRAY
            word = randomWordArray;




            //DEFINE GUESSED CHAR ARRAY TO STARS
            for (int i = 0; i < word.Length; i++)
            {
                guessed[i] = '*';
            }


            Console.Clear();

            //START GAME
            Raad();
        }

        public static void Raad()
        {
            Console.Title = "[Hangman Game] [ Guessed "+guesstimes+" times ] ["+tips+" tips left] [Commands: /tip to get a tip & /stop to stop the game]";
            Console.WriteLine("Guess a character: [" + chances.ToString() + " chances left]");
            Console.WriteLine(new String(guessed));

            String input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.Clear();
                Raad();
                return;
            }
            if (input.ToLower().Equals("/stop"))
            {
                Console.Clear();
                Console.WriteLine("You gave up!");
                Console.WriteLine("The word was: " + new String(word));
                return;
            }
            if (input.ToLower().Equals("/tip"))
            {
                if (tips > 0)
                {


                    Console.Clear();
                    String[] tip = GetTip();
                    tips--;
                    Console.WriteLine("Your hint is: "+ tip[0]+" at position: "+tip[1]+" [ "+tips+" tips left ]");
                    
                }
                else
                {
                    Console.WriteLine("You don't have any hints left!");
                    
                }
                Console.WriteLine("Press a key to continue...");
                Console.ReadLine();
                Console.Clear();
                Raad();
                return;
            }

            Char character = input.ToCharArray()[0];


            //INCREMENT GUESSTIMES
            guesstimes++;
            
            

            int index = 0;
            bool got = false;

            foreach (Char x in word)
            {
                if (x.ToString().ToLower().Equals(character.ToString().ToLower()))
                {

                    guessed[index] = x;

                    got = true;
                }
                index++;


            }

            if (!got)
            {

                chances--;
                if (chances.Equals(0))
                {
                    Console.Clear();
                    Console.WriteLine("You lost!\nThe word was: " + new String(word));
                    Console.ReadLine();
                    return;

                }
            }



            //CHECK IF STRING IS SAME
            if (!new String(word).ToLower().Equals(new String(guessed).ToLower()))
            {

               


                Console.Clear();
                Raad();
            }
            else
            {
                Console.Title = "[Hangman Game] [ Guessed " + guesstimes + " times ] [" + tips + " tips left] [Commands: /tip to get a tip & /stop to stop the game]";

                Console.Clear();
                Console.WriteLine("You guessed it in " + guesstimes + " times!!");
                Console.WriteLine(new String(word));
                Console.ReadKey();

            }


        }





        public static String GetRandomWord()
        {
            String[] words = { "Test1", "Test2" };
           // String[] words = { "day", "violin", "snow", "yardstick", "carousel", "watering", "can", "drink", "music", "solar", "system", "homeless", "thumb", "class", "bell", "pepper", "rocking", "chair", "toilet", "paper", "dig", "cave", "gum", "salt", "and", "pepper", "restaurant", "root", "weight", "free", "gingerbread", "man", "mini", "blinds", "toothbrush", "pinecone", "hunter", "ink", "loaf", "melt", "present", "waterfall", "zebra", "dump", "truck", "lucky", "soccer", "Jupiter", "hot", "dog", "goose", "reindeer", "dominoes", "tennis", "teapot", "swing", "birthday", "cake", "sleep", "lake", "front", "porch", "pirate" };
            Random rnd = new Random();

            return words[rnd.Next(0, (words.Length - 1))];

        }


        public static String[] GetTip()
        {
            List<String[]> notGuessed = new List<String[]>();
            int wordIndex = 0;
            foreach (Char x in guessed)
            {

                
                
                if (x.Equals('*'))
                {
                    String[] stringArrayThing = new String[2] { word[wordIndex].ToString(), (wordIndex + 1).ToString() };

                    notGuessed.Add(stringArrayThing);

                }
                wordIndex++;

            }
            Random rnd = new Random();
            String[][] notGuessedArray = notGuessed.ToArray();
            String[] tip = notGuessedArray[rnd.Next( 0, (notGuessedArray.Length -1))];

            return tip;


        }




    }


}
