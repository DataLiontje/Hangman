using System;

namespace Galgje
{
    class Program
    {


        public static Char[] word = new Char[100];
        public static Char[] guessed = new char[100];
        public static int chances = 5;
        public static int guesstimes = 0;

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
            for (int i=0;i<word.Length;i++)
            {
                guessed[i] = '*';
            }


            Console.Clear();

            //START GAME
            Raad();
        }

        public static void Raad()
        {
            Console.WriteLine("Raad letter voor letter: [nog "+chances.ToString()+" kansen]");
            Console.WriteLine(new String(guessed));
            
            String input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.Clear();
                Raad();
                return;
            }
            if (input.ToLower().Equals("stop"))
            {
                Console.Clear();
                Console.WriteLine("Gestopt met raden!");
                Console.WriteLine("Het woord was: " + new String(word));
                return;
            }

            Char character = input.ToCharArray()[0];
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
                    Console.WriteLine("Je hebt verloren!\nHet woord was: "+new String(word));
                    Console.ReadLine();
                    return;
                   
                }
            }

            
            if (!new String(word).ToLower().Equals(new String(guessed).ToLower()))
            {


                Console.Clear();
                Raad();
            }
            else
            {
               
                Console.Clear();
                Console.WriteLine("Je hebt t geraden!!");
                Console.WriteLine(new String(word));
                Console.ReadLine();

            }


        }




        public static String GetRandomWord()
        {
            String[] words = { "day", "violin", "snow", "yardstick", "carousel", "watering", "can", "drink", "music", "solar", "system", "homeless", "thumb", "class", "bell", "pepper", "rocking", "chair", "toilet", "paper", "dig", "cave", "gum", "salt", "and", "pepper", "restaurant", "root", "weight", "free", "gingerbread", "man", "mini", "blinds", "toothbrush", "pinecone", "hunter", "ink", "loaf", "melt", "present", "waterfall", "zebra", "dump", "truck", "lucky", "soccer", "Jupiter", "hot", "dog", "goose", "reindeer", "dominoes", "tennis", "teapot", "swing", "birthday", "cake", "sleep", "lake", "front", "porch", "pirate" };
            Random rnd = new Random();

            return words[rnd.Next(0, (words.Length - 1))];

        }

    }
}
