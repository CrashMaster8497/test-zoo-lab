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
                foreach (var animal in enclosure.Animals)
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

        public void HireEmployee(IEmployee employee)
        {
            bool isSuitable = false;
            foreach (var enclosure in Enclosures)
            {
                foreach (var animal in enclosure.Animals)
                {
                    if (employee is ZooKeeper zooKeeper)
                    {
                        if (zooKeeper.HasAnimalExperience(animal))
                        {
                            isSuitable = true;
                        }
                    }
                    if (employee is Veterinarian veterinarian)
                    {
                        if (veterinarian.HasAnimalExperience(animal))
                        {
                            isSuitable = true;
                        }
                    }
                }
            }

            if (!isSuitable)
            {
                throw new NoNeededExperienceException(string.Format(
                    "Can't hire an employee ({0} {1}) without suitable experiences",
                    employee.FirstName,
                    employee.LastName));
            }

            Employees.Add(employee);
        }

        public void FeedAnimals()
        {
            var animalDictionary = new Dictionary<string, List<Animal>>();
            foreach (var enclosure in Enclosures)
            {
                foreach (var animal in enclosure.Animals)
                {
                    if (!animalDictionary.ContainsKey(animal.GetType().Name))
                    {
                        animalDictionary.Add(animal.GetType().Name, new List<Animal>());
                    }
                    animalDictionary[animal.GetType().Name].Add(animal);
                }
            }

            var zooKeeperDictionary = new Dictionary<string, List<ZooKeeper>>();
            foreach (var employee in Employees)
            {
                if (employee is ZooKeeper zooKeeper)
                {
                    foreach (var animalType in zooKeeper.AnimalExperiences)
                    {
                        if (!zooKeeperDictionary.ContainsKey(animalType))
                        {
                            zooKeeperDictionary.Add(animalType, new List<ZooKeeper>());
                        }
                        zooKeeperDictionary[animalType].Add(zooKeeper);
                    }
                }
            }

            var random = Random.Shared;
            foreach (var animalType in animalDictionary.Keys)
            {
                foreach (var animal in animalDictionary[animalType])
                {
                    if (zooKeeperDictionary.ContainsKey(animalType))
                    {
                        var zooKeeper = zooKeeperDictionary[animalType][random.Next(zooKeeperDictionary[animalType].Count)];
                        zooKeeper.FeedAnimal(animal);
                    }
                }
            }
        }

        public void HealAnimals()
        {
            var animalDictionary = new Dictionary<string, List<Animal>>();
            foreach (var enclosure in Enclosures)
            {
                foreach (var animal in enclosure.Animals)
                {
                    if (!animalDictionary.ContainsKey(animal.GetType().Name))
                    {
                        animalDictionary.Add(animal.GetType().Name, new List<Animal>());
                    }
                    animalDictionary[animal.GetType().Name].Add(animal);
                }
            }

            var veterinarianDictionary = new Dictionary<string, List<Veterinarian>>();
            foreach (var employee in Employees)
            {
                if (employee is Veterinarian veterinarian)
                {
                    foreach (var animalType in veterinarian.AnimalExperiences)
                    {
                        if (!veterinarianDictionary.ContainsKey(animalType))
                        {
                            veterinarianDictionary.Add(animalType, new List<Veterinarian>());
                        }
                        veterinarianDictionary[animalType].Add(veterinarian);
                    }
                }
            }

            var random = Random.Shared;
            foreach (var animalType in animalDictionary.Keys)
            {
                foreach (var animal in animalDictionary[animalType])
                {
                    if (veterinarianDictionary.ContainsKey(animalType))
                    {
                        var veterinarian = veterinarianDictionary[animalType][random.Next(veterinarianDictionary[animalType].Count)];
                        veterinarian.HealAnimal(animal);
                    }
                }
            }
        }
    }
}
