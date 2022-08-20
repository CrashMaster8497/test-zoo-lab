using ZooLibrary.Employees;
using ZooLibrary.Utility;

namespace ZooLibrary.Tests.Utility
{
    public class FeedTimeTest
    {
        [Fact]
        public void ShouldBeAbleToCreateFeedTime()
        {
            var feedTime = new FeedTime(dateTime: DateTime.Now, zooKeeper: new ZooKeeper());

            Assert.NotNull(feedTime);
            Assert.NotNull(feedTime.ZooKeeper);
        }
    }
}
