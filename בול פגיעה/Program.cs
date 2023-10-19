using System;

namespace בול_פגיעה
{
    class Program
    {
        static bool Iswon (int [] code, int [] trycode)
        {
            if (NumberBull(code, trycode) == 4)
                return true;
            return false;
        }
        static int  Numbercows(int[] code, int[] trycode)
        {
            bool IsExist = false;
            int count = 0;
            for (int i = 0; i < code.Length; i++)
            {
                IsExist = false;
                for (int j = 0; j < code.Length; j++)
                {
                    if (trycode[i] == code[j])
                        IsExist = true;
                }
                if (IsExist)
                    count++;
            }
            return (count- NumberBull(code, trycode));
        }
        static int NumberBull(int [] code, int [] trycode)
        {
            int count = 0;
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == trycode[i])
                    count++;
            }
            return count;
        }
        static void Game()
        {
            bool won = false;
            int count = 0;
            int[] code = new int[4];
            Choosecode(code);
            int[] trycode = new int[4];
            Console.WriteLine("Now guess the numbers");
            for (int i = 0; i < 10; i++)
            {
                count++;
                for (int j = 0; j < trycode.Length; j++)
                {
                    trycode[j] = int.Parse(Console.ReadLine());
                    if (Filter(trycode[j], trycode, j))
                    {
                        Console.WriteLine("You have entered that number, Enter another one!");
                        trycode[j] = int.Parse(Console.ReadLine());
                    }
                }
                Console.WriteLine("________________________________________________");
                Console.Write($"Your guess is:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Print(trycode);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (Iswon(code, trycode))
                {
                    won = true;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Yesssss!!! You won! You guessed the right number and you succeded by {count} tries.");
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The number of 'bull' is: { NumberBull(code, trycode)}" );
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The number of 'cows' is: {Numbercows(code, trycode)} ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("________________________________________________");
                if (i!=9)
                    Console.WriteLine("You can try again");
            }
            if(!won)
            {
                Console.WriteLine($"The code was");
                Print(code);
            }
           
        }
        static bool Filter(int num,int []code, int index)
        {
            for (int i = 0; i < index; i++)
            {
                if (num == code[i])
                    return true;
            }
            return false;

        }
        static void Print (int [] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]+" ");
            }
        }
        static void Choosecode(int [] code)
        {
            Random random = new Random();

            for (int i = 0; i < code.Length; i++)
            {
                code[i] = random.Next(10);

                while (Filter(code[i], code, i))
                {
                    code[i] = random.Next(10);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int[] code = new int[4];
            Console.WriteLine();
            Console.WriteLine("Hi! You are going to play  'Bulls and Cows' now!");
            Console.WriteLine();
            Console.WriteLine("Enter 4 numbers between 0-9 (Press 'Enter' between each number!)");
            Console.WriteLine();
            Console.WriteLine("(You can guess the number only by 10 tries)");
            Console.WriteLine();
            Game();
        }

    }
}
