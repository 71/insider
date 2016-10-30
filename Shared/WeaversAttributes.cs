using System;
using System.Collections.Generic;
using Mono.Cecil;

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

    /// <summary>
    /// Base class for all attributes that will weave assemblies.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = true)]
    public abstract class AssemblyWeaverAttribute : WeaverAttribute
    {
        /// <summary>
        /// Begin weaving an <see cref="AssemblyDefinition"/>.
        /// </summary>
        public abstract void Apply(AssemblyDefinition assembly);
    }

    /// <summary>
    /// Base class for all attributes that will weave methods.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodWeaverAttribute : WeaverAttribute
    {
        /// <summary>
        /// Begin weaving a <see cref="MethodDefinition"/>.
        /// </summary>
        public abstract void Apply(MethodDefinition method);
    }

    /// <summary>
    /// Base class for all attributes that will weave properties.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public abstract class PropertyWeaverAttribute : WeaverAttribute
    {
        /// <summary>
        /// Begin weaving a <see cref="PropertyDefinition"/>.
        /// </summary>
        public abstract void Apply(PropertyDefinition property);
    }

    /// <summary>
    /// Base class for all attributes that will weave types (classes and interfaces).
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
    public abstract class TypeWeaverAttribute : WeaverAttribute
    {
        /// <summary>
        /// Begin weaving a <see cref="TypeDefinition"/>.
        /// </summary>
        public abstract void Apply(TypeDefinition type);
    }

    /// <summary>
    /// Base class for all attributes that will weave events.
    /// </summary>
    [AttributeUsage(AttributeTargets.Event, AllowMultiple = true, Inherited = true)]
    public abstract class EventWeaverAttribute : WeaverAttribute
    {
        /// <summary>
        /// Begin weaving an <see cref="EventDefinition"/>.
        /// </summary>
        public abstract void Apply(EventDefinition @event);
    }

    /// <summary>
    /// Base class for all attributes that will weave fields.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public abstract class FieldWeaverAttribute : WeaverAttribute
    {
        /// <summary>
        /// Begin weaving a <see cref="FieldDefinition"/>.
        /// </summary>
        public abstract void Apply(FieldDefinition field);
    }

    /// <summary>
    /// Base class for all attributes that will weaves parameters.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true, Inherited = true)]
    public abstract class ParameterWeaverAttribute : WeaverAttribute
    {
        /// <summary>
        /// Begin weaving a <see cref="ParameterDefinition"/>, given the
        /// <see cref="MethodDefinition"/> in which it is.
        /// </summary>
        public abstract void Apply(ParameterDefinition parameter, MethodDefinition method);
    }
}
