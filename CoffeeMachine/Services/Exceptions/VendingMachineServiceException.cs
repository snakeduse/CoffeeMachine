using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeMachine.Services.Exceptions
{
    public class VendingMachineServiceException : Exception
    {
        public VendingMachineServiceException()
            : base() { }

        public VendingMachineServiceException(string message)
            : base(message) { }

        public VendingMachineServiceException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public VendingMachineServiceException(string message, Exception innerException)
            : base(message, innerException) { }

        public VendingMachineServiceException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}