using GradeBook.Tests.CommandPattern;
using GradeBook.Tests.CommandPattern.After;
using GradeBook.Tests.CommandPattern.Before;
using Xunit;
using Xunit.Abstractions;

namespace GradeBook.Tests.MediatorPattern
{
    public class MediatorPatternTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public MediatorPatternTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void it_sends_messages_to_colleagues_with_mediator_pattern()
        {
            // Arrange
            var mediator = new ConcreteMediator();

            var colleague1 = mediator.CreateColleague<Colleague1>(_testOutputHelper);
            var colleague2 = mediator.CreateColleague<Colleague2>(_testOutputHelper);

            colleague1.Send("Hello, world! (from colleague1)");
            colleague2.Send("Hi, there! (from colleague2)");
        }
    }
}