using GradeBook.Tests.ChainOfResponsibilityPattern.Handlers;

namespace GradeBook.Tests.ChainOfResponsibilityPattern.UserValidation
{
    public class AgeValidationHandler : Handler<User>
    {
        public override void Handle(User user)
        {
            if (user.Age < 18)
            {
                throw new UserValidationException("You have to be 18 years or older");
            }
            
            base.Handle(user);
        }
    }
}