using ZooLibrary.Animals;
using ZooLibrary.Employees;
using ZooLibrary.Exceptions;

namespace ZooLibrary
{
    public class Zoo
    {
        public List<Enclosure> Enclosures { get; set; } = new List<Enclosure>();
        public List<IEmployee> Employees { get; set; } = new List<IEmployee>();
        public string Location { get; set; } = string.Empty;

        public Zoo() { }
        public Zoo(string location)
        {
            Location = location;
        }

        public Enclosure AddEnclosure(string name, int squareFeet)
        {
            var enclosure = new Enclosure
            {
                Name = name,
                ParentZoo = this,
                SquareFeet = squareFeet,
            };

            Enclosures.Add(enclosure);

            return enclosure;
        }

        public Enclosure FindAvailableEnclosure(Animal newAnimal)
        {
            Enclosure? availableEnclosure = null;
            foreach (var enclosure in Enclosures)
            {
                int sqFtLeft = enclosure.SquareFeet;
                Animal? notFriendlyAnimal = null;
                foreach (Animal animal in enclosure.Animals)
                {
                    sqFtLeft -= animal.RequiredSpaceSqFt;
                    if (!newAnimal.IsFriendlyWith(animal) || !animal.IsFriendlyWith(newAnimal))
                    {
                        notFriendlyAnimal = animal;
                    }
                }

                if (sqFtLeft >= newAnimal.RequiredSpaceSqFt && notFriendlyAnimal == null)
                {
                    availableEnclosure = enclosure;
                }
            }

            if (availableEnclosure == null)
            {
                throw new NoAvailableEnclosureException(string.Format(
                    "Can't find an available enclosure for animal {0}",
                    newAnimal.GetType().Name));
            }

            return availableEnclosure;
        }
    }
}
