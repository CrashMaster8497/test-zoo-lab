namespace ZooLibrary.Animals.Mammals
{
    public class Elephant : Mammal
    {
        private static readonly string[] _friendlyAnimals = new string[]
        {
            "Bison",
            "Elephant",
            "Parrot",
            "Turtle"
        };

        public override int RequiredSpaceSqFt { get; } = 1000;
        public override string[] FavoriteFood { get; } = new string[] { "Grass" };

        public override bool IsFriendlyWith(Animal animal)
        {
            return _friendlyAnimals.Contains(animal.GetType().Name);
        }
    }
}
