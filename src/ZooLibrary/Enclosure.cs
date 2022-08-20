using ZooLibrary.Animals;
using ZooLibrary.Exceptions;

namespace ZooLibrary
{
    public class Enclosure
    {
        public string Name { get; set; } = string.Empty;
        public List<Animal> Animals { get; set; } = new List<Animal>();
        public Zoo ParentZoo { get; set; } = new Zoo();
        public int SquareFeet { get; set; } = 0;

        public void AddAnimal(Animal newAnimal)
        {
            int sqFtLeft = SquareFeet;
            Animal? notFriendlyAnimal = null;
            foreach (Animal animal in Animals)
            {
                sqFtLeft -= animal.RequiredSpaceSqFt;
                if (!newAnimal.IsFriendlyWith(animal) || !animal.IsFriendlyWith(newAnimal))
                {
                    notFriendlyAnimal = animal;
                }
            }

            if (notFriendlyAnimal != null)
            {
                throw new NotFriendlyAnimalException(string.Format(
                    "Found an animal ({0}) that is not friendly with new animal ({1})",
                    notFriendlyAnimal.GetType().Name,
                    newAnimal.GetType().Name));
            }

            if (sqFtLeft < newAnimal.RequiredSpaceSqFt)
            {
                throw new NoAvailableSpaceException(string.Format(
                    "Needs {0} square feet of free space, but only {1} left",
                    newAnimal.RequiredSpaceSqFt,
                    sqFtLeft));
            }

            Animals.Add(newAnimal);
        }
    }
}
