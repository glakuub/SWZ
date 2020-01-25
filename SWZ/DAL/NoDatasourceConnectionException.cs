using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWZ.DAL
{
    class NoDatasourceConnectionException: Exception
    {
        private static readonly string _message = "Could not connect to data source. ";
        private string _optionalMessage;
        public override string Message => _message + _optionalMessage;

        public NoDatasourceConnectionException(string optionalMessage = null) {
            if (optionalMessage != null)
                _optionalMessage = optionalMessage;
        }
    }
}
