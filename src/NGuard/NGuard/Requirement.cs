using System;

namespace NGuard
{
    public class Requirement
    {
        private readonly bool _condition;
        private readonly string _description;

        public Requirement(string requirementDescription)
        {
            if (requirementDescription == null)
            {
                throw new ArgumentNullException("requirementDescription");
            }

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
