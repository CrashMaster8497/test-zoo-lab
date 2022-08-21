using ZooLibrary;

namespace ZooApp
{
    public class ZooApp
    {
        private List<Zoo> _zoos = new List<Zoo>();

        public void AddZoo(Zoo zoo)
        {
            _zoos.Add(zoo);
        }

        public void Run()
        {

        }

        public static void Main(string[] args)
        {
            var zooApp = new ZooApp();
            zooApp.Run();
        }
    }
}