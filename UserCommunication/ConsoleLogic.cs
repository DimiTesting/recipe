using Recipe.WorkWithFiles;

namespace Recipe.UserCommunication
{
    public class ConsoleLogic
    {
        public ConsoleReader _consoleReader;
        public WorkWithFile _workWithFiles;
        public int Choice{get; set;}
        public ConsoleLogic(ConsoleReader consoleReader, WorkWithFile workWithFiles)
        {
            _consoleReader = consoleReader;
            _workWithFiles = workWithFiles;
        }

        public bool CreateRecipe()
        {   
            Console.WriteLine(_consoleReader.WelcommingMessage);

            UserChoice();

            while(!false)
            {
                Console.WriteLine(_consoleReader.InstructionMessage);
                string userInput = Console.ReadLine();
                int result;
                
                if(int.TryParse(userInput, out result))
                {
                    if(result<=8 && result>=1)
                    {
                        for(int i=0; _workWithFiles.Ingredients.Count>i; i++)
                        {
                            if(result==_workWithFiles.Ingredients[i].Id)
                            {
                                _workWithFiles.Choices.Add(_workWithFiles.Ingredients[i]);
                            }
                        }
                    }
                    else 
                    {
                        if(_workWithFiles.Choices.Count==0)
                        {
                            Console.WriteLine("Recep has not been added");
                            return false;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Recipe Added:");
                        for(int i=0; _workWithFiles.Choices.Count>i; i++)
                        {
                            Console.WriteLine($"{_workWithFiles.Choices[i].Name}. Add to other ingredients");
                        }
                        Console.WriteLine("Press Any key to close");
                        Console.ReadLine();

                        if(Choice == 1)
                        {
                            _workWithFiles.SaveToTxt();
                            return false;
                        } 
                        else if(Choice == 2)
                        {
                            _workWithFiles.SaveToJson();
                            return false;
                        }
                        return true;
                    }
                }
                else 
                {
                    if(_workWithFiles.Choices.Count==0)
                    {
                        Console.WriteLine("Recep has not been added");
                        return false;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Recipe Added:");
                    for(int i=0; _workWithFiles.Choices.Count>i; i++)
                    {
                        Console.WriteLine($"{_workWithFiles.Choices[i].Name}. Add to other ingredients");
                    }
                    Console.WriteLine("Press Any key to close");
                    Console.ReadLine();
                    if(Choice == 1)
                    {
                        _workWithFiles.SaveToTxt();
                        return false;
                    } 
                    else if(Choice == 2)
                    {
                        _workWithFiles.SaveToJson();
                        return false;
                    }
                    return true;
                }
            }
        }
    
        public bool UserChoice()
        {
            while(!false)
            {

                string userInput = Console.ReadLine();
                int result; 

                if(int.TryParse(userInput, out result))
                {
                    Choice = result;
                    if(Choice == 1)
                    {
                        if(File.Exists(_workWithFiles.path))
                        {
                            Console.WriteLine(_consoleReader.InitialMessage);
                            _workWithFiles.ReadFromTxt();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("No existing receipts at the moment, we will create the very first one!");
                        }
                        Console.WriteLine();
                        _consoleReader.PrintMessage();

                        return false;
                    }
                    else if(Choice == 2)
                    {
                        if(File.Exists(_workWithFiles.path2))
                        {
                            Console.WriteLine(_consoleReader.InitialMessage);
                            _workWithFiles.ReadFromJson();               
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("No existing receipts at the moment, we will create the very first one!");
                        }
                        
                        Console.WriteLine();  
                        _consoleReader.PrintMessage();   
                        return false;
                    }
                    else 
                    {
                        Console.WriteLine("Please provide a valid input");
                    }
                }
                else 
                {
                    Console.WriteLine("Please provide a valid input");
                }
            }
        }
        
    }
}