using System;

namespace GodSharp.Encryption
{
    /// <summary>
    /// The argument validator
    /// </summary>
    internal class ArgumentValidator
    {
        /// <summary>
        /// Validates the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <exception cref="ArgumentNullException">item</exception>
        public static void Validate(params object[] args)
        {
            if (args.Length == 0) return;

            foreach (object item in args)
            {
                if (item == null) throw new ArgumentNullException(nameof(item));
            }
        }
    }
}
