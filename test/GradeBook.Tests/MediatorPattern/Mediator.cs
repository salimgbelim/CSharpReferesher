namespace GradeBook.Tests.MediatorPattern
{
    public abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }
}