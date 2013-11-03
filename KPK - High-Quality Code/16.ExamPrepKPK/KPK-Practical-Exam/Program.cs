using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace CatalogOfFreeContent
{
    public class Program
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder(); 
            Catalog catalog = new Catalog();
            ICommandExecutor catalogExecutor = new CommandExecutor();

            var commands = ReadInputCommands();
            foreach (ICommand cmd in commands)
            {
                catalogExecutor.ExecuteCommand(catalog, cmd, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> ReadInputCommands()
        {
            List<ICommand> commands = new List<ICommand>();
            bool endCommandFound = false;

            while (true)
            {
                string line = Console.ReadLine();
                if (line.Trim() == "End")
                {
                    break;
                }
                commands.Add(new Command(line));
            }

            return commands;
        }
    }
}
