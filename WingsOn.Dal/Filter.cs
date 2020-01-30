using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WingsOn.Domain;

namespace WingsOn.Dal
{
    public class FilterBuilder<T>
        where T: DomainObject
    {
        private List<Expression<Func<T, bool>>> _expressions = new List<Expression<Func<T, bool>>>();

        public void AddExpression(Expression<Func<T, bool>> expression)
        {
            _expressions.Add(expression);
        }

        public Filter<T> Build()
        {
            return new Filter<T>(_expressions);
        }
    }

    public class Filter<T>
    {
        public Filter(IReadOnlyList<Expression<Func<T, bool>>> expressions)
        {
            WhereExpressions = expressions;
        }

        public IReadOnlyList<Expression<Func<T, bool>>> WhereExpressions { get; }
    }
}
