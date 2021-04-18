namespace CqsExample.Core.Cqs
{
    public interface IQueryHandler<TIn, TOut>
        where TIn : IQuery
        where TOut : IQueryResult
    {
        TOut Handle(TIn query);
    }
}