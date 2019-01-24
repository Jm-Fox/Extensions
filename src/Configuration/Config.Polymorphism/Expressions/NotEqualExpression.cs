namespace PolymorphicSample
{
    /// <summary></summary>
    public class NotEqualExpression : EqualExpression
    {
        /// <summary></summary>
        public override object Evaluate(object args)
        {
            return !(bool)base.Evaluate(args);
        }
    }
}
