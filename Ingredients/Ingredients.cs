namespace Recipe.Ingredients
{
    public abstract class Ingredient
    {
        public abstract int Id { get; }
        public abstract string Name { get; }
        public abstract string Description { get; }
    }

    public class WheatFlour : Ingredient
    {
        public override int Id => 1;
        public override string Name => "Wheat flour";
        public override string Description => "Sieve.";
    }

    public class CoconutFlour : Ingredient
    {
        public override int Id => 2;
        public override string Name => "Coconut flour";
        public override string Description => "Sieve.";
    }
    
    public class Butter : Ingredient
    {
        public override int Id => 3;
        public override string Name => "Butter";
        public override string Description => "Melt on low heat.";
    }
    
    public class Chocolate : Ingredient
    {
        public override int Id => 4;
        public override string Name => "Chocolate";
        public override string Description => "Melt in a water bath.";
    }
    
    public class Sugar : Ingredient
    {
        public override int Id => 5;
        public override string Name => "Sugar";
        public override string Description => "";
    }
    
    public class Cardamom : Ingredient
    {
        public override int Id => 6;
        public override string Name => "Cardamom";
        public override string Description => "Take half a teaspoon.";
    }
    
    public class Cinnamon : Ingredient
    {
        public override int Id => 7;
        public override string Name => "Cinnamon";
        public override string Description => "Take half a teaspoon.";
    }
    
    public class CocoaPowder : Ingredient
    {
        public override int Id => 8;
        public override string Name => "Cocoa powder";
        public override string Description => "";
    }
}