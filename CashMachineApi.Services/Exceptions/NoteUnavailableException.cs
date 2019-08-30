using System;

namespace CashMachineApi.Services.Exceptions
{
    public class NoteUnavailableException : Exception
    {
        public NoteUnavailableException()
        { }

        public NoteUnavailableException(string message) : base(message)
        { }

        public NoteUnavailableException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
