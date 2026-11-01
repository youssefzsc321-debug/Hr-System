using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Domain.Common
{
    public static class Errors
    {
        public const string Required = "{0} is required";
        public const string PhoneRegex = "Please enter a valid phone number (11 digits)";
        public const string MinLengthForNatId = "{0} must be exactly {1} digits";
        public const string ValidSalary = "Please enter a valid salary";
        public const string WeakPassword = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.";
        public const string ConfirmPasswordNotMatch = "Password and confirmation password do not match.";
    }
}
