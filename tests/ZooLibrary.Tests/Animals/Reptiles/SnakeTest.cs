using ZooLibrary.Animals;
using ZooLibrary.Animals.Birds;
using ZooLibrary.Animals.Mammals;
using ZooLibrary.Animals.Reptiles;

namespace ZooLibrary.Tests.Animals.Reptiles
{
    public class SnakeTest
    {
        [Fact]
        public void ShouldBeAbleToCreateSnake()
        {
            var snake = new Snake();

            Assert.NotNull(snake);
            Assert.Equal(2, snake.RequiredSpaceSqFt);
            Assert.NotNull(snake.FavoriteFood);
            Assert.True(snake.FavoriteFood.Length == 1);
            Assert.Contains("Meat", snake.FavoriteFood);
            Assert.NotNull(snake.FeedTimes);
            Assert.Empty(snake.FeedTimes);
            Assert.NotNull(snake.FeedSchedule);
            Assert.Empty(snake.FeedSchedule);
            Assert.False(snake.IsSick);
        }

        [Theory]
        [MemberData(nameof(GenerateFriendlyAnimals))]
        public void ShouldBeFriendlyWith(Animal animal)
        {
            var snake = new Snake();

            Assert.True(snake.IsFriendlyWith(animal));
        }

        [Theory]
        [MemberData(nameof(GenerateNotFriendlyAnimals))]
        public void ShouldNotBeFriendlyWith(Animal animal)
        {
            var snake = new Snake();

            Assert.False(snake.IsFriendlyWith(animal));
        }

        [Fact]
        public void ShouldBeAbleToFeed()
        {
            var snake = new Snake();

            var zooKeeper = new Employees.ZooKeeper();
            zooKeeper.FeedAnimal(snake);

            Assert.True(snake.FeedTimes.Count == 1);
            Assert.Equal(zooKeeper, snake.FeedTimes[0].ZooKeeper);
        }

        [Fact]
        public void ShouldNotBeAbleToFeedMoreThan2Times()
        {
            var snake = new Snake();

            var zooKeeper = new Employees.ZooKeeper();
            zooKeeper.FeedAnimal(snake);
            zooKeeper.FeedAnimal(snake);
            zooKeeper.FeedAnimal(snake);

            Assert.True(snake.FeedTimes.Count == 2);
        }

        [Fact]
        public void ShouldBeAbleToSetFeedSchedule()
        {
            var snake = new Snake();

            var schedule = new List<int> { 9, 18 };
            snake.AddFeedSchedule(schedule);

            Assert.Equal(schedule, snake.FeedSchedule);
        }

        [Fact]
        public void ShouldBeAbleToHeal()
        {
            var snake = new Snake() { IsSick = true };

            snake.Heal(new ZooLibrary.Medicine.Antibiotics());

            Assert.False(snake.IsSick);
        }

        private static IEnumerable<object[]> GenerateFriendlyAnimals()
        {
            yield return new object[] { new Snake() };
        }

        private static IEnumerable<object[]> GenerateNotFriendlyAnimals()
        {
            yield return new object[] { new Bison() };
            yield return new object[] { new Elephant() };
            yield return new object[] { new Lion() };
            yield return new object[] { new Parrot() };
            yield return new object[] { new Penguin() };
            //yield return new object[] { new Turtle() };
        }
    }
}
