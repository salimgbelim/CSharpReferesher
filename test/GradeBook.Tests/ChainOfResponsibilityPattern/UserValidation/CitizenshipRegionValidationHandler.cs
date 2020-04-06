using GradeBook.Tests.ChainOfResponsibilityPattern.Handlers;

namespace GradeBook.Tests.ChainOfResponsibilityPattern.UserValidation
{
    public class CitizenshipRegionValidationHandler : Handler<User>
    {
        public override void Handle(User user)
        {
            if (user.Region.TwoLetterISORegionName == "NO")
            {
                throw new UserValidationException("We currently do not support Norwegians");
            }
            
            base.Handle(user);
        }
    }
}