using System;

namespace WebGame.Common.Exeptions
{
    public class BuisnessException : Exception
    {
        public BuisnessException() { }
        public BuisnessException(string message) : base(message)
        {
        }
    }
}
