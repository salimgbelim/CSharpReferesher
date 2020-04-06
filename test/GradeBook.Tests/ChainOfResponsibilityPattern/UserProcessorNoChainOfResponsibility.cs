using GradeBook.Tests.ChainOfResponsibilityPattern.Validators;

namespace GradeBook.Tests.ChainOfResponsibilityPattern
{
    public class UserProcessorNoChainOfResponsibility
    {
        private readonly SocialSecurityNumberValidator SocialSecurityNumberValidator
            = new SocialSecurityNumberValidator();

        public bool Register(User user)
        {
            if (!SocialSecurityNumberValidator.Validate(user.SocialSecurityNumber, user.Region))
            {
                return false;
            }
            else if (user.Age < 18)
            {
                return false;
            }
            else if (user.Name.Length <= 1)
            {
                return false;
            }
            else if (user.Region.TwoLetterISORegionName == "NO")
            {
                return false;
            }

            return true;
        }
    }
}