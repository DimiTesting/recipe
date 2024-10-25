using Recipe.Ingredients;
using Recipe.UserCommunication;
using Recipe.WorkWithFiles;
using System.IO;

namespace Recipe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleReader consoleReader = new ConsoleReader();
            WorkWithFile workWithFile = new WorkWithFile();
            ConsoleLogic consoleLogic = new ConsoleLogic(consoleReader, workWithFile);
            consoleLogic.CreateRecipe();
        }
    }
}