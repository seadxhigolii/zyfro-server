using Zyfro.Pro.Server.Application.Interfaces;
using Zyfro.Pro.Server.Common.Helpers;
using Zyfro.Pro.Server.Domain.Entities.Base;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using static Zyfro.Pro.Server.Common.Constants.ValidatorMessages;

namespace Zyfro.Pro.Server.Application.Infrastructure.FluentValidator
{
    public static class FluentValidatorExtension
    {
        private static IProDbContext DbContext => AuthHelper.HttpContextAccessor.HttpContext.RequestServices.GetRequiredService<IProDbContext>();

        public static IRuleBuilderOptions<T, TProperty> NotEmptyWithMsg<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.NotEmpty().WithMessage(NotEmpty("{PropertyName}"));

        public static IRuleBuilderOptions<T, TProperty> NotNullWithMsg<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.NotNull().WithMessage(NotEmpty("{PropertyName}"));

        public static IRuleBuilderOptions<T, TProperty> IsInEnumWithMsg<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder) where TProperty : Enum
            => ruleBuilder.IsInEnum().WithMessage(NotEmpty("{PropertyName}"));

        public static IRuleBuilderOptions<T, string> MatchesWithMsg<T>(this IRuleBuilder<T, string> ruleBuilder, Regex expression)
            => ruleBuilder.Must(expression.IsMatch).WithMessage(FormatNotMatch("{PropertyName}"));

