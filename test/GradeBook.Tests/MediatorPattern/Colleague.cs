using Xunit.Abstractions;

namespace GradeBook.Tests.MediatorPattern
{
    public abstract class Colleague
    {
        public Mediator Mediator { get; set; }
        public ITestOutputHelper TestOutputHelper { get; set; }

        public void SetMediator(Mediator mediator)
        {
            this.Mediator = mediator;
        }
        
        public void SetTestOutputHelper(ITestOutputHelper testOutputHelper)
        {
            this.TestOutputHelper = testOutputHelper;
        }
       
        public virtual void Send(string message)
        {
            this.Mediator.Send(message, this);
        }

        public abstract void HandleNotification(string message);
    }
}