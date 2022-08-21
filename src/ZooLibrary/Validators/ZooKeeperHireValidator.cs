using FluentValidation;
using ZooLibrary.Employees;

namespace ZooLibrary.Validators
{
    public class ZooKeeperHireValidator : AbstractValidator<ZooKeeper>, IHireValidator
    {
        const int FirstNameMaxLength = 50;
        const int LastNameMaxLength = 50;
        const string EmptyFirstName = "First Name required";
        const string LongFirstName = "First Name too long";
        const string EmptyLastName = "Last Name required";
        const string LongLastName = "Last Name too long";

        public ZooKeeperHireValidator()
        {
            RuleFor(zooKeeper => zooKeeper.FirstName)
                .NotEmpty().WithMessage(EmptyFirstName)
                .MaximumLength(FirstNameMaxLength).WithMessage(LongFirstName);
            RuleFor(zooKeeper => zooKeeper.LastName)
                .NotEmpty().WithMessage(EmptyLastName)
                .MaximumLength(LastNameMaxLength).WithMessage(LongLastName);
        }

        public List<string> ValidateEmployee(IEmployee employee)
        {
            var errors = Validate((ZooKeeper)employee).Errors;

            var result = errors.Select(error => error.ErrorMessage).ToList();

            return result;
        }
    }
}
