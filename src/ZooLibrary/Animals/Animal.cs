using ZooLibrary.Utility;

namespace ZooLibrary.Animals
{
    public abstract class Animal
    {
        public abstract int RequiredSpaceSqFt { get; }
        public abstract string[] FavoriteFood { get; }
        public List<FeedTime> FeedTimes { get; } = new List<FeedTime>();
        public List<int> FeedSchedule { get; private set; } = new List<int>();
        public bool IsSick { get; set; } = false;

        public abstract bool IsFriendlyWith(Animal animal);

        public void Feed(Food.Food food)
        {

        }

        public void AddFeedSchedule(List<int> hours)
        {
            FeedSchedule = hours;
        }

        public void Heal(Medicine.Medicine medicine)
        {
            IsSick = false;
        }
    }
}
