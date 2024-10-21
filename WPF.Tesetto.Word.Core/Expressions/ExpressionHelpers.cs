using System.Linq.Expressions;
using System.Reflection;

namespace WPF.Tesetto.Word.Core
{
    public static class ExpressionHelpers
    {
        public static T GetPropertyValue<T>(this Expression<Func<T>> expression)
        {
            return expression.Compile().Invoke();
        }

        public static async void SetPropertyValue<T>(this Expression<Func<T>> expression, T value)
        {
            var memberExpression = (expression as LambdaExpression).Body as MemberExpression;
            var propertyInfo = (PropertyInfo)memberExpression.Member;
            var target = Expression.Lambda(memberExpression.Expression).Compile().DynamicInvoke();

            propertyInfo.SetValue(target, value);
        }
    }
}