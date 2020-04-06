using System.Linq;
using GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.Models;
using GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.PaymentProcessors;

namespace GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.Handlers.PaymentHandlers
{
    public class InvoiceHandler : IReceiver<Order>
    {
        private InvoicePaymentProcessor InvoicePaymentProcessor { get; }
            = new InvoicePaymentProcessor();

        /// TODO: Implement me
        public  void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Invoice))
            {
                InvoicePaymentProcessor.Finalize(order);
            }
        }
    }
}