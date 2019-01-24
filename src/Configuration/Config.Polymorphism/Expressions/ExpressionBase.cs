namespace PolymorphicSample
{
    /// <summary></summary>
    public abstract class ExpressionBase
    {
        /// <summary></summary>
        public abstract object Evaluate(object args);

        /// <summary></summary>
        public virtual void Validate()
        {
            // throw exceptions if expression is invalid
        }
    }
}
