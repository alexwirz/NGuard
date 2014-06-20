﻿using NUnit.Framework;

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

        [Test]
        [ExpectedException(typeof(ContractViolated), ExpectedMessage = "Insanity")]
        public void WhenDescriptionPassedWithBecauseThenTheDescriptionIncludedInTheContractViolatedException()
        {
            Requires.Because("Insanity").That(1 + 1 == 1);
        }
    }
}
