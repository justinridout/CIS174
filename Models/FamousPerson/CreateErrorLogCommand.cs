using CIS174_TestCoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models.FamousPerson
{
    public class CreateErrorLogCommand
    {
        public int RequestedId { get; set; }
        public int httpstatuscode { get; set; }
        public DateTime TimeOfError { get; set; }
        public string ExceptionMessage { get; set; }

        public ErrorLog ToLog()
        {
            return new ErrorLog
            {
                httpstatuscode = httpstatuscode,
                TimeOfError = TimeOfError,
                RequiestedId = RequestedId,
                ExceptionMessage = ExceptionMessage,

            };
        }
    }
}
