using System;

namespace GradeBook.Tests.ChainOfResponsibilityPattern.UserValidation
{
    public class UserValidationException : Exception
    {
        public UserValidationException(string message) : base(message)
        {
        }
    }
}