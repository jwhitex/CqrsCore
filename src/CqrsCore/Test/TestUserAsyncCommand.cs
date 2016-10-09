using System.Threading.Tasks;
using CqrsCore.ICommands;

namespace CqrsCore.Test
{
    public class TestUserAsyncCommand : IAsyncCommand<bool>
    {
        public int Number { get; set; }
    }

    public class TestUserAsyncCommandHandler : IAsyncCommandHandler<TestUserAsyncCommand, bool>
    {
        public async Task<bool> HandleAsync(TestUserAsyncCommand query)
        {
            if (query.Number == 1)
                return await Task.FromResult(true);
            return await Task.FromResult(false);
        }
    }
}