using ZooLibrary.Animals;
using ZooLibrary.Animals.Mammals;
using ZooLibrary.Exceptions;

namespace ZooLibrary.Tests
{
    public class EnclosureTest
    {
        [Fact]
        public void ShouldBeAbleToCreateEnclosure()
        {
            var enclosure = new Enclosure();

            Assert.NotNull(enclosure);
            Assert.Equal(string.Empty, enclosure.Name);
            Assert.NotNull(enclosure.Animals);
            Assert.IsType<List<Animal>>(enclosure.Animals);
            Assert.Empty(enclosure.Animals);
            Assert.NotNull(enclosure.ParentZoo);
            Assert.IsType<Zoo>(enclosure.ParentZoo);
            Assert.Equal(0, enclosure.SquareFeet);
        }

        [Fact]
        public void ShouldBeAbleToAddAnimal()
        {
            var enclosure = new Enclosure { SquareFeet = 1000 };

            var animal = new Bison();

            enclosure.AddAnimal(animal);
        }

        [Theory]
        [MemberData(nameof(GenerateDataForNoSpace))]
        public void ShouldThrowNoAvailableSpaceException(int squareFeet, List<Animal> animals, Animal newAnimal, int freeSpace)
        {
            var enclosure = new Enclosure { SquareFeet = squareFeet };

            foreach (Animal animal in animals)
            {
                enclosure.AddAnimal(animal);
            }

            var exception = Assert.Throws<NoAvailableSpaceException>(() => enclosure.AddAnimal(newAnimal));
            Assert.Equal(string.Format("Needs {0} square feet of free space, but only {1} left",
                newAnimal.RequiredSpaceSqFt, freeSpace), exception.Message);
        }

        [Theory]
        [MemberData(nameof(GenerateDataForNotFriendly))]
        public void ShouldThrowNotFriendlyAnimalException(List<Animal> animals, Animal newAnimal, string conflictAnimal)
        {
            var enclosure = new Enclosure { SquareFeet = 10000 };

            foreach (Animal animal in animals)
            {
                enclosure.AddAnimal(animal);
            }

            var exception = Assert.Throws<NotFriendlyAnimalException>(() => enclosure.AddAnimal(newAnimal));
            Assert.Equal(string.Format("Found an animal ({0}) that is not friendly with new animal ({1})",
                conflictAnimal, newAnimal.GetType().Name), exception.Message);
        }

        private static IEnumerable<object[]> GenerateDataForNoSpace()
        {
            yield return new object[]
            {
                999,
                new List<Animal> { },
                new Bison(),
                999
            };
            yield return new object[]
            {
                1999,
                new List<Animal> { new Bison() },
                new Elephant(),
                999
            };
        }

        private static IEnumerable<object[]> GenerateDataForNotFriendly()
        {
            yield return new object[]
            {
                new List<Animal> { new Bison() },
                new Lion(),
                "Bison"
            };
            yield return new object[]
            {
                new List<Animal> { new Bison(), new Elephant() },
                new Lion(),
                "Elephant"
            };
        }
    }
}
