using GradeBook.Tests.ChainOfResponsibilityPattern.Handlers;
using GradeBook.Tests.ChainOfResponsibilityPattern.Validators;

namespace GradeBook.Tests.ChainOfResponsibilityPattern.UserValidation
{
    public class SocialSecurityNumberValidatorHandler : Handler<User>
    {
        private readonly SocialSecurityNumberValidator SocialSecurityNumberValidator
            = new SocialSecurityNumberValidator();
        public override void Handle(User user)
        {
            if (!SocialSecurityNumberValidator.Validate(user.SocialSecurityNumber, user.Region))
            {
                throw new UserValidationException("Social security number could not be valid");
            }
            
            base.Handle(user);
        }
    }
}