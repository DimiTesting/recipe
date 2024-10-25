using Recipe.Ingredients;
using Recipe.WorkWithFiles;
using System.Collections.Generic;  

namespace Recipe.UserCommunication
{
    public class ConsoleReader
    {
        public List<Ingredient> Ingredients {get;} = IngredientsAndChoices.GetIngredients();
        public string WelcommingMessage {get; } = 
            "The program is able to work with both file types Txt and Json.\n" +
            "Which option do you prefer?\n" +
            "Please type 1 for Txt and type 2 for Json:";
        public string InitialMessage {get; } = "Here are the existing receipts";
        public string GuideMessage {get; } = "Create a new cookie recipe! Avaliable ingredients are:";
        public string InstructionMessage {get; } = "Add an ingredient by it's Id or type anything else if finished";

    public void PrintMessage()
    {
        Console.WriteLine(GuideMessage);
        foreach(Ingredient ingredient in Ingredients)
        {
            Console.WriteLine(ingredient.Id + ". " + ingredient.Name);
        }
    }
    }
}