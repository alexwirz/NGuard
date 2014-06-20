
namespace NGuard
{
    public class Requirement
    {
        private readonly bool _condition;
        private readonly string _description;

        public Requirement(bool condition, string description)
        {
            _condition = condition;
            _description = description;
        }        

        public Requirement(string requirementDescription)
        {
            _description = requirementDescription;
        }

        public void That(bool condition)
        {
            AssertIsTrue(condition, _description);
        }

        public static void AssertIsTrue(bool condition, string description)
        {
            if (!condition)
            {
                throw new ContractViolated(description);
            }
        }
    }
}
