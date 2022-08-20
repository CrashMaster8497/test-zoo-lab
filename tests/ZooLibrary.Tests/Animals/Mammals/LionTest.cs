using ZooLibrary.Animals;
using ZooLibrary.Animals.Birds;
using ZooLibrary.Animals.Mammals;
using ZooLibrary.Animals.Reptiles;

namespace ZooLibrary.Tests.Animals.Mammals
{
    public class LionTest
    {
        [Fact]
        public void ShouldBeAbleToCreateLion()
        {
            var lion = new Lion();

            Assert.NotNull(lion);
            Assert.Equal(1000, lion.RequiredSpaceSqFt);
            Assert.NotNull(lion.FavoriteFood);
            Assert.True(lion.FavoriteFood.Count() == 1);
            Assert.Contains("Meat", lion.FavoriteFood);
            Assert.NotNull(lion.FeedTimes);
            Assert.Empty(lion.FeedTimes);
            Assert.NotNull(lion.FeedSchedule);
            Assert.Empty(lion.FeedSchedule);
            Assert.False(lion.IsSick);
        }

        [Theory]
        [MemberData(nameof(GenerateFriendlyAnimals))]
        public void ShouldBeFriendlyWith(Animal animal)
        {
            var lion = new Lion();

            Assert.True(lion.IsFriendlyWith(animal));
        }

        [Theory]
        [MemberData(nameof(GenerateNotFriendlyAnimals))]
        public void ShouldNotBeFriendlyWith(Animal animal)
        {
            var lion = new Lion();

            Assert.False(lion.IsFriendlyWith(animal));
        }

        [Fact]
        public void ShouldBeAbleToFeed()
        {
            var lion = new Lion();

            var zooKeeper = new Employees.ZooKeeper();
            zooKeeper.FeedAnimal(lion);

            Assert.True(lion.FeedTimes.Count == 1);
            Assert.Equal(zooKeeper, lion.FeedTimes[0].ZooKeeper);
        }

        [Fact]
        public void ShouldNotBeAbleToFeedMoreThan2Times()
        {
            var lion = new Lion();

            var zooKeeper = new Employees.ZooKeeper();
            zooKeeper.FeedAnimal(lion);
            zooKeeper.FeedAnimal(lion);
            zooKeeper.FeedAnimal(lion);

            Assert.True(lion.FeedTimes.Count == 2);
        }

        [Fact]
        public void ShouldBeAbleToSetFeedSchedule()
        {
            var lion = new Lion();

            var schedule = new List<int> { 9, 18 };
            lion.AddFeedSchedule(schedule);

            Assert.Equal(schedule, lion.FeedSchedule);
        }

        [Fact]
        public void ShouldBeAbleToHeal()
        {
            var lion = new Lion() { IsSick = true };

            lion.Heal(new ZooLibrary.Medicine.Antibiotics());

            Assert.False(lion.IsSick);
        }

        private static IEnumerable<object[]> GenerateFriendlyAnimals()
        {
            yield return new object[] { new Lion() };
        }

        private static IEnumerable<object[]> GenerateNotFriendlyAnimals()
        {
            yield return new object[] { new Bison() };
            //yield return new object[] { new Elephant() };
            //yield return new object[] { new Parrot() };
            //yield return new object[] { new Penguin() };
            //yield return new object[] { new Snake() };
            //yield return new object[] { new Turtle() };
        }
    }
}
