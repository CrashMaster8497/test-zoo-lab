namespace ZooLibrary.Tests.Food
{
    public class MeatTest
    {
        [Fact]
        public void ShouldBeAbleToCreateMeat()
        {
            var meat = new ZooLibrary.Food.Meat();

            Assert.NotNull(meat);
        }
    }
}
