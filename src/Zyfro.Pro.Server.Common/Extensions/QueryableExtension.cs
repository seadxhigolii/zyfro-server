using NinjaNye.SearchExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Asp.Nappox.School.Common.Extensions
{
    public static class QueryableExtension
    {
        public static IQueryable<T> SearchFromInput<T>(this IQueryable<T> query, string value, params Expression<Func<T, string>>[] stringExpressions)
        {
            if (string.IsNullOrEmpty(value)) return query;

            string[] searchParams = value.Trim().Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(x => x.ToLower()).ToArray();

            var toLowerExpressions = ToLowerExpressions(stringExpressions).ToArray();

            var queryRes = query.Search(toLowerExpressions).StartsWith(searchParams);

            return queryRes;
        }

        private static IEnumerable<Expression<Func<T, string>>> ToLowerExpressions<T>(Expression<Func<T, string>>[] stringExpressions)
        {
            foreach (var stringExpression in stringExpressions)
            {
                var propertyAccess = stringExpression.Body;

                // Get the ToLower() method of the string type.
                var toLowerMethod = typeof(string).GetMethod("ToLower", Array.Empty<Type>());

                // Convert the property value to lowercase.
                var toLowerCaseExp = Expression.Call(propertyAccess, toLowerMethod);

                yield return Expression.Lambda<Func<T, string>>(toLowerCaseExp, stringExpression.Parameters[0]);
            }
        }

        public static IQueryable<T> SkipAndTake<T>(this IQueryable<T> query, int page, int pageSize, out int totalPages, out int totalItems)
        {
            var total = totalItems = query.Count();

            if (page <= 0 || pageSize <= 0)
            {
                totalPages = 1;
                return query.Skip(0);
            }

            else totalPages = (int)Math.Ceiling(total / (double)pageSize);

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
