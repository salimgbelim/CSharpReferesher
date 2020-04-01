using System;
using Xunit.Abstractions;

namespace GradeBook.Tests.MediatorPattern
{
    public class Colleague2 : Colleague
    {
        public override void HandleNotification(string message)
        {
            TestOutputHelper.WriteLine($"Colleague2 receives notification change message: {message}");
        }
    }
}