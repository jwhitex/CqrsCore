using System.Threading.Tasks;
using Autofac;
using CqrsCore.ICommands;
using CqrsCore.IQueries;

namespace CqrsCore.ICommandQueryProcessor
{
    public class CommandQueryProcessor : ICommandQueryProcessor
    {
        private readonly IContainer _container;

        public CommandQueryProcessor(IContainer container)
        {
            _container = container;
        }

        public TResult Process<TResult>(IQuery<TResult> query)
        {

            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _container.Resolve(handlerType);

            return handler.Handle((dynamic)query);
        }

        public async Task<TResult> Process<TResult>(IAsyncQuery<TResult> query)
        {

            var handlerType = typeof(IAsyncQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _container.Resolve(handlerType);

            return await handler.HandleAsync((dynamic)query);
        }

        public void Process(ICommand command)
        {

            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());

            dynamic handler = _container.Resolve(handlerType);

            handler.Handle((dynamic) command);
        }

        public async Task<TResult> Process<TResult>(IAsyncCommand<TResult> command)
        {

            var handlerType = typeof(IAsyncCommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));

            dynamic handler = _container.Resolve(handlerType);

            return await handler.HandleAsync((dynamic)command);
        }


    }
}