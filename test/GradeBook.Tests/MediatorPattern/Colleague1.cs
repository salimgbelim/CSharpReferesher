using System;
using Xunit.Abstractions;

namespace GradeBook.Tests.MediatorPattern
{
    public class Colleague1 : Colleague
    {
        public override void HandleNotification(string message)
        {
            TestOutputHelper.WriteLine($"Colleague1 receives notification change message: {message}");
        }
    }
}