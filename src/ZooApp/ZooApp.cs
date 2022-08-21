using ZooLibrary;
using ZooLibrary.Animals;
using ZooLibrary.Animals.Birds;
using ZooLibrary.Animals.Mammals;
using ZooLibrary.Animals.Reptiles;
using ZooLibrary.Employees;
using ZooLibrary.Exceptions;

namespace ZooApp
{
    public class ZooApp
    {
        private List<Zoo> _zoos = new List<Zoo>();

        public void AddZoo(Zoo zoo)
        {
            _zoos.Add(zoo);
        }

        public void Run()
        {
            // Add zoo
            var zoo = new Zoo { Location = "zoo1 location" };
            AddZoo(zoo);

            // Add enclosures
            zoo.AddEnclosure("enclosure1-1", 20);
            zoo.AddEnclosure("enclosure1-2", 20);
            zoo.AddEnclosure("enclosure1-3", 10);
            zoo.AddEnclosure("enclosure1-4", 1000);
            zoo.AddEnclosure("enclosure1-5", 2000);

            // Add animals
            var animals = new List<Animal>
            {
                new Bison(),
                new Elephant(),
                new Lion { IsSick = true },
                new Parrot { IsSick = true },
                new Penguin(),
                new Snake(),
                new Turtle(),
                new Bison()
            };
            foreach (var animal in animals)
            {
                Enclosure? enclosure = null;
                try
                {
                    enclosure = zoo.FindAvailableEnclosure(animal);
                }
                catch (NoAvailableEnclosureException e)
                {
                    Console.WriteLine(e);
                }

                if (enclosure != null)
                {
                    enclosure.AddAnimal(animal);
                }
            }

            // Add zoo keepers
            var zooKeepers = new List<ZooKeeper>
            {
                new ZooKeeper { FirstName = "0", LastName = "0" },
                new ZooKeeper { FirstName = "1", LastName = "1" },
                new ZooKeeper { FirstName = "2", LastName = "2" }
            };
            zooKeepers[0].AddAnimalExperience(new Bison());
            zooKeepers[0].AddAnimalExperience(new Elephant());
            zooKeepers[0].AddAnimalExperience(new Parrot());
            zooKeepers[0].AddAnimalExperience(new Penguin());
            zooKeepers[0].AddAnimalExperience(new Turtle());
            zooKeepers[1].AddAnimalExperience(new Lion());
            zooKeepers[1].AddAnimalExperience(new Penguin());
            zooKeepers[1].AddAnimalExperience(new Snake());
            zooKeepers[1].AddAnimalExperience(new Turtle());
            foreach (var zooKeeper in zooKeepers)
            {
                try
                {
                    zoo.HireEmployee(zooKeeper);
                }
                catch (NoNeededExperienceException e)
                {
                    Console.WriteLine(e);
                }
            }

            // Add veterinarians
            var veterinarians = new List<Veterinarian>
            {
                new Veterinarian { FirstName = "0", LastName = "0" },
                new Veterinarian { FirstName = "1", LastName = "1" },
                new Veterinarian { FirstName = "2", LastName = "2" }
            };
            veterinarians[0].AddAnimalExperience(new Bison());
            veterinarians[0].AddAnimalExperience(new Elephant());
            veterinarians[0].AddAnimalExperience(new Parrot());
            veterinarians[0].AddAnimalExperience(new Penguin());
            veterinarians[0].AddAnimalExperience(new Turtle());
            veterinarians[1].AddAnimalExperience(new Lion());
            veterinarians[1].AddAnimalExperience(new Penguin());
            veterinarians[1].AddAnimalExperience(new Snake());
            veterinarians[1].AddAnimalExperience(new Turtle());
            foreach (var veterinarian in veterinarians)
            {
                try
                {
                    zoo.HireEmployee(veterinarian);
                }
                catch (NoNeededExperienceException e)
                {
                    Console.WriteLine(e);
                }
            }

            // Feed
            zoo.FeedAnimals();

            // Heal
            zoo.HealAnimals();
        }

        public static void Main(string[] args)
        {
            var zooApp = new ZooApp();
            zooApp.Run();
        }
    }
}
