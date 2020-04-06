using System.Linq;
using GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.Models;

namespace GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.PaymentProcessors
{
    public class InvoicePaymentProcessor : IPaymentProcessor
    {
        public void Finalize(Order order)
        {
            var payment = order.SelectedPayments
                .FirstOrDefault(x => x.PaymentProvider == PaymentProvider.Invoice);

            if (payment == null) return;

            order.FinalizedPayments.Add(payment);
        }
    }
}