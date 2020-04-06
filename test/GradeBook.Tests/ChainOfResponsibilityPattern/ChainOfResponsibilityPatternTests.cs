using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.Handlers;
using GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.Handlers.PaymentHandlers;
using GradeBook.Tests.ChainOfResponsibilityPattern.PaymentProcessing.Models;
using Xunit;
using Xunit.Abstractions;

namespace GradeBook.Tests.ChainOfResponsibilityPattern
{
    public class ChainOfResponsibilityPatternTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ChainOfResponsibilityPatternTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void it_process_without_chain_of_responsibility()
        {
            // Arrange
            User user = new User("Filip Ekberg",
                "870101XXXX",
                new RegionInfo("SE"),
                new DateTimeOffset(1987, 01, 29, 00, 00, 00, TimeSpan.FromHours(2)));

            UserProcessorNoChainOfResponsibility processorNoChainOfResponsibility =
                new UserProcessorNoChainOfResponsibility();

            var result = processorNoChainOfResponsibility.Register(user);

            _testOutputHelper.WriteLine("Chain Of Responsibility : {0}", result);
        }

        [Fact]
        public void it_process_with_abstraction_based_chain_of_responsibility()
        {
            // Arrange
            User user = new User("Filip Ekberg",
                "870101XXXX",
                new RegionInfo("SE"),
                new DateTimeOffset(1987, 01, 29, 00, 00, 00, TimeSpan.FromHours(2)));

            UserProcessorWithAbstractionBasedChainOfResponsibility chainOfResponsibility =
                new UserProcessorWithAbstractionBasedChainOfResponsibility();

            var result = chainOfResponsibility.Register(user);

            _testOutputHelper.WriteLine("Chain Of Responsibility : {0}", result);
        }

        [Fact]
        public void it_process_payment_based_chain_of_responsibility()
        {
            // Arrange
            var order = new Order();
            order.LineItems.Add(new Item("ATOMOSV", "Atomos Ninja V", 499), 2);
            order.LineItems.Add(new Item("EOSR", "Canon EOS R", 1799), 1);

            order.SelectedPayments.Add(new Payment
            {
                PaymentProvider = PaymentProvider.Paypal,
                Amount = 1000
            });

            order.SelectedPayments.Add(new Payment
            {
                PaymentProvider = PaymentProvider.Invoice,
                Amount = 1797
            });

            _testOutputHelper.WriteLine($"Order Amount Due : {order.AmountDue}");
            _testOutputHelper.WriteLine($"Order Shipping Status : {order.ShippingStatus}");

            // Handle payment...Paypal --> Invoice --> Credit Card
            var receivers = new List<IReceiver<Order>>
            {
                new PaypalHandler(),
                new CreditCardHandler(),
                new InvoiceHandler()
            };

            PaymentHandler handler = new PaymentHandler(receivers);

            handler.Handle(order);

            _testOutputHelper.WriteLine($"Order Amount Due : {order.AmountDue}");
            _testOutputHelper.WriteLine($"Order Shipping Status : {order.ShippingStatus}");
        }
    }
}