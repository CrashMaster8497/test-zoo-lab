using FluentValidation.TestHelper;
using ZooLibrary.Employees;
using ZooLibrary.Validators;

namespace ZooLibrary.Tests.Validators
{
    public class VeterinarianHireValidatorTest
    {
        private readonly VeterinarianHireValidator validator = new VeterinarianHireValidator();

        [Fact]
        public void ShouldBeAbleToValidateEmployee()
        {
            Veterinarian veterinarian = new Veterinarian();

            var result = validator.ValidateEmployee(veterinarian);

            Assert.Contains("First Name required", result);
            Assert.Contains("Last Name required", result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void ShouldReturnFirstNameRequired(string firstName)
        {
            Veterinarian veterinarian = new Veterinarian { FirstName = firstName };

            var result = validator.TestValidate(veterinarian);

            result.ShouldHaveValidationErrorFor(veterinarian => veterinarian.FirstName)
                .WithErrorMessage("First Name required");
        }

        [Fact]
        public void ShouldReturnFirstNameTooLong()
        {
            Veterinarian veterinarian = new Veterinarian { FirstName = new string('a', 51) };

            var result = validator.TestValidate(veterinarian);

            result.ShouldHaveValidationErrorFor(veterinarian => veterinarian.FirstName)
                .WithErrorMessage("First Name too long");
        }

        [Theory]
        [MemberData(nameof(GenerateFirstNames))]
        public void ShouldNotReturnWrongFirstName(string firstName)
        {
            Veterinarian veterinarian = new Veterinarian { FirstName = firstName };

            var result = validator.TestValidate(veterinarian);

            result.ShouldNotHaveValidationErrorFor(veterinarian => veterinarian.FirstName);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void ShouldReturnLastNameRequired(string lastName)
        {
            Veterinarian veterinarian = new Veterinarian { LastName = lastName };

            var result = validator.TestValidate(veterinarian);

            result.ShouldHaveValidationErrorFor(veterinarian => veterinarian.LastName)
                .WithErrorMessage("Last Name required");
        }

        [Fact]
        public void ShouldReturnLastNameTooLong()
        {
            Veterinarian veterinarian = new Veterinarian { LastName = new string('a', 51) };

            var result = validator.TestValidate(veterinarian);

            result.ShouldHaveValidationErrorFor(veterinarian => veterinarian.LastName)
                .WithErrorMessage("Last Name too long");
        }

        [Theory]
        [MemberData(nameof(GenerateLastNames))]
        public void ShouldNotReturnWrongLastName(string lastName)
        {
            Veterinarian veterinarian = new Veterinarian { LastName = lastName };

            var result = validator.TestValidate(veterinarian);

            result.ShouldNotHaveValidationErrorFor(veterinarian => veterinarian.LastName);
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
