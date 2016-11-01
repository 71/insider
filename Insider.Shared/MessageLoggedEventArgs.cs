using System;

namespace Insider
{
    /// <summary>
    /// Represents a message logged by a <see cref="WeaverAttribute"/>.
    /// </summary>
    public sealed class MessageLoggedEventArgs : EventArgs
    {
        /// <summary>
        /// The message logged by the weaver.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// The importance of the message logged.
        /// </summary>
        public MessageImportance Importance { get; private set; }

        /// <summary>
        /// Whether or not the message led to an error.
        /// <para>
        /// This will be <code>true</code> if <see cref="Importance"/> is
        /// <see cref="MessageImportance.Error"/>, or if <see cref="Importance"/> is
        /// <see cref="MessageImportance.Warning"/>, and <see cref="Weaver.TreatWarningsAsErrors"/>
        /// is <code>true</code>.
        /// </para>
        /// </summary>
        public bool StoppedWeaving { get; private set; }

        public string File { get; private set; }

        public int Column { get; private set; }

        public int Row { get; private set; }
        
        internal MessageLoggedEventArgs(string msg, MessageImportance i, bool stop)
        {
            Message = msg;
            Importance = i;
            StoppedWeaving = stop;
        }
    }
}
