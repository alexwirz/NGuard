using System;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;

namespace NGuard
{
    public static class ExpressionExtensions
    {
        public static T DeepValueClone<T>(this Expression<Func<T>> valueExpression)
        {
            if (valueExpression == null)
            {
                throw new ArgumentNullException("valueExpression");
            }

            var value = valueExpression.Compile()();
            return DeepClone(value);
        }

        private static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }

        public static string Name<T>(this Expression<Func<T>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                return ConstantExpressionValue<T>(expression);
            }

            if (memberExpression.Member == null)
            {
                throw new ArgumentException("The Member property of a MemberExpression must not be null");
            }

            return memberExpression.Member.Name;
        }

        private static string ConstantExpressionValue<T>(Expression<Func<T>> expression)
        {
            var constantExpression = expression.Body as ConstantExpression;
            if (constantExpression == null)
            {
                throw new ArgumentException("Expression.Body is not of type ConstantExpression");
            }

            if (constantExpression.Value == null)
            {
                throw new ArgumentException("The Value property of a ConstantExpression must not be null");
            }

            return constantExpression.Value.ToString();
        }
    }
}
