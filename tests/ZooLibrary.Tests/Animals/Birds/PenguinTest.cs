using ZooLibrary.Animals;
using ZooLibrary.Animals.Birds;
using ZooLibrary.Animals.Mammals;
using ZooLibrary.Animals.Reptiles;

namespace ZooLibrary.Tests.Animals.Birds
{
    public class PenguinTest
    {
        [Fact]
        public void ShouldBeAbleToCreatePenguin()
        {
            var penguin = new Penguin();

            Assert.NotNull(penguin);
            Assert.Equal(10, penguin.RequiredSpaceSqFt);
            Assert.NotNull(penguin.FavoriteFood);
            Assert.True(penguin.FavoriteFood.Length == 1);
            Assert.Contains("Meat", penguin.FavoriteFood);
            Assert.NotNull(penguin.FeedTimes);
            Assert.Empty(penguin.FeedTimes);
            Assert.NotNull(penguin.FeedSchedule);
            Assert.Empty(penguin.FeedSchedule);
            Assert.False(penguin.IsSick);
        }

        [Theory]
        [MemberData(nameof(GenerateFriendlyAnimals))]
        public void ShouldBeFriendlyWith(Animal animal)
        {
            var penguin = new Penguin();

            Assert.True(penguin.IsFriendlyWith(animal));
        }

        [Theory]
        [MemberData(nameof(GenerateNotFriendlyAnimals))]
        public void ShouldNotBeFriendlyWith(Animal animal)
        {
            var penguin = new Penguin();

            Assert.False(penguin.IsFriendlyWith(animal));
        }

        [Fact]
        public void ShouldBeAbleToFeed()
        {
            var penguin = new Penguin();

            var zooKeeper = new Employees.ZooKeeper();
            zooKeeper.FeedAnimal(penguin);

            Assert.True(penguin.FeedTimes.Count == 1);
            Assert.Equal(zooKeeper, penguin.FeedTimes[0].ZooKeeper);
        }

        [Fact]
        public void ShouldNotBeAbleToFeedMoreThan2Times()
        {
            var penguin = new Penguin();

            var zooKeeper = new Employees.ZooKeeper();
            zooKeeper.FeedAnimal(penguin);
            zooKeeper.FeedAnimal(penguin);
            zooKeeper.FeedAnimal(penguin);

            Assert.True(penguin.FeedTimes.Count == 2);
        }

        [Fact]
        public void ShouldBeAbleToSetFeedSchedule()
        {
            var penguin = new Penguin();

            var schedule = new List<int> { 9, 18 };
            penguin.AddFeedSchedule(schedule);

            Assert.Equal(schedule, penguin.FeedSchedule);
        }

        [Fact]
        public void ShouldBeAbleToHeal()
        {
            var penguin = new Penguin() { IsSick = true };

            penguin.Heal(new ZooLibrary.Medicine.Antibiotics());

            Assert.False(penguin.IsSick);
        }

        private static IEnumerable<object[]> GenerateFriendlyAnimals()
        {
            yield return new object[] { new Penguin() };
        }

        private static IEnumerable<object[]> GenerateNotFriendlyAnimals()
        {
            yield return new object[] { new Bison() };
            yield return new object[] { new Elephant() };
            yield return new object[] { new Lion() };
            yield return new object[] { new Parrot() };
            //yield return new object[] { new Snake() };
            //yield return new object[] { new Turtle() };
        }
    }
}
