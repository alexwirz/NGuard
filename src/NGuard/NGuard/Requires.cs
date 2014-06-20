
namespace NGuard
{
    public class Requires
    {
        private readonly string _requirementDescription;

        public Requires(string requirementDescription)
        {
            _requirementDescription = requirementDescription;
        }

        public static void That(bool condition)
        {
            Requirement.AssertIsTrue(condition, "Condition must be true");
        }

        public static Requirement Because(string requirementDescription)
        {
            return new Requirement(requirementDescription);
        }
    }
}
