using FluentValidation.TestHelper;
using ZooLibrary.Employees;
using ZooLibrary.Validators;

namespace ZooLibrary.Tests.Validators
{
    public class ZooKeeperHireValidatorTest
    {
        private readonly ZooKeeperHireValidator validator = new ZooKeeperHireValidator();

        [Fact]
        public void ShouldBeAbleToValidateEmployee()
        {
            ZooKeeper zooKeeper = new ZooKeeper();

            var result = validator.ValidateEmployee(zooKeeper);

            Assert.Contains("First Name required", result);
            Assert.Contains("Last Name required", result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void ShouldReturnFirstNameRequired(string firstName)
        {
            ZooKeeper zooKeeper = new ZooKeeper { FirstName = firstName };

            var result = validator.TestValidate(zooKeeper);

            result.ShouldHaveValidationErrorFor(zooKeeper => zooKeeper.FirstName)
                .WithErrorMessage("First Name required");
        }

        [Fact]
        public void ShouldReturnFirstNameTooLong()
        {
            ZooKeeper zooKeeper = new ZooKeeper { FirstName = new string('a', 51) };

            var result = validator.TestValidate(zooKeeper);

            result.ShouldHaveValidationErrorFor(zooKeeper => zooKeeper.FirstName)
                .WithErrorMessage("First Name too long");
        }

        [Theory]
        [MemberData(nameof(GenerateFirstNames))]
        public void ShouldNotReturnWrongFirstName(string firstName)
        {
            ZooKeeper zooKeeper = new ZooKeeper { FirstName = firstName };

            var result = validator.TestValidate(zooKeeper);

            result.ShouldNotHaveValidationErrorFor(zooKeeper => zooKeeper.FirstName);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void ShouldReturnLastNameRequired(string lastName)
        {
            ZooKeeper zooKeeper = new ZooKeeper { LastName = lastName };

            var result = validator.TestValidate(zooKeeper);

            result.ShouldHaveValidationErrorFor(zooKeeper => zooKeeper.LastName)
                .WithErrorMessage("Last Name required");
        }

        [Fact]
        public void ShouldReturnLastNameTooLong()
        {
            ZooKeeper zooKeeper = new ZooKeeper { LastName = new string('a', 51) };

            var result = validator.TestValidate(zooKeeper);

            result.ShouldHaveValidationErrorFor(zooKeeper => zooKeeper.LastName)
                .WithErrorMessage("Last Name too long");
        }

        [Theory]
        [MemberData(nameof(GenerateLastNames))]
        public void ShouldNotReturnWrongLastName(string lastName)
        {
            ZooKeeper zooKeeper = new ZooKeeper { LastName = lastName };

            var result = validator.TestValidate(zooKeeper);

            result.ShouldNotHaveValidationErrorFor(zooKeeper => zooKeeper.LastName);
        }

        private static IEnumerable<object[]> GenerateFirstNames()
        {
            yield return new object[] { "first" };
            yield return new object[] { new string('a', 50) };
        }

        private static IEnumerable<object[]> GenerateLastNames()
        {
            yield return new object[] { "last" };
            yield return new object[] { new string('a', 50) };
        }
    }
}
