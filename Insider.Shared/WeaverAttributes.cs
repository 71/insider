using System;
using System.Collections.Generic;

namespace Insider
{
    /// <summary>
    /// Base class for all attributes that will "weave"
    /// an assembly.
    /// </summary>
    public abstract class WeaverAttribute : Attribute
    {
        /// <summary>
        /// <see cref="LogDelegate"/> set by the main weaver,
        /// and called internally by <see cref="Log(string, MessageImportance)"/>.
        /// </summary>
        internal LogDelegate LogInternal { get; set; }

        /// <summary>
        /// Dictionary containing all settings set by the user with the
        /// <see cref="InsiderSettingAttribute"/>.
        /// </summary>
        protected internal IReadOnlyDictionary<string, object> Settings { get; internal set; }

        /// <summary>
        /// Log a message to the build process.
        /// </summary>
        /// <param name="importance">The importance of the message</param>
        /// <param name="message">The <see cref="string"/> message to log</param>
        protected void Log(string message, MessageImportance importance)
            => LogInternal(this, message, importance);
    }
}
