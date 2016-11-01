using System;
using Mono.Cecil;

namespace Insider
{
    /// <summary>
    /// Interface for all attributes that will weave anything.
    /// </summary>
    public interface IWeaver
    {
    }

    /// <summary>
    /// Indicates that this <see cref="WeaverAttribute"/> can weave assemblies.
    /// </summary>
    public interface IAssemblyWeaver : IWeaver
    {
        /// <summary>
        /// Begin weaving an <see cref="AssemblyDefinition"/>.
        /// </summary>
        void Apply(AssemblyDefinition assembly);
    }

    /// <summary>
    /// Indicates that this <see cref="WeaverAttribute"/> can weave methods.
    /// </summary>
    public interface IMethodWeaver : IWeaver
    {
        /// <summary>
        /// Begin weaving a <see cref="MethodDefinition"/>.
        /// </summary>
        void Apply(MethodDefinition method);
    }

    /// <summary>
    /// Indicates that this <see cref="WeaverAttribute"/> can weave properties.
    /// </summary>
    public interface IPropertyWeaver : IWeaver
    {
        /// <summary>
        /// Begin weaving a <see cref="PropertyDefinition"/>.
        /// </summary>
        void Apply(PropertyDefinition property);
    }

    /// <summary>
    /// Indicates that this <see cref="WeaverAttribute"/> can weave types (classes and interfaces).
    /// </summary>
    public interface ITypeWeaver : IWeaver
    {
        /// <summary>
        /// Begin weaving a <see cref="TypeDefinition"/>.
        /// </summary>
        void Apply(TypeDefinition type);
    }

    /// <summary>
    /// Indicates that this <see cref="WeaverAttribute"/> can weave events.
    /// </summary>
    public interface IEventWeaver : IWeaver
    {
        /// <summary>
        /// Begin weaving an <see cref="EventDefinition"/>.
        /// </summary>
        void Apply(EventDefinition @event);
    }

    /// <summary>
    /// Indicates that this <see cref="WeaverAttribute"/> can weave fields.
    /// </summary>
    public interface IFieldWeaver : IWeaver
    {
        /// <summary>
        /// Begin weaving a <see cref="FieldDefinition"/>.
        /// </summary>
        void Apply(FieldDefinition field);
    }

    /// <summary>
    /// Indicates that this <see cref="WeaverAttribute"/> can weave parameters.
    /// </summary>
    public interface IParameterWeaver : IWeaver
    {
        /// <summary>
        /// Begin weaving a <see cref="ParameterDefinition"/>, given the
        /// <see cref="MethodDefinition"/> in which it is.
        /// </summary>
        void Apply(ParameterDefinition parameter, MethodDefinition method);
    }

    /// <summary>
    /// Indicates that this <see cref="WeaverAttribute"/> can weave modules.
    /// <para>
    /// This attribute cannot be set on anything, but <see cref="Apply"/> will be called
    /// everytime its <see cref="AssemblyDefinition"/> is resolved.
    /// </para>
    /// <para>
    /// This interface should be used by weavers that silently interact
    /// with another library, for example a database that
    /// compiles expressions on compilation, not on runtime.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Why an attribute, if it cannot be set on anything? Speed.
    /// Instead of scanning for all types, Insider focuses on anything
    /// that inherits <see cref="WeaverAttribute"/>.
    /// Adding a special case for the <see cref="IModuleWeaver"/> would
    /// not only add a few loops, but also a few methods specifically
    /// for it.
    /// </remarks>
    public interface IModuleWeaver : IWeaver
    {
        /// <summary>
        /// Weave a <see cref="ModuleDefinition"/>, given
        /// the <see cref="ProcessingState"/> of the Insider.
        /// </summary>
        void Apply(ModuleDefinition module, ProcessingState state);
    }

    /// <summary>
    /// Enum used by <see cref="IModuleWeaver"/> to
    /// behave differently based on the state of
    /// the processing of an assembly.
    /// </summary>
    public enum ProcessingState
    {
        /// <summary>
        /// Processing of the <see cref="ModuleDefinition"/> hasn't started yet.
        /// </summary>
        Before,
        /// <summary>
        /// Processing of the <see cref="ModuleDefinition"/> has ended.
        /// </summary>
        After
    }
}
