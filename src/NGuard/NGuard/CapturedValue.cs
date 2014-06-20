using System;
using System.Linq.Expressions;

namespace NGuard
{
    public class CapturedValue<T>
    {
        public T Value { get; private set; }

        public CapturedValue(T value)
        {
            Value = value;
        }

        public void ToEnsureThat(Expression<Func<T, bool>> predicateExpression)
        {
            if (predicateExpression == null) throw new ArgumentNullException("predicateExpression");
            var predicate = predicateExpression.Compile();
            if (!predicate(Value))
            {
                throw new ContractViolated(predicateExpression.ToString());
            }
        }
    }
}
