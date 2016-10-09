using CqrsCore.ICommands;

namespace CqrsCore.Test
{
    public class TestUserCommand : ICommand
    {
        public int Number { get; set; }
    }

    public class TestUserCommandHandler : ICommandHandler<TestUserCommand>
    {
        public void Handle(TestUserCommand query)
        {
            TestUserCommandAction.Boolean = query.Number == 1;
        }
    }

    public static class TestUserCommandAction
    {
        public static bool Boolean;
    }   
}
