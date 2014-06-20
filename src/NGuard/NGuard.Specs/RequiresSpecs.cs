using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGuard.Specs
{
    [TestFixture]
    public class RequiresSpecs
    {
        [Test]
        [ExpectedException(typeof(ContractViolated))]
        public void WhenConditionIsFalseThatThrowsException()
        {
            Requires.That(1 > 2);
        }

        [Test]
        public void WhenConditionIsTrueNoExceptionIsThrown()
        {
            Requires.That(2 * 2 == 4);
        }
    }
}
