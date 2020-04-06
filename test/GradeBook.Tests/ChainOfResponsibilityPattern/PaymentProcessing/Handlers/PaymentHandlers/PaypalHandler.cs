using System.Linq;
using GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.Models;
using GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.PaymentProcessors;

namespace GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.Handlers.PaymentHandlers
{
    public class PaypalHandler : IReceiver<Order>
    {
        private PaypalPaymentProcessor PaypalPaymentProcessor { get; }
            = new PaypalPaymentProcessor();

        public  void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Paypal))
            {
                PaypalPaymentProcessor.Finalize(order);
            }
        }
    }
}