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
    }
}
