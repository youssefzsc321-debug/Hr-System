using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Domain.Common
{
    public static class RegexPatterns
    {
        public const string Phone = @"^01[0125][0-9]{8}$";
        public const string SalaryRegex = @"^\d+(\.\d{1,2})?$";
    }
}
