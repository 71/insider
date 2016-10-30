using System;

namespace Insider
{
    /// <summary>
    /// Exception encountered whilst weaving an assembly.
    /// </summary>
    public sealed class WeavingException : Exception
    {
        /// <summary>
        /// <see cref="WeaverAttribute"/> that sent the error.
        /// </summary>
        public WeaverAttribute Sender { get; private set; }

        /// <summary>
        /// <code>true</code> if the message was <see cref="MessageImportance.Error"/>,
        /// <code>false</code> otherwise.
        /// </summary>
        public bool IsError { get; private set; }

        /// <summary>
        /// Initialize a new exception thrown by a weaver.
        /// </summary>
        internal WeavingException(object sender, string msg, MessageImportance err) : base(msg)
        {
            Sender = sender as WeaverAttribute;
            IsError = err == MessageImportance.Error;
        }

        /// <summary>
        /// Initialize a new exception encountered while processing the module.
        /// </summary>
        internal WeavingException(string msg, Exception innerException) : base(msg, innerException)
        {
            Sender = null;
            IsError = true;
        }
    }
}
