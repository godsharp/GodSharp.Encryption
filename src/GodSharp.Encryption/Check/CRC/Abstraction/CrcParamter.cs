namespace GodSharp.Encryption
{
    /// <summary>
    /// Crc paramter
    /// </summary>
    /// <typeparam name="TTable">The type of the table.</typeparam>
    internal class CrcParamter<TTable> where TTable : struct
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the polynomial.
        /// </summary>
        /// <value>
        /// The polynomial.
        /// </value>
        public TTable Polynomial { get; set; }

        /// <summary>
        /// Gets or sets the xor value.
        /// </summary>
        /// <value>
        /// The xor value.
        /// </value>
        public TTable XorValue { get; set; }

        /// <summary>
        /// Gets or sets the remainder initial value.
        /// </summary>
        /// <value>
        /// The remainder initial value.
        /// </value>
        public TTable RemainderInitialValue { get; set; }

        /// <summary>
        /// Gets or sets the xor result value.
        /// </summary>
        /// <value>
        /// The xor result value.
        /// </value>
        public TTable XorResultValue { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [reference input].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [reference input]; otherwise, <c>false</c>.
        /// </value>
        public bool RefInput { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [reference output].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [reference output]; otherwise, <c>false</c>.
        /// </value>
        public bool RefOutput { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrcParamter{TTable}"/> class.
        /// </summary>
        public CrcParamter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrcParamter{TTable}"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="polynomial">The polynomial.</param>
        /// <param name="remainder">The remainder.</param>
        /// <param name="xor">The xor.</param>
        /// <param name="width">The width.</param>
        /// <param name="input">if set to <c>true</c> [input].</param>
        /// <param name="output">if set to <c>true</c> [output].</param>
        public CrcParamter(string name, TTable polynomial, TTable remainder, TTable xor, int width, bool input, bool output)
        {
            Name = name;
            Polynomial = polynomial;
            RemainderInitialValue = remainder;
            XorResultValue = xor;
            Width = width;
            RefInput = input;
            RefOutput = output;
        }
    }
}
