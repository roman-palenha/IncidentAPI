using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class IncidentException : Exception
    {
        public IncidentException()
        {
            
        }

        public IncidentException(string message)
            : base(message)
        {
            
        }

        public IncidentException(string message, Exception innerException)
            : base(message, innerException)
        {
            
        }
    }
}
