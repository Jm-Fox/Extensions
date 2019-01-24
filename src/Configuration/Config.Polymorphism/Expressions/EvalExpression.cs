using System;
using System.Linq;
using System.Reflection;

namespace PolymorphicSample
{
    /// <summary></summary>s
    public class EvalExpression : ExpressionBase
    {
        /// <summary></summary>
        public BindingFlags BindingFlags { get; set; } =
            BindingFlags.NonPublic | BindingFlags.Public
            | BindingFlags.Instance;

        /// <summary></summary>
        public ExpressionBase Value { get; set; }

        /// <summary></summary>
        public string MemberName { get; set; }

        /// <summary></summary>
        public object[] Indexers { get; set; }

        /// <summary></summary>
        public override object Evaluate(object args)
        {
            object value = null;
            if (Value != null)
                value = Value.Evaluate(args);
            else
                value = args;
            if (value == null || args == null)
                return null;
            if (MemberName == null)
            {
                if (value is Array)
                    return ((Array)value).GetValue(Indexers.Select(i => (int)i).ToArray());
                MemberName = "Item";
            }
            Type type = value.GetType();
            FieldInfo field = type.GetField(MemberName, BindingFlags);
            if (field != null)
                return field.GetValue(value);
            PropertyInfo property = type.GetProperty(MemberName, BindingFlags);
            if (property != null)
                return property.GetValue(value, Indexers);
            throw new InvalidOperationException($"Could not find a property or field with member name '{MemberName}' on type '{type}'.");
        }
    }
}
