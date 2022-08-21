using ZooLibrary.Animals;
using ZooLibrary.Animals.Birds;
using ZooLibrary.Animals.Mammals;
using ZooLibrary.Animals.Reptiles;
using ZooLibrary.Employees;
using ZooLibrary.Medicine;

namespace ZooLibrary.Tests.Animals.Birds
{
    public class ParrotTest
    {
        [Fact]
        public void ShouldBeAbleToCreateParrot()
        {
            var parrot = new Parrot();

            Assert.NotNull(parrot);
            Assert.Equal(5, parrot.RequiredSpaceSqFt);
            Assert.NotNull(parrot.FavoriteFood);
            Assert.True(parrot.FavoriteFood.Length == 1);
            Assert.Contains("Vegetables", parrot.FavoriteFood);
            Assert.NotNull(parrot.FeedTimes);
            Assert.Empty(parrot.FeedTimes);
            Assert.NotNull(parrot.FeedSchedule);
            Assert.Empty(parrot.FeedSchedule);
            Assert.False(parrot.IsSick);
        }

        [Theory]
        [MemberData(nameof(GenerateFriendlyAnimals))]
        public void ShouldBeFriendlyWith(Animal animal)
        {
            var parrot = new Parrot();

            Assert.True(parrot.IsFriendlyWith(animal));
        }

        [Theory]
        [MemberData(nameof(GenerateNotFriendlyAnimals))]
        public void ShouldNotBeFriendlyWith(Animal animal)
        {
            var parrot = new Parrot();

            Assert.False(parrot.IsFriendlyWith(animal));
        }

        [Fact]
        public void ShouldBeAbleToFeed()
        {
            var parrot = new Parrot();

            var zooKeeper = new ZooKeeper();
            zooKeeper.AddAnimalExperience(parrot);
            zooKeeper.FeedAnimal(parrot);

            Assert.True(parrot.FeedTimes.Count == 1);
            Assert.Equal(zooKeeper, parrot.FeedTimes[0].ZooKeeper);
        }

        [Fact]
        public void ShouldNotBeAbleToFeedMoreThan2Times()
        {
            var parrot = new Parrot();

            var zooKeeper = new ZooKeeper();
            zooKeeper.AddAnimalExperience(parrot);
            zooKeeper.FeedAnimal(parrot);
            zooKeeper.FeedAnimal(parrot);
            zooKeeper.FeedAnimal(parrot);

            Assert.True(parrot.FeedTimes.Count == 2);
        }

        [Fact]
        public void ShouldBeAbleToSetFeedSchedule()
        {
            var parrot = new Parrot();

            var schedule = new List<int> { 9, 18 };
            parrot.AddFeedSchedule(schedule);

            Assert.Equal(schedule, parrot.FeedSchedule);
        }

        [Fact]
        public void ShouldBeAbleToHeal()
        {
            var parrot = new Parrot() { IsSick = true };

            parrot.Heal(new Antibiotics());

            Assert.False(parrot.IsSick);
        }

        private static IEnumerable<object[]> GenerateFriendlyAnimals()
        {
            yield return new object[] { new Bison() };
            yield return new object[] { new Elephant() };
            yield return new object[] { new Parrot() };
            yield return new object[] { new Turtle() };
        }

        private static IEnumerable<object[]> GenerateNotFriendlyAnimals()
        {
            yield return new object[] { new Lion() };
            yield return new object[] { new Penguin() };
            yield return new object[] { new Snake() };
        }
    }
}
