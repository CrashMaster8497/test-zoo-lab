using ZooLibrary.Animals;
using ZooLibrary.Animals.Mammals;
using ZooLibrary.Employees;

namespace ZooLibrary.Tests.Employees
{
    public class ZooKeeperTest
    {
        [Fact]
        public void ShouldBeAbleToCreateZooKeeper()
        {
            var zooKeeper = new ZooKeeper();

            Assert.NotNull(zooKeeper);
            Assert.Equal(string.Empty, zooKeeper.FirstName);
            Assert.Equal(string.Empty, zooKeeper.LastName);
            Assert.NotNull(zooKeeper.AnimalExperiences);
            Assert.IsType<List<string>>(zooKeeper.AnimalExperiences);
            Assert.Empty(zooKeeper.AnimalExperiences);
        }

        [Theory]
        [MemberData(nameof(GenerateAddExperienceData))]
        public void ShouldBeAbleToAddAnimalExperience(List<Animal> experiences, int expectedLength)
        {
            var zooKeeper = new ZooKeeper();
            foreach (Animal animal in experiences)
            {
                zooKeeper.AddAnimalExperience(animal);
            }

            Assert.Equal(expectedLength, zooKeeper.AnimalExperiences.Count);
            foreach (Animal animal in experiences)
            {
                Assert.Contains(animal.GetType().Name, zooKeeper.AnimalExperiences);
            }
        }

        [Theory]
        [MemberData(nameof(GenerateCheckExperienceData))]
        public void ShouldBeAbleToCheckAnimalExperience(List<Animal> experiences, Animal checkAnimal, bool expected)
        {
            var zooKeeper = new ZooKeeper();
            foreach (Animal animal in experiences)
            {
                zooKeeper.AddAnimalExperience(animal);
            }

            bool actual = zooKeeper.HasAnimalExperience(checkAnimal);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GenerateCheckExperienceData))]
        public void ShouldBeAbleToFeedAnimal(List<Animal> experiences, Animal checkAnimal, bool expected)
        {
            var zooKeeper = new ZooKeeper();
            foreach (Animal animal in experiences)
            {
                zooKeeper.AddAnimalExperience(animal);
            }

            bool actual = zooKeeper.FeedAnimal(checkAnimal);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldNotBeAbleToFeed3Times()
        {
            var zooKeeper = new ZooKeeper();
            var animal = new Bison();
            zooKeeper.AddAnimalExperience(animal);
            zooKeeper.FeedAnimal(animal);
            zooKeeper.FeedAnimal(animal);

            bool actual = zooKeeper.FeedAnimal(animal);

            Assert.False(actual);
        }

        private static IEnumerable<object[]> GenerateAddExperienceData()
        {
            yield return new object[]
            {
                new List<Animal> { new Bison() },
                1
            };
            yield return new object[]
            {
                new List<Animal> { new Bison(), new Elephant(), new Lion() },
                3
            };
            yield return new object[]
            {
                new List<Animal> { new Bison(), new Bison(), new Bison() },
                1
            };
        }

        private static IEnumerable<object[]> GenerateCheckExperienceData()
        {
            yield return new object[]
            {
                new List<Animal> { new Bison() },
                new Bison(),
                true
            };
            yield return new object[]
            {
                new List<Animal> { new Bison() },
                new Elephant(),
                false
            };
            yield return new object[]
            {
                new List<Animal> { new Bison(), new Elephant() },
                new Elephant(),
                true
            };
        }
    }
}
