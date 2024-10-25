using Recipe.Ingredients;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Recipe.WorkWithFiles
{
    public class WorkWithFile
    {
        public string path{get; } = @"C:\Users\amankeldi.kurban\Desktop\C#\Recipe\recipe.txt";
        public string path2{get; } = @"C:\Users\amankeldi.kurban\Desktop\C#\Recipe\recipe.json";
        public List<Ingredient> Choices {get;} = IngredientsAndChoices.SelectedChoices();
        public List<Ingredient> Ingredients {get;} = IngredientsAndChoices.GetIngredients();

        public bool SaveToTxt()
        {            
            string text = "";

            foreach (Ingredient choice in Choices)
            {
                text += $"{choice.Id},";
            }

            try 
            {
                text = text.Remove(text.Length - 1);
            }
            catch 
            {
                return false;
            }

            string createText = $"{text}" + Environment.NewLine;

            File.AppendAllText(path, createText);

            return true;
        }

        public void ReadFromTxt()
        {

            List<List<string>> recipesList = new List<List<string>>();
            int receiptsCount = 0; 

            foreach (string line in File.ReadAllLines(path))
            {
                recipesList.Add(line.Split(",").ToList());
            }

            for (int i=0; recipesList.Count>i; i++)
            {
                receiptsCount++; 
                Console.WriteLine($"*****{receiptsCount}*****"); 

                for (int j=0; recipesList[i].Count>j; j++)
                {
                    for (int b=0; Ingredients.Count>b; b++)
                    {
                        if(Int32.Parse(recipesList[i][j])==Ingredients[b].Id)
                        {
                            Console.WriteLine(Ingredients[b].Name + ". Add to other ingredients");
                        }
                    }
                }

                Console.WriteLine();
            }
        }

        public bool SaveToJson()
        {
            int key = 1;
            string text = "";

            Dictionary<int, string> recipes = new Dictionary<int, string>();
            List<Dictionary<int, string>> dataList;

            foreach (Ingredient choice in Choices)
            {
                text += $"{choice.Id},";
            }
            try 
            {
                text = text.Remove(text.Length - 1);
            }
            catch 
            {
                return false;
            }

            if(File.Exists(path2))
            {
                string jsonData = File.ReadAllText(path2);
                dataList =JsonConvert.DeserializeObject<List<Dictionary<int, string>>>(jsonData);
                
                if (dataList == null)
                {
                    dataList = new List<Dictionary<int, string>>();
                }
                else 
                {
                    var lastDict = dataList.LastOrDefault();
                    if (lastDict != null && lastDict.Keys.Any())
                    {
                        key = lastDict.Keys.Max() + 1;
                    }
                }
            }
            else 
            {
                dataList = new List<Dictionary<int, string>>(); 
            }

            recipes.Add(key, text);
            dataList.Add(recipes);

            string updatedJsonData = JsonConvert.SerializeObject(dataList, Formatting.Indented);
            File.WriteAllText(path2, updatedJsonData);
            return true;
        }
    
        public void ReadFromJson()
        {
            if(File.Exists(path2))
            {
                string jsonData = File.ReadAllText(path2);
                List<Dictionary<int, string>> data = JsonConvert.DeserializeObject<List<Dictionary<int, string>>>(jsonData);
                
                List<List<string>> recipesList = new List<List<string>>();
                int receiptsCount = 0; 

                for(int i=0; data.Count>i; i++)
                {
                    foreach(KeyValuePair<int, string> kvp in data[i])
                    {
                    recipesList.Add(kvp.Value.Split(",").ToList());
                    }
                }

                for (int i=0; recipesList.Count>i; i++)
                {
                    receiptsCount++; 
                    Console.WriteLine($"*****{receiptsCount}*****"); 

                    for (int j=0; recipesList[i].Count>j; j++)
                    {
                        for (int b=0; Ingredients.Count>b; b++)
                        {
                            if(Int32.Parse(recipesList[i][j])==Ingredients[b].Id)
                            {
                                Console.WriteLine(Ingredients[b].Name + ". Add to other ingredients");
                            }
                        }
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No file such as recipes.json exist");
            }
        }
    }
}