using System;

namespace FileDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
            run();
        }
        public static void run()
        {
            string userInput;
            bool running = true;
            int input;
            IFileComponent file;
            while (running)
            {
                file = null;
                input = PromptMenu("Welcome to a file encrypter/decrypter, select an option:", new string[] { "0 - Exit", "1 - Read", "2 - Write" });
                if(input != -1)
                {
                    switch (input)
                    {
                        case 0:
                            Console.WriteLine("Farewell!");
                            running = false;
                            break;
                        case 1:
                            Console.WriteLine("What file would you like to read?");
                            userInput = Console.ReadLine();
                            file = new IODecorator(file, userInput, false);
                            do
                            {
                                input = PromptMenu("Would you like to add a decrypter?:", new string[] { "0 - None", "1 - Shifter", "2 - Unix / Windows Converter", "3 - Save as New File" });
                                switch(input)
                                {
                                    case -1:
                                        Console.WriteLine("Please try again");
                                        break;
                                    case 0:
                                        Console.WriteLine("Ok");
                                        break;
                                    case 1:
                                        Console.WriteLine("How much would you like to shift down by?:");
                                        userInput = Console.ReadLine();
                                        if(int.TryParse(userInput, out int pick))
                                        {
                                            file = new ShiftDecorator(file, -1 * pick);
                                        }
                                        else
                                        {
                                            Console.WriteLine("That was not a whole number...");
                                        }
                                        break;
                                    case 2:
                                        file = new LineDecorator(file);
                                        Console.WriteLine(file.GetFile());
                                        break;
                                    case 3:
                                        Console.WriteLine("What would you like to name this file?: ");
                                        userInput = Console.ReadLine();
                                        file = new IODecorator(file, userInput, true);
                                        Console.WriteLine(file.GetFile());
                                        input = 0;
                                        break;
                                }
                            } while (input != 0);
                            Console.WriteLine(file.GetFile());
                            break;
                        case 2:
                            do
                            {
                                input = PromptMenu("What would you like to do?:", new string[] { "0 - Save", "1 - Add Text", "2 - Sign", "3 - Shift" });
                                switch(input)
                                {
                                    case -1:
                                        Console.WriteLine("Please try again");
                                        break;
                                    case 0:
                                        Console.WriteLine("What would you like to name this file?: ");
                                        userInput = Console.ReadLine();
                                        file = new IODecorator(file, userInput, true);
                                        Console.WriteLine(file.GetFile());
                                        break;
                                    case 1:
                                        Console.WriteLine("What would you like to say?: ");
                                        userInput = Console.ReadLine();
                                        file = new WordDecorator(file, userInput);
                                        Console.WriteLine(file.GetFile());
                                        break;
                                    case 2:
                                        Console.WriteLine("What would you like your signature to be?: ");
                                        userInput = Console.ReadLine();
                                        file = new WordDecorator(file, userInput);
                                        Console.WriteLine(file.GetFile());
                                        break;
                                    case 3:
                                        Console.WriteLine("How much would you like to shift up by?:");
                                        userInput = Console.ReadLine();
                                        if (int.TryParse(userInput, out int pick))
                                        {
                                            file = new ShiftDecorator(file, pick);
                                            Console.WriteLine(file.GetFile());
                                        }
                                        else
                                        {
                                            Console.WriteLine("That was not a whole number...");
                                        }
                                        break;
                                }
                            } while (input != 0);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("There was an issue, please try again");
                }
            }
        }
        public static int PromptMenu(string prompt, string[] options)
        {
            string userInput;
            bool error = true;
            do
            {
                Console.WriteLine(prompt);
                foreach(string option in options)
                {
                    Console.WriteLine(option);
                }
                userInput = Console.ReadLine();
                if(int.TryParse(userInput, out int pick))
                {
                    if (pick >= 0 && pick <= options.Length) return pick;
                }
            } while (error);
            return -1;
        }
    }
}
