using ZooLibrary.Animals;
using ZooLibrary.Utility;

namespace ZooLibrary.Employees
{
    public class Veterinarian : IEmployee
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<string> AnimalExperiences { get; set; } = new List<string>();

        public void AddAnimalExperience(Animal animal)
        {
            if (!HasAnimalExperience(animal))
            {
                AnimalExperiences.Add(animal.GetType().Name);
            }
        }

        public bool HasAnimalExperience(Animal animal)
        {
            return AnimalExperiences.Contains(animal.GetType().Name);
        }

        public bool HealAnimal(Animal animal)
        {
            if (!HasAnimalExperience(animal) || !animal.IsSick)
            {
                return false;
            }

            animal.IsSick = false;

            return true;
        }
    }
}
