using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace GradeBook.Tests.MediatorPattern
{
    public class ConcreteMediator : Mediator
    {
        private List<Colleague> colleagues = new List<Colleague>();

        public T CreateColleague<T>(ITestOutputHelper testOutputHelper) where T : Colleague, new()
        {
            T colleague = new T();
            colleague.SetMediator(this);
            colleague.SetTestOutputHelper(testOutputHelper);
            
            this.colleagues.Add(colleague);
            return colleague;
        }

        public override void Send(string message, Colleague colleague)
        {
            this.colleagues
                .Where(x => x != colleague)
                .ToList()
                .ForEach(c => c.HandleNotification(message));
        }
    }
}