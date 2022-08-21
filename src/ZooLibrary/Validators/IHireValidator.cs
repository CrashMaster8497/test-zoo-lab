using ZooLibrary.Employees;

namespace ZooLibrary.Validators
{
    public interface IHireValidator
    {
        public List<string> ValidateEmployee(IEmployee employee);
    }
}
