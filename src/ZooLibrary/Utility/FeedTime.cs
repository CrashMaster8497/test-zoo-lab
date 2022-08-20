using ZooLibrary.Employees;

namespace ZooLibrary.Utility
{
    public class FeedTime
    {
        public readonly DateTime DateTime;
        public readonly ZooKeeper ZooKeeper;

        public FeedTime(DateTime dateTime, ZooKeeper zooKeeper)
        {
            DateTime = dateTime;
            ZooKeeper = zooKeeper;
        }
    }
}
