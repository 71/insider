using System;

namespace Insider
{
    /// <summary>
    /// Defines an attribute that should store settings for a
    /// weaver.
    /// <para>
    /// Every named property in the constructor and its value will be copied
    /// to the global <see cref="WeaverAttribute.Settings"/> dictionary.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Values are copied to the dictionary using the following key:
    /// [AssemblyName].[PropertyName]
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public abstract class InsiderSettingAttribute : Attribute
    {
    }

    /// <summary>
    /// Sets a key and value in the global <see cref="WeaverAttribute.Settings"/> dictionary.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class SettingAttribute : InsiderSettingAttribute
    {
        public SettingAttribute(string name, object value)
        {
        }
    }

    /// <summary>
    /// Indicates the default value for a setting (property or field of
    /// an attribute that inherits <see cref="InsiderSettingAttribute"/>).
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class DefaultSettingValueAttribute : Attribute
    {
        internal readonly object Value;

        /// <summary>
        /// Set a setting's default value to <paramref name="value"/>.
        /// </summary>
        public DefaultSettingValueAttribute(object value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Allows you to change the behavior of the weaver.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public sealed class InsiderAttribute : InsiderSettingAttribute
    {
        /// <summary>
        /// If <code>true</code>, every attribute and method related to
        /// the Insider will be removed from the produced assembly.
        /// <para>
        /// If <code>false</code>, attributes and their definition will stay in the
        /// assembly, forcing you to keep dependencies to Mono.Cecil.
        /// </para>
        /// <para>
        /// Default: <code>true</code>.
        /// </para>
        /// </summary>
        [DefaultSettingValue(true)]
        public bool CleanUp { get; set; }

        /// <summary>
        /// If <code>true</code>, <see cref="System.Diagnostics.Debugger.Launch"/>
        /// will be called everytime <code>Weaver.Apply()</code> is called.
        /// <para>
        /// Default: <code>false</code>.
        /// </para> 
        /// </summary>
        [DefaultSettingValue(false)]
        public bool Debug { get; set; }
    }
}
