using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.Models
{
    class DataServiceException : Exception
    {
        private static readonly string _message = "Could not use data service. ";
        private string _optionalMessage;
        public override string Message => _message + _optionalMessage;

        public DataServiceException(string optionalMessage = null)
        {
            if (optionalMessage != null)
                _optionalMessage = optionalMessage;
        }
    }
}
