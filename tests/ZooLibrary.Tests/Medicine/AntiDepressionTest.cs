namespace ZooLibrary.Tests.Medicine
{
    public class AntiDepressionTest
    {
        [Fact]
        public void ShouldBeAbleToCreateAntiDepression()
        {
            var antiDepression = new ZooLibrary.Medicine.AntiDepression();

            Assert.NotNull(antiDepression);
        }
    }
}
