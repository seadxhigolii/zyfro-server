using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Zyfro.Pro.Server.Application.Infrastructure.FluentValidator
{
    public class ExpressionParameterReplacer : ExpressionVisitor
    {
        private readonly ReadOnlyCollection<ParameterExpression> _parameters;
        private readonly Expression _replacement;

        public ExpressionParameterReplacer(ReadOnlyCollection<ParameterExpression> parameters, Expression replacement)
        {
            _parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
            _replacement = replacement ?? throw new ArgumentNullException(nameof(replacement));
        }

        public Expression<Func<TEntity, bool>> ToEntityPredicateLambda<TEntity>(Expression expression)
        {
            var body = Visit(expression);

            return Expression.Lambda<Func<TEntity, bool>>(body, _parameters[0]);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == _parameters[1] ? _replacement : base.VisitParameter(node);
        }
    }
}
