using System;
using System.Globalization;

namespace GradeBook.Tests.ChainOfResponsibilityPattern.Validators
{
    public class SocialSecurityNumberValidator
    {
        public bool Validate(string socialSecurityNumber, RegionInfo region)
        {
            switch(region.TwoLetterISORegionName)
            {
                case "SE": return ValidateSwedishSocialSecurityNumber(socialSecurityNumber);
                case "US": return ValidateUnitedStatesSocialSecurityNumber(socialSecurityNumber);
                default: throw new UnsupportedSocialSecurityNumberException();
            }
        }
        
        private bool ValidateSwedishSocialSecurityNumber(string socialSecurityNumber)
        {
            // Not actually how it's done..

            return socialSecurityNumber.Length > 1;
        }

        private bool ValidateUnitedStatesSocialSecurityNumber(string socialSecurityNumber)
        {
            // Not actually how it's done..

            return socialSecurityNumber.Length > 2;
        }
        
        public class UnsupportedSocialSecurityNumberException : Exception
        {
        }
    }
}