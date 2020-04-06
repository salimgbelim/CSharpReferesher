using System;
using System.Collections.Generic;
using GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.Models;

namespace GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.Handlers
{
    public class PaymentHandler
    {
        private readonly IList<IReceiver<Order>> receivers;

        public PaymentHandler(IList<IReceiver<Order>> receivers)
        {
            this.receivers = receivers;
        }

        public void Handle(Order order)
        {
            foreach (var receiver in this.receivers)
            {
                if (order.AmountDue > 0)
                {
                    receiver.Handle(order);
                }
                else
                {
                    break;
                }
            }

            if (order.AmountDue > 0)
            {
                throw new InsufficientPaymentException();
            }
            else
            {
                order.ShippingStatus = ShippingStatus.ReadyForShippment;
            }
        }
    }

    public class InsufficientPaymentException : Exception
    {
    }
}