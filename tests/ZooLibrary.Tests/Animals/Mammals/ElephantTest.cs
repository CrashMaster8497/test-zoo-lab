using ZooLibrary.Animals;
using ZooLibrary.Animals.Birds;
using ZooLibrary.Animals.Mammals;
using ZooLibrary.Animals.Reptiles;

namespace ZooLibrary.Tests.Animals.Mammals
{
    public class ElephantTest
    {
        [Fact]
        public void ShouldBeAbleToCreateElephant()
        {
            var elephant = new Elephant();

            Assert.NotNull(elephant);
            Assert.Equal(1000, elephant.RequiredSpaceSqFt);
            Assert.NotNull(elephant.FavoriteFood);
            Assert.True(elephant.FavoriteFood.Length == 1);
            Assert.Contains("Grass", elephant.FavoriteFood);
            Assert.NotNull(elephant.FeedTimes);
            Assert.Empty(elephant.FeedTimes);
            Assert.NotNull(elephant.FeedSchedule);
            Assert.Empty(elephant.FeedSchedule);
            Assert.False(elephant.IsSick);
        }

        [Theory]
        [MemberData(nameof(GenerateFriendlyAnimals))]
        public void ShouldBeFriendlyWith(Animal animal)
        {
            var elephant = new Elephant();

            Assert.True(elephant.IsFriendlyWith(animal));
        }

        [Theory]
        [MemberData(nameof(GenerateNotFriendlyAnimals))]
        public void ShouldNotBeFriendlyWith(Animal animal)
        {
            var elephant = new Elephant();

            Assert.False(elephant.IsFriendlyWith(animal));
        }

        [Fact]
        public void ShouldBeAbleToFeed()
        {
            var elephant = new Elephant();

            var zooKeeper = new Employees.ZooKeeper();
            zooKeeper.FeedAnimal(elephant);

            Assert.True(elephant.FeedTimes.Count == 1);
            Assert.Equal(zooKeeper, elephant.FeedTimes[0].ZooKeeper);
        }

        [Fact]
        public void ShouldNotBeAbleToFeedMoreThan2Times()
        {
            var elephant = new Elephant();

            var zooKeeper = new Employees.ZooKeeper();
            zooKeeper.FeedAnimal(elephant);
            zooKeeper.FeedAnimal(elephant);
            zooKeeper.FeedAnimal(elephant);

            Assert.True(elephant.FeedTimes.Count == 2);
        }

        [Fact]
        public void ShouldBeAbleToSetFeedSchedule()
        {
            var elephant = new Elephant();

            var schedule = new List<int> { 9, 18 };
            elephant.AddFeedSchedule(schedule);

            Assert.Equal(schedule, elephant.FeedSchedule);
        }

        [Fact]
        public void ShouldBeAbleToHeal()
        {
            var elephant = new Elephant() { IsSick = true };

            elephant.Heal(new ZooLibrary.Medicine.Antibiotics());

            Assert.False(elephant.IsSick);
        }

        private static IEnumerable<object[]> GenerateFriendlyAnimals()
        {
            yield return new object[] { new Bison() };
            yield return new object[] { new Elephant() };
            //yield return new object[] { new Parrot() };
            //yield return new object[] { new Turtle() };
        }

        private static IEnumerable<object[]> GenerateNotFriendlyAnimals()
        {
            yield return new object[] { new Lion() };
            //yield return new object[] { new Penguin() };
            //yield return new object[] { new Snake() };
        }
    }
}
