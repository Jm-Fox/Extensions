// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.Extensions.Configuration.Binder.Dynamic
{
    /// <summary>
    /// Specifies what strategy should be used to bind an instance to a <seealso cref="IConfiguration"/>.
    /// </summary>
    /// <param name="expected">Type that is expected by the binder.</param>
    /// <param name="configurationToBind">Configuration section being bound.</param>
    /// <returns>
    /// Strategy that should be used by the binder.
    /// </returns>
    public delegate DynamicTypeResolutionStrategy DynamicTypeStrategyResolver(Type expected, IConfiguration configurationToBind);
}