using CqrsCore.IQueries;

namespace CqrsCore.Test
{
    public class TestUserQuery : IQuery<bool>
    {
        public int Number { get; set; }
    }
    
    public class TestUserQueryHandler : IQueryHandler<TestUserQuery, bool>
    {
        public bool Handle(TestUserQuery query)
        {
            if (query.Number == 1)
                return true;
            return false;
        }
    }
}
