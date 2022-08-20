using ZooLibrary.Animals.Reptiles;

namespace ZooLibrary.Tests.Animals.Reptiles
{
    public class ReptileTest
    {
        [Theory]
        [MemberData(nameof(GenerateReptiles))]
        public void ShouldBeAbleToCreateReptile(Reptile reptile)
        {
            Assert.NotNull(reptile);
        }

        private static IEnumerable<object[]> GenerateReptiles()
        {
            yield return new object[] { new Snake() };
            //yield return new object[] { new Turtle() };
        }
    }
}
