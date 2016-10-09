using System.Threading.Tasks;
using CqrsCore.ICommands;
using CqrsCore.IQueries;

namespace CqrsCore.ICommandQueryProcessor
{
    public interface ICommandQueryProcessor
    {
        TResult Process<TResult>(IQuery<TResult> query);

        Task<TResult> Process<TResult>(IAsyncQuery<TResult> query);

        void Process(ICommand query);

        Task<TResult> Process<TResult>(IAsyncCommand<TResult> query);
        
    }
}
