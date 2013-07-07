using System.Collections.Generic;
using Entities.Expression.Common;
using NHibernate.Criterion;

namespace DAL.Expressions
{
    internal sealed class CriteraFactory
    {
        private readonly Dictionary<ExpressionType, ICriterion> _repository = new Dictionary<ExpressionType, ICriterion>();

        public CriteraFactory(string lhv, string rhv)
        {
            _repository.Add(ExpressionType.Equals, Restrictions.Eq(lhv, rhv));
            _repository.Add(ExpressionType.NotEquals, Restrictions.Not(Restrictions.Eq(lhv, rhv)));
            _repository.Add(ExpressionType.Like, Restrictions.Like(lhv, rhv));
        }

        public ICriterion Get(ExpressionType type)
        {
            ICriterion toReturn;
            if (_repository.TryGetValue(type, out toReturn))
            {
                return toReturn;
            }
            return null;
        }
    }
}
