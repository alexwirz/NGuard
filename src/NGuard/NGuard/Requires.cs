using System;

namespace NGuard
{
    public class Requires
    {
        public static void That(bool condition)
        {
            Requirement.AssertIsTrue(condition, "Condition must be true");
        }

        public static Requirement Because(string requirementDescription)
        {
            if (requirementDescription == null)
            {
                throw new ArgumentNullException("requirementDescription");            
            }

            return new Requirement(requirementDescription);
        }
    }
}
