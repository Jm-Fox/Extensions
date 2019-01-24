using System;
using System.ComponentModel;

namespace PolymorphicSample
{
    /// <summary></summary>
    public class EqualExpression : ExpressionBase
    {
        /// <summary></summary>
        public TypeEqualityOptions Options { get; set; }
        /// <summary></summary>
        public ExpressionBase Left { get; set; }
        /// <summary></summary>
        public ExpressionBase Right { get; set; }

        /// <summary></summary>
        public override object Evaluate(object args)
        {
            object leftVal = Left.Evaluate(args);
            object rightVal = Right.Evaluate(args);
            if (leftVal == null)
            {
                if (rightVal == null)
                    return true;
                return false;
            }
            if (rightVal == null)
                return false;
            if (leftVal.GetType() != rightVal.GetType())
            {
                if (Options == TypeEqualityOptions.CastToLeft)
                    rightVal = TypeDescriptor.GetConverter(leftVal.GetType()).ConvertTo(rightVal, leftVal.GetType());
                else if (Options == TypeEqualityOptions.CastToRight)
                    leftVal = TypeDescriptor.GetConverter(rightVal.GetType()).ConvertTo(leftVal, rightVal.GetType());
            }
            return leftVal.Equals(rightVal);
        }
    }
}
