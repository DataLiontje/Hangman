using System;

namespace Galgje
{
    class Program
    {


        public static Char[] word = "woord".ToCharArray();
        public static Char[] guessed = new char[100];
        public static int chances = 5;
        static void Main()
        {


            Console.Write("Geef een woord in voor de ander om te gaan raden: ");
            
            String guessword = Console.ReadLine();

            if (string.IsNullOrEmpty(guessword))
            {
                Console.Clear();
                Main();
            }

            word = guessword.ToCharArray();

            guessed = new char[word.Length];



            for (int i=0;i<word.Length;i++)
            {
                guessed[i] = '*';
            }
            Console.Clear();
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

            Char character = input.ToCharArray()[0];

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
                    Raad();
                   
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

    }
}
