using System.Threading.Tasks;

namespace CqrsCore.IQueries
{
    public interface IAsyncQueryHandler<in TQuery, TResult> where TQuery : IAsyncQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}