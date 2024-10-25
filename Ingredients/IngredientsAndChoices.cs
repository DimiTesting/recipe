namespace Recipe.Ingredients
{
    public static class IngredientsAndChoices
    {
        public static List<Ingredient> GetIngredients()
        {
            List<Ingredient> Ingredients = new List<Ingredient>
            {
                new WheatFlour(),
                new CoconutFlour(),
                new Butter(),
                new Chocolate(),
                new Sugar(),
                new Cardamom(),
                new Cinnamon(),
                new CocoaPowder()
            };
            return Ingredients;
        }  
        public static List<Ingredient> SelectedChoices()
        {
            return new List<Ingredient>();
        }
    }
}