        public static IRuleBuilderOptions<T, TProperty> MatchesWithMsg<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, Func<TProperty, bool> predicate)
           => ruleBuilder.Must(predicate).WithMessage(FormatNotMatch("{PropertyName}"));

        public static IRuleBuilderOptions<T, TProperty> MatchesWithMsg<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, Func<T, TProperty, bool> predicate)
         => ruleBuilder.Must(predicate).WithMessage(FormatNotMatch("{PropertyName}"));

        public static IRuleBuilderOptions<T, string> MinLengthWithMsg<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength)
            => ruleBuilder.MinimumLength(minimumLength).WithMessage(MinLength("{PropertyName}", minimumLength));

        public static IRuleBuilderOptions<T, TProperty> DependentRule<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder, Action<IRuleBuilderInitial<T, TProperty>> dependentRuleAction)
            => ruleBuilder.DependentRules(() => dependentRuleAction((IRuleBuilderInitial<T, TProperty>)ruleBuilder));

        public static IRuleBuilderOptions<T, TProperty> AssertEntityExistWithMsg<T, TProperty, TEntity>(this IRuleBuilderInitial<T, TProperty> ruleBuilder, MessageFormatArgs messageFormat, Expression<Func<TEntity, TProperty, bool>> expression) where TEntity : class, IEntityTimeStamp
            => AssertEntityExistWithMsg(ruleBuilder, expression, messageFormat);

        public static IRuleBuilderOptions<T, TProperty> AssertEntityExistWithMsg<T, TProperty, TEntity>(this IRuleBuilderInitial<T, TProperty> ruleBuilder, MessageFormatArgs messageFormat, Expression<Func<TEntity, T, bool>> expression) where TEntity : class, IEntityTimeStamp
            => AssertEntityExistWithMsg(ruleBuilder, expression, messageFormat);

        public static IRuleBuilderOptions<T, TProperty> AssertEntityExistWithMsg<T, TProperty, TEntity>(this IRuleBuilderInitial<T, TProperty> ruleBuilder, Expression<Func<TEntity, TProperty, bool>> expression, MessageFormatArgs messageFormat = MessageFormatArgs.PropertyName) where TEntity : class, IEntityTimeStamp
            => EntityExist(ruleBuilder, expression).WithMessage(NotFound($"{{{messageFormat}}}"));

        public static IRuleBuilderOptions<T, TProperty> AssertEntityExistWithMsg<T, TProperty, TEntity>(this IRuleBuilderInitial<T, TProperty> ruleBuilder, Expression<Func<TEntity, T, bool>> expression, MessageFormatArgs messageFormat = MessageFormatArgs.PropertyName) where TEntity : class, IEntityTimeStamp
            => EntityExist(ruleBuilder, expression).WithMessage(NotFound($"{{{messageFormat}}}"));

        public static IRuleBuilderOptions<T, TProperty> AssertEntityExistUsingCollectionWithMsg<T, TProperty, TEntity>(this IRuleBuilderInitial<T, TProperty> ruleBuilder, MessageFormatArgs messageFormat, Expression<Func<TEntity, TProperty, bool>> expression) where TEntity : class, IEntityTimeStamp
           => AssertEntityExistUsingCollectionWithMsg(ruleBuilder, expression, messageFormat);

        public static IRuleBuilderOptions<T, TProperty> AssertEntityExistUsingCollectionWithMsg<T, TProperty, TEntity>(this IRuleBuilderInitial<T, TProperty> ruleBuilder, Expression<Func<TEntity, TProperty, bool>> expression, MessageFormatArgs messageFormat = MessageFormatArgs.PropertyName) where TEntity : class, IEntityTimeStamp
            => EntityExistInCollection(ruleBuilder, expression).WithMessage(NotFound($"{{{messageFormat}}}"));

        public static IRuleBuilderOptions<T, TProperty> AssertEntityMissingWithMsg<T, TProperty, TEntity>(this IRuleBuilderInitial<T, TProperty> ruleBuilder, Expression<Func<TEntity, TProperty, bool>> expression, MessageFormatArgs messageFormat = MessageFormatArgs.PropertyValue) where TEntity : class, IEntityTimeStamp
            => EntityExist(ruleBuilder, expression, true).WithMessage(AlreadyExists($"{{{messageFormat}}}"));

        public static IRuleBuilderOptions<T, TProperty> AssertEntityMissingWithMsg<T, TProperty, TEntity>(this IRuleBuilderInitial<T, TProperty> ruleBuilder, Expression<Func<TEntity, T, bool>> expression, MessageFormatArgs messageFormat = MessageFormatArgs.PropertyValue) where TEntity : class, IEntityTimeStamp
            => EntityExist(ruleBuilder, expression, true).WithMessage(AlreadyExists($"{{{messageFormat}}}"));


        private static IRuleBuilderOptions<T, TProperty> EntityExist<T, TProperty, TEntity>(this IRuleBuilderInitial<T, TProperty> ruleBuilder, Expression<Func<TEntity, TProperty, bool>> expression, bool isReverse = false) where TEntity : class, IEntityTimeStamp
        {
            return ruleBuilder.MustAsync(async (propertyValue, cancellationToken) =>
            {
                var predicateLambda = new ExpressionParameterReplacer(expression.Parameters, Expression.Constant(propertyValue))
                     .ToEntityPredicateLambda<TEntity>(expression.Body);

                bool exists = await DbContext.Set<TEntity>().AsNoTracking().AnyAsync(predicateLambda, cancellationToken: cancellationToken);

                return isReverse ? !exists : exists;
            });
        }

        private static IRuleBuilderOptions<T, TProperty> EntityExistInCollection<T, TProperty, TEntity>(this IRuleBuilderInitial<T, TProperty> ruleBuilder, Expression<Func<TEntity, TProperty, bool>> expression, bool isReverse = false) where TEntity : class, IEntityTimeStamp
        {
            IEnumerable<TEntity> entityData = DbContext.Set<TEntity>().AsNoTracking().AsEnumerable();

            return ruleBuilder.Must((propertyValue) =>
            {
                var predicateLambda = new ExpressionParameterReplacer(expression.Parameters, Expression.Constant(propertyValue))
                     .ToEntityPredicateLambda<TEntity>(expression.Body);

                bool exists = entityData.Any(predicateLambda.Compile());

                return isReverse ? !exists : exists;
            });
        }

        private static IRuleBuilderOptions<T, TProperty> EntityExist<T, TProperty, TEntity>(this IRuleBuilderInitial<T, TProperty> ruleBuilder, Expression<Func<TEntity, T, bool>> expression, bool isReverse = false) where TEntity : class, IEntityTimeStamp
        {
            return ruleBuilder.MustAsync(async (entity, propertyValue, cancellationToken) =>
            {
                var predicateLambda = new ExpressionParameterReplacer(expression.Parameters, Expression.Constant(entity))
                     .ToEntityPredicateLambda<TEntity>(expression.Body);

                bool exists = await DbContext.Set<TEntity>().AsNoTracking().AnyAsync(predicateLambda, cancellationToken: cancellationToken);

                return isReverse ? !exists : exists;
            });
        }
    }
}
