using ZooLibrary.Animals;
using ZooLibrary.Animals.Birds;
using ZooLibrary.Animals.Mammals;
using ZooLibrary.Animals.Reptiles;
using ZooLibrary.Employees;
using ZooLibrary.Medicine;

namespace ZooLibrary.Tests.Animals.Reptiles
{
    public class TurtleTest
    {
        [Fact]
        public void ShouldBeAbleToCreateTurtle()
        {
            var turtle = new Turtle();

            Assert.NotNull(turtle);
            Assert.Equal(5, turtle.RequiredSpaceSqFt);
            Assert.NotNull(turtle.FavoriteFood);
            Assert.True(turtle.FavoriteFood.Length == 1);
            Assert.Contains("Grass", turtle.FavoriteFood);
            Assert.NotNull(turtle.FeedTimes);
            Assert.Empty(turtle.FeedTimes);
            Assert.NotNull(turtle.FeedSchedule);
            Assert.Empty(turtle.FeedSchedule);
            Assert.False(turtle.IsSick);
        }

        [Theory]
        [MemberData(nameof(GenerateFriendlyAnimals))]
        public void ShouldBeFriendlyWith(Animal animal)
        {
            var turtle = new Turtle();

            Assert.True(turtle.IsFriendlyWith(animal));
        }

        [Theory]
        [MemberData(nameof(GenerateNotFriendlyAnimals))]
        public void ShouldNotBeFriendlyWith(Animal animal)
        {
            var turtle = new Turtle();

            Assert.False(turtle.IsFriendlyWith(animal));
        }

        [Fact]
        public void ShouldBeAbleToFeed()
        {
            var turtle = new Turtle();

            var zooKeeper = new ZooKeeper();
            zooKeeper.FeedAnimal(turtle);

            Assert.True(turtle.FeedTimes.Count == 1);
            Assert.Equal(zooKeeper, turtle.FeedTimes[0].ZooKeeper);
        }

        [Fact]
        public void ShouldNotBeAbleToFeedMoreThan2Times()
        {
            var turtle = new Turtle();

            var zooKeeper = new ZooKeeper();
            zooKeeper.FeedAnimal(turtle);
            zooKeeper.FeedAnimal(turtle);
            zooKeeper.FeedAnimal(turtle);

            Assert.True(turtle.FeedTimes.Count == 2);
        }

        [Fact]
        public void ShouldBeAbleToSetFeedSchedule()
        {
            var turtle = new Turtle();

            var schedule = new List<int> { 9, 18 };
            turtle.AddFeedSchedule(schedule);

            Assert.Equal(schedule, turtle.FeedSchedule);
        }

        [Fact]
        public void ShouldBeAbleToHeal()
        {
            var turtle = new Turtle() { IsSick = true };

            turtle.Heal(new Antibiotics());

            Assert.False(turtle.IsSick);
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
