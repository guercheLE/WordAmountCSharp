// <copyright file="IWordAmount.cs" company="Guerche TI">
//     Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Luciano Evaristo Guerche</author>
// <email>guercheLE@hotmail.com</email>
// <date>August 17th, 2018 16:54</date>
// <summary>
// </summary>
namespace WordAmount.Common
{
    /// <summary>
    /// Word Amount interface.
    /// </summary>
    public interface IWordAmount
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the currency word singular.
        /// </summary>
        /// <value>The currency word singular.</value>
        string CurrencyWordSingular { get; set; }

        /// <summary>
        /// Gets or sets the currency word plural.
        /// </summary>
        /// <value>The currency word plural.</value>
        string CurrencyWordPlural { get; set; }

        /// <summary>
        /// Gets or sets the conjunction for cents.
        /// </summary>
        /// <value>The conjunction for cents.</value>
        string ConjunctionForCents { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Gets word amount for specified value.
        /// </summary>
        /// <param name="value">Value to return word amount of.</param>
        /// <param name="firstLetterUppercase">if set to <c>true</c> [first letter uppercase].</param>
        /// <returns>Word Amount for the specified value.</returns>
        string Get(double value, bool firstLetterUppercase = false);

        #endregion Public Methods
    }
}