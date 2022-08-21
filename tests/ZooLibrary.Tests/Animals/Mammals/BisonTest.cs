using ZooLibrary.Animals;
using ZooLibrary.Animals.Birds;
using ZooLibrary.Animals.Mammals;
using ZooLibrary.Animals.Reptiles;
using ZooLibrary.Employees;
using ZooLibrary.Medicine;

namespace ZooLibrary.Tests.Animals.Mammals
{
    public class BisonTest
    {
        [Fact]
        public void ShouldBeAbleToCreateBison()
        {
            var bison = new Bison();

            Assert.NotNull(bison);
            Assert.Equal(1000, bison.RequiredSpaceSqFt);
            Assert.NotNull(bison.FavoriteFood);
            Assert.True(bison.FavoriteFood.Length == 1);
            Assert.Contains("Grass", bison.FavoriteFood);
            Assert.NotNull(bison.FeedTimes);
            Assert.Empty(bison.FeedTimes);
            Assert.NotNull(bison.FeedSchedule);
            Assert.Empty(bison.FeedSchedule);
            Assert.False(bison.IsSick);
        }

        [Theory]
        [MemberData(nameof(GenerateFriendlyAnimals))]
        public void ShouldBeFriendlyWith(Animal animal)
        {
            var bison = new Bison();

            Assert.True(bison.IsFriendlyWith(animal));
        }

        [Theory]
        [MemberData(nameof(GenerateNotFriendlyAnimals))]
        public void ShouldNotBeFriendlyWith(Animal animal)
        {
            var bison = new Bison();

            Assert.False(bison.IsFriendlyWith(animal));
        }

        [Fact]
        public void ShouldBeAbleToFeed()
        {
            var bison = new Bison();

            var zooKeeper = new ZooKeeper();
            zooKeeper.AddAnimalExperience(bison);
            zooKeeper.FeedAnimal(bison);

            Assert.True(bison.FeedTimes.Count == 1);
            Assert.Equal(zooKeeper, bison.FeedTimes[0].ZooKeeper);
        }

        [Fact]
        public void ShouldNotBeAbleToFeedMoreThan2Times()
        {
            var bison = new Bison();

            var zooKeeper = new ZooKeeper();
            zooKeeper.AddAnimalExperience(bison);
            zooKeeper.FeedAnimal(bison);
            zooKeeper.FeedAnimal(bison);
            zooKeeper.FeedAnimal(bison);

            Assert.True(bison.FeedTimes.Count == 2);
        }

        [Fact]
        public void ShouldBeAbleToSetFeedSchedule()
        {
            var bison = new Bison();

            var schedule = new List<int> { 9, 18 };
            bison.AddFeedSchedule(schedule);

            Assert.Equal(schedule, bison.FeedSchedule);
        }

        [Fact]
        public void ShouldBeAbleToHeal()
        {
            var bison = new Bison() { IsSick = true };

            bison.Heal(new Antibiotics());

            Assert.False(bison.IsSick);
        }

        private static IEnumerable<object[]> GenerateFriendlyAnimals()
        {
            yield return new object[] { new Bison() };
            yield return new object[] { new Elephant() };
        }

        private static IEnumerable<object[]> GenerateNotFriendlyAnimals()
        {
            yield return new object[] { new Lion() };
            yield return new object[] { new Parrot() };
            yield return new object[] { new Penguin() };
            yield return new object[] { new Snake() };
            yield return new object[] { new Turtle() };
        }
    }
}
