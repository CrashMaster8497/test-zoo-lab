using ZooLibrary.Employees;

namespace ZooLibrary.Tests.Employees
{
    public class IEmployeeTest
    {
        [Theory]
        [MemberData(nameof(GenerateEmployees))]
        public void ShouldBeAbleToCreateEmployee(IEmployee employee)
        {
            Assert.NotNull(employee);
            Assert.Equal(string.Empty, employee.FirstName);
            Assert.Equal(string.Empty, employee.LastName);
        }

        private static IEnumerable<object[]> GenerateEmployees()
        {
            yield return new object[] { new ZooKeeper() };
            //yield return new object[] { new Veterinarian() };
        }
    }
}
