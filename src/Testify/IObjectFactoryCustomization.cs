namespace Testify
{
    /// <summary>
    /// Defines an interface used to customize the <see cref="ObjectFactory"/> behavior.
    /// </summary>
    public interface IObjectFactoryCustomization
    {
        /// <summary>
        /// Creates an object of a specified type.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="result">The result.</param>
        /// <returns><see langword="true"/> if an object was created, otherwise <see langword="false"/>.</returns>
        bool Create(IObjectFactoryContext context, out object result);
    }
}