using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PolymorphicSample.Expressions
{
    /// <summary></summary>
    public class Int64EvalExpression : ExpressionBase
    {
        /// <summary></summary>
        public IntOperation Op { get; set; }

        /// <summary></summary>
        public ExpressionBase Left { get; set; }

        /// <summary></summary>
        public ExpressionBase Right { get; set; }

        private static long Longify(object value)
        {
            if (value is long l)
                return l;
            var converter = TypeDescriptor.GetConverter(typeof(long));
            if (converter.CanConvertTo(typeof(long)))
                return (long)converter.ConvertTo(value, typeof(long));
            throw new InvalidOperationException();
        }

        private static int Intify(object value)
        {
            if (value is int i)
                return i;
            var converter = TypeDescriptor.GetConverter(typeof(int));
            if (converter.CanConvertTo(typeof(int)))
                return (int)converter.ConvertTo(value, typeof(int));
            throw new InvalidOperationException();
        }

        /// <summary></summary>
        public override object Evaluate(object args)
        {
            switch (Op)
            {
                case IntOperation.Add:
                    return Longify(Left.Evaluate(args)) + Longify(Right.Evaluate(args));
                case IntOperation.Subtract:
                    return Longify(Left.Evaluate(args)) - Longify(Right.Evaluate(args));
                case IntOperation.Multiply:
                    return Longify(Left.Evaluate(args)) * Longify(Right.Evaluate(args));
                case IntOperation.Divide:
                    return Longify(Left.Evaluate(args)) / Longify(Right.Evaluate(args));
                case IntOperation.Mod:
                    return Longify(Left.Evaluate(args)) / Longify(Right.Evaluate(args));
                case IntOperation.Negate:
                    return -Longify(Left.Evaluate(args));
                case IntOperation.Lshift:
                    return Longify(Left.Evaluate(args)) << Intify(Right.Evaluate(args));
                case IntOperation.Rshift:
                    return Longify(Left.Evaluate(args)) >> Intify(Right.Evaluate(args));
                case IntOperation.Max:
                    return Math.Max(Longify(Left.Evaluate(args)), Longify(Right.Evaluate(args)));
                case IntOperation.Min:
                    return Math.Min(Longify(Left.Evaluate(args)), Longify(Right.Evaluate(args)));
                case IntOperation.Square:
                    long left = Longify(Left.Evaluate(args));
                    return left * left;
                case IntOperation.SquareRoot:
                    return Math.Sqrt(Longify(Left.Evaluate(args)));
                case IntOperation.Pow:
                    return Math.Pow(Longify(Left.Evaluate(args)), Longify(Right.Evaluate(args)));
                case IntOperation.And:
                    return Longify(Left.Evaluate(args)) & Longify(Right.Evaluate(args));
                case IntOperation.Or:
                    return Longify(Left.Evaluate(args)) | Longify(Right.Evaluate(args));
                case IntOperation.Xor:
                    return Longify(Left.Evaluate(args)) ^ Longify(Right.Evaluate(args));
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
