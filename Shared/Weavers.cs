using System;
using Mono.Cecil;

namespace Insider
{
    /// <summary>
    /// Base class for all attributes that will weave anything.
    /// </summary>
    public interface IWeaver
    {
    }

    /// <summary>
    /// Base class for all attributes that will weave assemblies.
    /// </summary>
    public interface IAssemblyWeaver : IWeaver
    {
        /// <summary>
        /// Begin weaving an <see cref="AssemblyDefinition"/>.
        /// </summary>
        void Apply(AssemblyDefinition assembly);
    }

    /// <summary>
    /// Base class for all attributes that will weave methods.
    /// </summary>
    public interface IMethodWeaver : IWeaver
    {
        /// <summary>
        /// Begin weaving a <see cref="MethodDefinition"/>.
        /// </summary>
         void Apply(MethodDefinition method);
    }

    /// <summary>
    /// Base class for all attributes that will weave properties.
    /// </summary>
    public interface IPropertyWeaver : IWeaver
    {
        /// <summary>
        /// Begin weaving a <see cref="PropertyDefinition"/>.
        /// </summary>
         void Apply(PropertyDefinition property);
    }

    /// <summary>
    /// Base class for all attributes that will weave types (classes and interfaces).
    /// </summary>
    public interface ITypeWeaver : IWeaver
    {
        /// <summary>
        /// Begin weaving a <see cref="TypeDefinition"/>.
        /// </summary>
         void Apply(TypeDefinition type);
    }

    /// <summary>
    /// Base class for all attributes that will weave events.
    /// </summary>
    public interface IEventWeaver : IWeaver
    {
        /// <summary>
        /// Begin weaving an <see cref="EventDefinition"/>.
        /// </summary>
         void Apply(EventDefinition @event);
    }

    /// <summary>
    /// Base class for all attributes that will weave fields.
    /// </summary>
    public interface IFieldWeaver : IWeaver
    {
        /// <summary>
        /// Begin weaving a <see cref="FieldDefinition"/>.
        /// </summary>
         void Apply(FieldDefinition field);
    }

    /// <summary>
    /// Base class for all attributes that will weaves parameters.
    /// </summary>
    public interface IParameterWeaver : IWeaver
    {
        /// <summary>
        /// Begin weaving a <see cref="ParameterDefinition"/>, given the
        /// <see cref="MethodDefinition"/> in which it is.
        /// </summary>
         void Apply(ParameterDefinition parameter, MethodDefinition method);
    }
}
