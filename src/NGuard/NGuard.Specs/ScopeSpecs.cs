using NUnit.Framework;
using System.Collections.Generic;

namespace NGuard.Specs
{
    [TestFixture]
    public class ScopeSpecs
    {
        [Test]
        public void CanRetrievePreviouslyCapturedValuesFromTheScope()
        {
            var x = 42;
            var scope = new Scope();
            scope.Capture(() => x);
            x += 2;
            var previousX = scope.Captured(() => x);
            Assert.AreEqual(x - 2, previousX);
        }

        [Test]
        public void CanTrackMultipleValuesInsideTheScope()
        {
            var x = 42;
            var array = new[] { "foo", "bar", "baz" };
            var scope = Scope.For(() => x).And(() => array);
            Assert.AreEqual(x, scope.Captured(() => x));
            Assert.AreEqual(array, scope.Captured(() => array));
        }

        [Test]
        public void ScopeCapturesDeepCopies()
        {
            var list = new List<string> { "foo", "bar", "baz" };
            var scope = Scope.For(() => list);
            list.Add("another one");
            var currentCount = list.Count;
            var previousCount = scope.Captured(() => list).Count;
            Assert.IsTrue(currentCount == previousCount + 1);
        }

        [Test]
        public void UseCapturedReturnsPreviouslyCapturedValue()
        {
            var x = 42;
            var scope = Scope.For(() => x);
            Assert.AreEqual(42, scope.UseCaptured(() => x).Value);
        }

        [Test]
        [ExpectedException(typeof(ContractViolated))]
        public void EnsureUsesCapturedValueToEvaluateCondition()
        {
            var x = 42;
            var scope = Scope.For(() => x);
            scope.UseCaptured(() => x).ToEnsureThat(previousX => x == previousX + 1);
        }
    }
}
