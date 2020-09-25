using System;

namespace Zork
{
    class Program
    {
        private static string CurrentRoom
        {
            get
            {
                return Rooms[Location];
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while(command != Commands.QUIT)
            {
                Console.WriteLine(CurrentRoom);
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.LOOK:
                        Console.WriteLine("A rubber mat saying 'Welcome to Zork!' lies by the door.");
                        break;

                    case Commands.QUIT:
                        Console.WriteLine("Thank you for playing!");
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Move(command) == false)
                        {
                            Console.WriteLine("The way is shut!");
                        }else
                        {
                            Console.WriteLine($"You moved {command}.");
                        }
                        break;

                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }

        private static bool Move(Commands command)
        {

            bool isValidMove = true;
            switch(command)
            {
                case Commands.NORTH:
                case Commands.SOUTH:
                    isValidMove = false;
                    break;

                case Commands.EAST when Location < Rooms.Length - 1:
                    Location++;
                    break;

                case Commands.WEST when Location > 0:
                    Location--;
                    break;

                default:
                    isValidMove = false;
                    break;
            }
            return isValidMove;
        }

        private static Commands ToCommand(string commandString) => 
            Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN;

        private static string[] Rooms = { "Forest", "West of House", "Behind House", "Clearing", "Canyon View" };

        private static int Location = 1;
        
    }
}
