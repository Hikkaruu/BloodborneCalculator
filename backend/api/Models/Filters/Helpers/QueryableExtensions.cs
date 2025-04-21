using System.Linq.Expressions;

namespace api.Models.Filters.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyRangeFilter<T, TValue>(
        this IQueryable<T> query,
        TValue? exactValue,
        TValue? minValue,
        TValue? maxValue,
        Expression<Func<T, TValue>> propertySelector)
        where TValue : struct, IComparable<TValue>
        {
            if (exactValue.HasValue)
            {
                query = query.Where(Expression.Lambda<Func<T, bool>>(
                    Expression.Equal(propertySelector.Body, Expression.Constant(exactValue.Value)),
                    propertySelector.Parameters));
            }
            else
            {
                if (minValue.HasValue)
                {
                    query = query.Where(Expression.Lambda<Func<T, bool>>(
                        Expression.GreaterThanOrEqual(propertySelector.Body, Expression.Constant(minValue.Value)),
                        propertySelector.Parameters));
                }

                if (maxValue.HasValue)
                {
                    query = query.Where(Expression.Lambda<Func<T, bool>>(
                        Expression.LessThanOrEqual(propertySelector.Body, Expression.Constant(maxValue.Value)),
                        propertySelector.Parameters));
                }
            }

            return query;
        }
    }
}
