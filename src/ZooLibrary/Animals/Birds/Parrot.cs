namespace ZooLibrary.Animals.Birds
{
    public class Parrot : Bird
    {
        private static readonly string[] _friendlyAnimals = new string[]
        {
            "Bison",
            "Elephant",
            "Parrot",
            "Turtle"
        };

        public override int RequiredSpaceSqFt { get; } = 5;
        public override string[] FavoriteFood { get; } = new string[] { "Vegetables" };

        public override bool IsFriendlyWith(Animal animal)
        {
            return _friendlyAnimals.Contains(animal.GetType().Name);
        }
    }
}
