using System;
using System.Runtime.Serialization;

namespace Insider
{
    /// <summary>
    /// Exception encountered whilst weaving an assembly.
    /// </summary>
#if !PCL
    [Serializable]
#endif
    public sealed class WeavingException : Exception
#if !PCL
        , ISerializable
#endif
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

#if !PCL
        public WeavingException(SerializationInfo info, StreamingContext context)
            : base(info.GetString("msg"), info.GetValue("inner", typeof(Exception)) as Exception)
        {
            IsError = info.GetBoolean("iserror");
            Sender = info.GetValue("sender", typeof(WeaverAttribute)) as WeaverAttribute;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("iserror", IsError);
            info.AddValue("sender", Sender, typeof(WeaverAttribute));
            info.AddValue("msg", Message);
            info.AddValue("inner", InnerException, typeof(Exception));
        }
#endif
    }
}
