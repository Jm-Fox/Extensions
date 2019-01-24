// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.Configuration.Binder.Dynamic
{
    /// <summary>
    /// Provides basic dynamic type resolution.
    /// </summary>
    public class DynamicTypeResolver
    {
        /// <summary>
        /// The key name to be used to override the declared type.
        /// Default: _type
        /// </summary>
        public string TypeKey { get; set; } = "_type";

        /// <summary>
        /// The key name to be used to derive the implementation type when the declared type is
        /// <see cref="object"/> (the implementation can be *anything*).
        /// Must be used in conjunction with <seealso cref="LiteralValueKey"/>.
        /// Default: _literalType
        /// </summary>
        public string ObjectTypeKey { get; set; } = "_objectType";

        /// <summary>
        /// The key name to be used to derive the implementation value when the declared type is
        /// <see cref="object"/> (the implementation can be *anything*).
        /// Must be used in conjunction with <seealso cref="ObjectTypeKey"/>.
        /// Default: _value
        /// </summary>
        public string LiteralValueKey { get; set; } = "_value";

        /// <summary>
        /// Provides aliases for types so the type's (possibly assembly qualified) full name is not required.
        /// </summary>
        public IDictionary<string, Type> TypeAliases { get; set; }
            = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Specifies what type should be bound to for a given expected type and configuration section.
        /// </summary>
        /// <param name="expected">Type that is expected by the binder.</param>
        /// <param name="configurationToBind">Configuration section being bound.</param>
        /// <returns>Type that should be used to implement a <seealso cref="IConfiguration"/></returns>
        protected Type ResolveType(Type expected, IConfiguration configurationToBind)
        {
            string type = configurationToBind[TypeKey];
            if (type != null)
            {
                if (TypeAliases.TryGetValue(type, out Type actual))
                    return actual;
                actual = Type.GetType(type);
                if (actual != null)
                    return actual;
            }
            return expected;
        }

        /// <summary>
        /// Specifies what strategy should be used to bind an instance to a <seealso cref="IConfiguration"/>.
        /// </summary>
        /// <param name="expected">Type that is expected by the binder.</param>
        /// <param name="configurationToBind">Configuration section being bound.</param>
        /// <returns>
        /// Strategy that should be used by the binder.
        /// </returns>
        public DynamicTypeResolutionStrategy ResolveStrategy(Type expected, IConfiguration configurationToBind)
        {
            Type type = ResolveType(expected, configurationToBind);
            if (type == typeof(object)
                && configurationToBind[ObjectTypeKey] != null
                && configurationToBind[LiteralValueKey] != null)
            {
                return new DynamicTypeResolutionStrategy
                {
                    KeyName = LiteralValueKey,
                    ActualType = Type.GetType(configurationToBind[ObjectTypeKey])
                };
            }
            return new DynamicTypeResolutionStrategy
            {
                ActualType = type
            };
        }
    }
}