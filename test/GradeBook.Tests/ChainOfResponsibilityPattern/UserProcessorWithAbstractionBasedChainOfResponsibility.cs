using System;
using GradeBook.Tests.ChainOfResponsibilityPattern.UserValidation;

namespace GradeBook.Tests.ChainOfResponsibilityPattern
{
    public class UserProcessorWithAbstractionBasedChainOfResponsibility
    {
        public bool Register(User user)
        {
            try
            {
                var handler = new SocialSecurityNumberValidatorHandler();

                handler
                    .SetNext(new AgeValidationHandler())
                    .SetNext(new NameValidationHandler())
                    .SetNext(new CitizenshipRegionValidationHandler());

                handler.Handle(user);
            }
            catch (UserValidationException e)
            {
                return false;
            }

            return true;
        }
    }
}