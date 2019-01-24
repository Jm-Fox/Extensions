namespace PolymorphicSample
{
    /// <summary></summary>
    public class LiteralExpression : ExpressionBase
    {
        /// <summary></summary>
        public object Value { get; set; }

        /// <summary></summary>
        public override object Evaluate(object args)
        {
            return Value;
        }
    }
}
