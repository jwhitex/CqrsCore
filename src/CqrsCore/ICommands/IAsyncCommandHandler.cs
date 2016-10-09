using System.Threading.Tasks;

namespace CqrsCore.ICommands
{
    public interface IAsyncCommandHandler<in TCommand, TResult> where TCommand : IAsyncCommand<TResult>
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}