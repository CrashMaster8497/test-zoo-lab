namespace ZooLibrary.Tests.Utility
{
    public class FeedTimeTest
    {
        [Fact]
        public void ShouldBeAbleToCreateFeedTime()
        {
            var feedTime = new ZooLibrary.Utility.FeedTime(dateTime: DateTime.Now, zooKeeper: new Employees.ZooKeeper());

            Assert.NotNull(feedTime);
            Assert.NotNull(feedTime.ZooKeeper);
        }
    }
}
