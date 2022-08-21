using ZooLibrary;

namespace ZooApp.Tests
{
    public class ZooAppTest
    {
        [Fact]
        public void ShouldBeAbleToAddZoo()
        {
            var zooApp = new ZooApp();

            var zoo = new Zoo();
            zooApp.AddZoo(zoo);
        }

        [Fact]
        public void ShouldBeAbleToRunZooApp()
        {
            var zooApp = new ZooApp();
            zooApp.Run();
        }

        [Fact]
        public void ShouldBeAbleToRunMain()
        {
            ZooApp.Main(Array.Empty<string>());
        }
    }
}
