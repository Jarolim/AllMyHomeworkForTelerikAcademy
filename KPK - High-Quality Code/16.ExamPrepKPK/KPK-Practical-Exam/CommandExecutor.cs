using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace CatalogOfFreeContent
{
    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommand cmd, StringBuilder output)
        {
            switch (cmd.Type)
            {
                case CommandType.AddBook:
                    catalog.Add(new Content(ContentType.Book, cmd.Parameters)); 
                    output.AppendLine("Book added");
                    break;

                case CommandType.AddMovie:
                    var item = new Content(ContentType.Movie, cmd.Parameters);
                    catalog.Add(item);
                    output.AppendLine("Movie added");
                    break;

                case CommandType.AddSong:
                    catalog.Add(new Content(ContentType.Song, cmd.Parameters));
                    output.AppendLine("Song added");
                    break;

                case CommandType.AddApplication:
                    catalog.Add(new Content(ContentType.Application, cmd.Parameters));
                    output.AppendLine("Application added");
                    break;

                case CommandType.Update:
                    ProcessUpdateCommand(catalog, cmd, output);
                    break;

                case CommandType.Find:
                    ProcessFindCommand(catalog, cmd, output);
                    break;

                default:
                    throw new ArgumentException("Unknown command!");
            }
        }

        private static void ProcessUpdateCommand(ICatalog catalog, ICommand cmd, StringBuilder output)
        {
            if (cmd.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters!");
            }

            output.AppendLine(String.Format("{0} items updated",
                catalog.UpdateContent(cmd.Parameters[0], cmd.Parameters[1])));
        }

        private static void ProcessFindCommand(ICatalog catalog, ICommand cmd, StringBuilder output)
        {
            if (cmd.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters!");
            }

             int numberOfElementsToList = int.Parse(cmd.Parameters[1]);

            IEnumerable<IContent> foundContent = catalog.GetListContent(cmd.Parameters[0],
                numberOfElementsToList);

            if (foundContent.Count() == 0)
            {
                output.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    output.AppendLine(content.TextRepresentation);
                }
            }
        }
    }
}
