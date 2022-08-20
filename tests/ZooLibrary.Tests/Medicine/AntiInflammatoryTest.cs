namespace ZooLibrary.Tests.Medicine
{
    public class AntiInflammatoryTest
    {
        [Fact]
        public void ShouldBeAbleToCreateAntiInflammatory()
        {
            var antiInflammatory = new ZooLibrary.Medicine.AntiInflammatory();

            Assert.NotNull(antiInflammatory);
        }
    }
}
