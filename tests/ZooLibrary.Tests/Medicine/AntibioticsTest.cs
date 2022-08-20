namespace ZooLibrary.Tests.Medicine
{
    public class AntibioticsTest
    {
        [Fact]
        public void ShouldBeAbleToCreateAntibiotics()
        {
            var antibiotics = new ZooLibrary.Medicine.Antibiotics();

            Assert.NotNull(antibiotics);
        }
    }
}
