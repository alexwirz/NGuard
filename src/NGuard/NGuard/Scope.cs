using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NGuard
{
    public class Scope
    {
        private readonly Dictionary<string, object> _snapshots = new Dictionary<string, object>();

        public Scope()
        {
        }

        public static Scope For<T>(Expression<Func<T>> valueExpression)
        {
            if (valueExpression == null)
            {
                throw new ArgumentNullException("valueExpression");
            }

            var scope = new Scope();
            scope.Capture(valueExpression);
            return scope;
        }

        public Scope And<T>(Expression<Func<T>> valueExpression)
        {
            if (valueExpression == null)
            {
                throw new ArgumentNullException("valueExpression");
            }

            Capture(valueExpression);
            return this;
        }

        public void Capture<T>(Expression<Func<T>> valueExpression)
        {
            if (valueExpression == null)
            {
                throw new ArgumentNullException("valueExpression");
            }

            var name = valueExpression.Name();
            _snapshots.Add(name, valueExpression.DeepValueClone());
        }

        public T Captured<T>(Expression<Func<T>> valueExpression)
        {
            if (valueExpression == null)
            {
                throw new ArgumentNullException("valueExpression");
            }

            var name = valueExpression.Name();
            return (T)_snapshots[name];
        }

        public CapturedValue<T> UseCaptured<T>(Expression<Func<T>> valueExpression)
        {
            if (valueExpression == null)
            {
                throw new ArgumentNullException("valueExpression");
            }

            return new CapturedValue<T>(Captured(valueExpression));
        }
    }
}
