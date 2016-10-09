using System.Threading.Tasks;
using CqrsCore.IQueries;

namespace CqrsCore.Test
{
    public class TestUserAsyncQuery : IAsyncQuery<bool>
    {
        public int Number { get; set; }
    }

    public class TestUserAsyncQueryHandler : IAsyncQueryHandler<TestUserAsyncQuery, bool>
    {
        public async Task<bool> HandleAsync(TestUserAsyncQuery query)
        {
            if (query.Number == 1)
                return await Task.FromResult(true);
            return await Task.FromResult(false);
        }
    }
}