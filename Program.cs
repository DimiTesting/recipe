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
            try
            {
                ConsoleReader consoleReader = new ConsoleReader();
                WorkWithFile workWithFile = new WorkWithFile();
                ConsoleLogic consoleLogic = new ConsoleLogic(consoleReader, workWithFile);
                consoleLogic.CreateRecipe();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Sorry! The application experienced an unexpected error and will be closed" + 
                "The error message is" + ex.Message);
                Console.WriteLine("Press any key to close.");
                Console.ReadKey();
            }
        }
    }
}