using Microsoft.Extensions.Configuration.Binder.Dynamic;
using System;

namespace PolymorphicSample
{
    /// <summary></summary>
    public class ExpressionTypeResolver : DynamicTypeResolver
    {
        /// <summary></summary>
        public ExpressionTypeResolver()
        {
            const string suffix = "Expression";
            foreach (Type type in GetType().Assembly.GetTypes())
            {
                if (typeof(ExpressionBase).IsAssignableFrom(type) && type.Name.EndsWith(suffix))
                    TypeAliases.Add(type.Name.Replace(suffix, string.Empty), type);
            }
            ObjectTypeKey = "objectType";
            LiteralValueKey = "value";
            TypeKey = "type";
        }
    }
}
