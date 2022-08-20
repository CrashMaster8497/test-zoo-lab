using ZooLibrary.Animals.Mammals;

namespace ZooLibrary.Tests.Animals.Mammals
{
    public class MammalTest
    {
        [Theory]
        [MemberData(nameof(GenerateMammals))]
        public void ShouldBeAbleToCreateMammal(Mammal mammal)
        {
            Assert.NotNull(mammal);
        }

        private static IEnumerable<object[]> GenerateMammals()
        {
            //yield return new object[] { new Bison() };
            //yield return new object[] { new Elephant() };
            yield return new object[] { new Lion() };
        }
    }
}
