using GradeBook.Tests.ChainOfResponsibilityPattern.Handlers;

namespace GradeBook.Tests.ChainOfResponsibilityPattern.UserValidation
{
    public class NameValidationHandler : Handler<User>
    {
        public override void Handle(User user)
        {
            if (user.Name.Length <= 1)
            {
                throw new UserValidationException("Your name is unlikely this short.");
            }

            base.Handle(user);
        }
    }
}