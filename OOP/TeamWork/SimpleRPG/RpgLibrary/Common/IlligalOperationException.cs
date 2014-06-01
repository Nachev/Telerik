namespace TankWarsLibrary.Common
{
    using System;
   
    public class IlligalOperationException : ApplicationException
    {
        public IlligalOperationException(string message)
            : base()
        {
            
        }

        public IlligalOperationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

    }
}
