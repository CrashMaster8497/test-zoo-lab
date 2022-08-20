namespace ZooLibrary.Tests.Food
{
    public class GrassTest
    {
        [Fact]
        public void ShouldBeAbleToCreateGrass()
        {
            var grass = new ZooLibrary.Food.Grass();

            Assert.NotNull(grass);
        }
    }
}
