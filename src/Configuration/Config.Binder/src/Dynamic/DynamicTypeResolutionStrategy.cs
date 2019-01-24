// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.Extensions.Configuration.Binder.Dynamic
{
    /// <summary>
    /// Provides a strategy for polymorphically resolving types.
    /// </summary>
    public class DynamicTypeResolutionStrategy
    {
        /// <summary>
        /// Denotes the actual type to bind to.
        /// The expected type provided to the resolver must be assignable from the actual type.
        /// Should not be null.
        /// </summary>
        public Type ActualType { get; set; }

        /// <summary>
        /// Denotes the section to bind against. If null, the current section will be used.
        /// </summary>
        public string KeyName { get; set; }
    }
}