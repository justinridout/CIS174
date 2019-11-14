using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Entities
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public int httpstatuscode { get; set; }
        public DateTime TimeOfError { get; set; }
        public int RequiestedId { get; set; }
        public string ExceptionMessage { get; set; }
        
    }
}
