using System;
using System.Collections.Generic;

namespace NGuard
{
    public class Requirement
    {
        private object _value;
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

        public Requirement That (object value)
        {
            _value = value;
            return this;
        }

        public CollectionRequirement ThatCollection(IEnumerable<object> collection)
        {
            return new CollectionRequirement(_description, collection);
        }

        public void IsNotNull()
        {
            AssertIsTrue(_value != null, _description);
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
