namespace ZooLibrary.Tests.Food
{
    public class VegetablesTest
    {
        [Fact]
        public void ShouldBeAbleToCreateVegetables()
        {
            var vegetables = new ZooLibrary.Food.Vegetables();

            Assert.NotNull(vegetables);
        }
    }
}
