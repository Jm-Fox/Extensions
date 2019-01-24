namespace PolymorphicSample
{
    /// <summary></summary>
    public class AndExpression : ExpressionBase
    {
        /// <summary></summary>
        public ExpressionBase[] Conditions { get; set; }

        /// <summary></summary>
        public override object Evaluate(object args)
        {
            foreach (ExpressionBase expression in Conditions)
                if (!(bool)expression.Evaluate(args))
                    return false;
            return true;
        }
    }
}
