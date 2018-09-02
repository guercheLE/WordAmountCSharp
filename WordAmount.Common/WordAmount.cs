// <copyright file="WordAmount.cs" company="Guerche TI">
//     Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Luciano Evaristo Guerche</author>
// <email>guercheLE@hotmail.com</email>
// <date>August 22nd, 2018 20:13</date>
// <summary>
// Word Amount abstract class.
// </summary>
namespace WordAmount.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Word Amount abstract class.
    /// </summary>
    public abstract class WordAmount : IWordAmount
    {
        #region Protected Fields

        /// <summary>
        /// The currencies word.
        /// </summary>
        protected string[] currencyWord = new string[2];

        /// <summary>
        /// The conjunction for cents.
        /// </summary>
        protected string conjunctionForCents;

        #endregion Protected Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the currency word singular.
        /// </summary>
        /// <value>The currency word singular.</value>
        public string CurrencyWordSingular { get => currencyWord[(int)NumberType.Singular]; set => currencyWord[(int)NumberType.Singular] = value; }

        /// <summary>
        /// Gets or sets the currency word plural.
        /// </summary>
        /// <value>The currency word plural.</value>
        public string CurrencyWordPlural { get => currencyWord[(int)NumberType.Plural]; set => currencyWord[(int)NumberType.Plural] = value; }

        /// <summary>
        /// Gets or sets the conjunction for cents.
        /// </summary>
        /// <value>The conjunction for cents.</value>
        public string ConjunctionForCents { get => conjunctionForCents; set => conjunctionForCents = value; }

        #endregion Public Properties

        #region Protected Properties

        /// <summary>
        /// Gets the value must be greater than zero message.
        /// </summary>
        /// <value>The value must be greater than zero message.</value>
        protected abstract string ValueMustBeGreaterThanZeroMessage { get; }

        /// <summary>
        /// Highest category supported.
        /// </summary>
        /// <value>The highest category supported.</value>
        protected abstract PartCategory HighestCategorySupported { get; }

        /// <summary>
        /// Maximum supported value exception message.
        /// </summary>
        /// <value>The maximum supported value exception message.</value>
        protected abstract string MaxSupportedValueExceptionMessage { get; }

        #endregion Protected Properties

        #region Public Methods

        /// <summary>
        /// Gets word amount for specified value.
        /// </summary>
        /// <param name="value">Value to return word amount of.</param>
        /// <param name="firstLetterUppercase">if set to <c>true</c> [first letter uppercase].</param>
        /// <returns>Word Amount for the specified value.</returns>
        public string Get(double value, bool firstLetterUppercase = false)
        {
            if (value <= 0)
            {
                throw new ArgumentException(ValueMustBeGreaterThanZeroMessage, nameof(value));
            }

            IList<Part> parts = ParseValueIntoParts(value);
            VerifyValueCanBeGotten(parts[0].Category);
            return Get(parts, value > 1.99, firstLetterUppercase);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Gets the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="parts">The parts.</param>
        /// <param name="pluralizeCurrency">Pluralize currency?</param>
        /// <param name="firstLetterUppercase">if set to <c>true</c> [first letter uppercase].</param>
        /// <returns>The value into word amount format.</returns>
        protected abstract string Get(IList<Part> parts, bool pluralizeCurrency, bool firstLetterUppercase = false);

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Parses the value into parts.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Parsed value into parts.</returns>
        private IList<Part> ParseValueIntoParts(double value)
        {
            List<Part> valueToReturn = new List<Part>();
            string formattedValue = value.ToString("#,##0.00");

            int paddingLength = (4 - ((formattedValue.Length - 2) % 4)) % 4;
            if (paddingLength != 0)
            {
                formattedValue = formattedValue.PadLeft(formattedValue.Length + paddingLength, '0');
            }

            int integerPartsIndexCount = (formattedValue.Length - 2) / 4;
            for (int index = 0; index < integerPartsIndexCount * 4; index += 4)
            {
                if (formattedValue.Substring(index, 3) != "000")
                {
                    valueToReturn.Add(new Part { Category = (PartCategory)(integerPartsIndexCount - (index / 4)), Value = int.Parse(formattedValue.Substring(index, 3)) });
                }
            }

            if (formattedValue.Substring(formattedValue.Length - 2, 2) != "00")
            {
                valueToReturn.Add(new Part { Category = PartCategory.Cents, Value = int.Parse(formattedValue.Substring(formattedValue.Length - 2, 2)) });
            }

            return valueToReturn;
        }

        /// <summary>
        /// Verifies the value can be gotten.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <exception cref="ApplicationException"></exception>
        private void VerifyValueCanBeGotten(PartCategory category)
        {
            int highestCategorySupported = (int)HighestCategorySupported;
            if ((int)category > highestCategorySupported)
            {
                string maxSupportedValue = new StringBuilder(((highestCategorySupported + 1) * 4) - 1).Insert(0, "999").Insert(3, ",999", highestCategorySupported - 1).Append(".99").ToString();
                throw new ApplicationException(string.Format(MaxSupportedValueExceptionMessage, maxSupportedValue));
            }
        }

        #endregion Private Methods
    }
}