namespace ZooLibrary.Tests.Food
{
    public class FoodTest
    {
        [Theory]
        [MemberData(nameof(GenerateFood))]
        public void ShouldBeAbleToCreateFood(ZooLibrary.Food.Food food)
        {
            Assert.NotNull(food);
        }

        private static IEnumerable<object[]> GenerateFood()
        {
            yield return new object[] { new ZooLibrary.Food.Grass() };
            yield return new object[] { new ZooLibrary.Food.Vegetables() };
            yield return new object[] { new ZooLibrary.Food.Meat() };
        }
    }
}
