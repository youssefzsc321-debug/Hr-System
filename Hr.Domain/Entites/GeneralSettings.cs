using Hr.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Domain.Entites
{
    public class GeneralSettings:BaseEntity
    {
        public decimal OverTimeVal { get; set; }
        public decimal DeducationVal { get; set; }
        public string FirstDay { get; set; }
        public string SecondDay { get; set; }

    }


}
