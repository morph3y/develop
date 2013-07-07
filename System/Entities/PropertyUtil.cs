using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Entities
{
    public static class PropertyUtil
    {
        public static string GetPropertyName<T>(Expression<Func<T, object>> propertyRefExpr)
        {
            if (propertyRefExpr == null)
            {
                throw new ArgumentNullException("propertyRefExpr", "propertyRefExpr is null.");
            }
            var memberExpr = propertyRefExpr.Body as MemberExpression;
            if (memberExpr == null)
            {
                var unaryExpr = propertyRefExpr.Body as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                {
                    memberExpr = unaryExpr.Operand as MemberExpression;
                }
            }
            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
            {
                return memberExpr.Member.Name;
            }
            throw new ArgumentException("No property reference expression was found.", "propertyRefExpr");
        }
    }
}
