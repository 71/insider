using System;
using System.Runtime.Serialization;
using Mono.Cecil.Cil;

namespace Insider
{
    /// <summary>
    /// Exception thrown internally whilst weaving an assembly.
    /// </summary>
#if !PCL
    [Serializable]
#endif
    public class InsiderException : Exception
#if !PCL
        , ISerializable
#endif
    {
        /// <summary>
        /// Initialize a new exception encountered by the Insider
        /// while processing the module.
        /// </summary>
        internal InsiderException(string msg, Exception innerException) : base(msg, innerException)
        {
        }

        /// <summary>
        /// Initialize a new exception encountered by the Insider
        /// while processing the module.
        /// </summary>
        internal InsiderException(string msg) : base(msg)
        {
        }

#if !PCL
        public InsiderException(SerializationInfo info, StreamingContext context)
            : base(info.GetString(nameof(Message)), info.GetValue(nameof(InnerException), typeof(Exception)) as Exception)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Message), Message);
            info.AddValue(nameof(InnerException), InnerException, typeof(Exception));
        }
#endif
    }

    /// <summary>
    /// Exception thrown by a 3rd party <see cref="WeaverAttribute"/>
    /// whilst processing a member or declaration.
    /// </summary>
#if !PCL
    [Serializable]
#endif
    public class WeavingException : InsiderException
#if !PCL
        , ISerializable
#endif
    {
        /// <summary>
        /// Debug information, if available, of the method that threw the error.
        /// </summary>
        public MethodDebugInformation DebugInformation { get; internal set; }

        /// <summary>
        /// Member or declaration being processed by the <see cref="Weaver"/>.
        /// </summary>
        public object Target { get; private set; }

        /// <summary>
        /// <see cref="Type"/> of the <see cref="WeaverAttribute"/> that threw the exception.
        /// </summary>
        public Type WeaverType { get; private set; }

        /// <summary>
        /// Indicates whether this <see cref="MethodWeavingException"/> was thrown
        /// using <see cref="WeaverAttribute.Log(string, MessageImportance)"/>,
        /// or by throwing an <see cref="Exception"/>.
        /// <para>
        /// <code>true</code> if this exception was thrown using
        /// <see cref="WeaverAttribute.Log(string, MessageImportance)"/>,
        /// <code>false</code> otherwise.
        /// </para>
        /// </summary>
        public bool IsIntended { get; private set; }

        /// <summary>
        /// Initialize a new exception thrown by a 3rd party
        /// method processing the module.
        /// </summary>
        internal WeavingException(string msg, object target, Type weaverType) : base(msg)
        {
            IsIntended = true;
            Target = target;
            WeaverType = weaverType;
        }

        /// <summary>
        /// Initialize a new exception thrown by a 3rd party
        /// method processing the module.
        /// </summary>
        internal WeavingException(Exception inner, object target, Type weaverType) : base(inner.Message, inner)
        {
            IsIntended = false;
            Target = target;
            WeaverType = weaverType;
        }

#if !PCL
        public WeavingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            IsIntended = info.GetBoolean(nameof(IsIntended));
            WeaverType = (Type)info.GetValue(nameof(WeaverType), typeof(Type));

            Type targetType = (Type)info.GetValue("TargetType", typeof(Type));
            Target = info.GetValue(nameof(Target), targetType);
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("TargetType", Target.GetType());
            info.AddValue(nameof(WeaverType), WeaverType);
            info.AddValue(nameof(IsIntended), IsIntended);
            info.AddValue(nameof(Target), Target, Target.GetType());
        }
#endif
    }
}
