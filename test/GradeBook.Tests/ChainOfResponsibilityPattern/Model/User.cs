using System;
using System.Globalization;

namespace GradeBook.Tests.ChainOfResponsibilityPattern
{
    public class User
    {
        public DateTimeOffset DateOfBirth { get; }

        public RegionInfo Region { get; }

        public string Name { get; }

        public string SocialSecurityNumber { get; }

        public int Age => (int) ((DateTimeOffset.UtcNow - DateOfBirth.UtcDateTime).TotalDays / 365);

        public User(string name, string socialSecurityNumber, RegionInfo region, DateTimeOffset dateOfBirth)
        {
            this.Name = name;
            this.SocialSecurityNumber = socialSecurityNumber;
            this.Region = region;
            this.DateOfBirth = dateOfBirth;
        }
    }
}