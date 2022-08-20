namespace ZooLibrary.Animals.Mammals
{
    public class Lion : Mammal
    {
        private static readonly string[] _friendlyAnimals = new string[] {
            "Lion"
        };

        public override int RequiredSpaceSqFt { get; } = 1000;
        public override string[] FavoriteFood { get; } = new string[] { "Meat" };

        public override bool IsFriendlyWith(Animal animal)
        {
            return _friendlyAnimals.Contains(animal.GetType().Name);
        }
    }
}
