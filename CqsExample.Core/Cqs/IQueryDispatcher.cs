namespace CqsExample.Core.Cqs
{
    public interface IQueryDispatcher
    {
        TResult Query<TQuery, TResult>(TQuery query)
            where TQuery : IQuery
            where TResult : IQueryResult;
    }
}