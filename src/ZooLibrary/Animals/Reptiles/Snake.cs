namespace ZooLibrary.Animals.Reptiles
{
    public class Snake : Reptile
    {
        private static readonly string[] _friendlyAnimals = new string[]
        {
            "Snake"
        };

        public override int RequiredSpaceSqFt { get; } = 2;
        public override string[] FavoriteFood { get; } = new string[] { "Meat" };

        public override bool IsFriendlyWith(Animal animal)
        {
            return _friendlyAnimals.Contains(animal.GetType().Name);
        }
    }
}
