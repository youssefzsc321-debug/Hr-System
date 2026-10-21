using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Domain.Enums
{
    public static class EnumsExtensions
    {
        public static string GetFormattedEnum(this Enum value)
        {
            return value.GetType()
             .GetMember(value.ToString())
             .First()
             .GetCustomAttribute<DisplayAttribute>()?
             .Name ?? value.ToString();
        }
    }
}
