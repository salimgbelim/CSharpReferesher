using GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.Models;

namespace GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.PaymentProcessors
{
    public interface IPaymentProcessor
    {
        void Finalize(Order order);
    }
}
