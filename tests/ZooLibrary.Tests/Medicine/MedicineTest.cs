namespace ZooLibrary.Tests.Medicine
{
    public class MedicineTest
    {
        [Theory]
        [MemberData(nameof(GenerateMedicine))]
        public void ShouldBeAbleToCreateMedicine(ZooLibrary.Medicine.Medicine medicine)
        {
            Assert.NotNull(medicine);
        }

        private static IEnumerable<object[]> GenerateMedicine()
        {
            yield return new object[] { new ZooLibrary.Medicine.Antibiotics() };
            yield return new object[] { new ZooLibrary.Medicine.AntiDepression() };
            yield return new object[] { new ZooLibrary.Medicine.AntiInflammatory() };
        }
    }
}
