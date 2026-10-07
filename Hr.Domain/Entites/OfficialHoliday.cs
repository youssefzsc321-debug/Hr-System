using Hr.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Domain.Entites
{
    public class OfficialHoliday:BaseEntity
    {
        public string Name { get; set; }           
        public DateTime StartDate { get; set; }    
        public DateTime EndDate { get; set; }      
    }
}
