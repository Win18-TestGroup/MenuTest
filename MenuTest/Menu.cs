using System;
using System.Collections.Generic;
using System.Text;

namespace MenuTest
{
    class Menu
    {
        public static List<Tuple<string, string>> users = new List<Tuple<string, string>>();

        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("##START####################");
            Console.WriteLine("# Press to choose         #");
            Console.WriteLine("# 1. Login                #");
            Console.WriteLine("# 2. Registry             #");
            Console.WriteLine("###########################");

            int choice = 0;

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Please dont be a jackass, press a number in the list!");
                throw;
            }

            switch (choice)
            {
                case 1: Menu.Login(); break;
                case 2: Menu.Registy(); break;
                default:
                    Console.WriteLine("Please pick a number in the menu");
                    Menu.Start();
                    break;
            }
        }

        public static void Login()
        {
            Console.Clear();
            Console.WriteLine("#### LOGIN ####");
            Console.WriteLine();
            Console.Write("Username:");
            string userName = Console.ReadLine();
            Console.WriteLine();
            if (users.Exists(e => e.Item1 == userName))
            {
                
                int attempt = 1;
                do
                {
                    Console.Write("Password:");
                    string password = Console.ReadLine();
                    attempt++;
                    if (users.Exists(e => e.Item2 == password))
                    {
                        Menu.MainMenu();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("wrong password");
                        Console.WriteLine($"You have {4 - attempt} attempt left!");
                        

                    }
                } while (attempt < 4);
            }
            else
            {
                Console.WriteLine("you are not a member");
                Console.ReadKey();
                Menu.Start();

            }
        }

        public static void Registy()
        {
            Console.Clear();
            Console.WriteLine("#### Registry ####");
            Console.WriteLine();
            Console.Write("Username:");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Password:");
            string password = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Your username is {userName}  and your password is {password}");
            Console.WriteLine();
            Console.WriteLine("Is this correct? Y/N");
            string correct = Console.ReadLine();

            if (correct == "y" || correct == "Y")
            {
                users.Add(new Tuple<string, string>(userName, password));

                //foreach (var element in users)
                //{
                //    Console.WriteLine($"Username: {element.Item1} and the password is: {element.Item2}");
                //}
                //Console.ReadKey();

                Menu.Start();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Try again!");
                Console.ReadKey();
                Menu.Registy();
            }


        }

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("###########################");
            Console.WriteLine("# You Are in!             #");
            Console.WriteLine("# 1. Memberlist           #");
            Console.WriteLine("# 2. Quit                 #");
            Console.WriteLine("###########################");

            string choice2 = Console.ReadLine();

            switch (choice2)
            {
                case "1": Menu.Memberlist(); break;
                case "2": Menu.Start(); break;
                default:
                    Console.WriteLine("Please pick a number in the menu");
                    Menu.MainMenu();
                    break;
            }
        }

        public static void Memberlist()
        {
            Console.Clear();
            Console.WriteLine("#### Memberlist ####");
            Console.WriteLine();

            foreach (var element in users)
            {
                Console.WriteLine($"Username: {element.Item1} are looking for LOVE!");
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Press any key to Continue... (Hint, 'any key' isint a special key, just press on a key on you fucking keybord");
            Console.ReadKey();
            Menu.MainMenu();
        }

    }
}
