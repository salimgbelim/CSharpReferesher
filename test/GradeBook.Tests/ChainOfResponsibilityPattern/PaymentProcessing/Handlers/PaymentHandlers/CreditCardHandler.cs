using System.Linq;
using GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.Models;
using GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.PaymentProcessors;

namespace GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.Handlers.PaymentHandlers
{
    public class CreditCardHandler : IReceiver<Order>
    {
        private CreditCardPaymentProcessor CreditCardPaymentProcessor { get; }
            = new CreditCardPaymentProcessor();

        public void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.CreditCard))
            {
                CreditCardPaymentProcessor.Finalize(order);
            }
        }
    }
}