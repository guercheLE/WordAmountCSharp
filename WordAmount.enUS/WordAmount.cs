// <copyright file="WordAmount.cs" company="Guerche TI">
//     Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Luciano Evaristo Guerche</author>
// <email>guercheLE@hotmail.com</email>
// <date>August 22nd, 2018 21:50</date>
// <summary>
// Word Amount class which implements Word Amount interface for American Engish.
// </summary>
namespace WordAmount.enUS
{
    using global::WordAmount.Common;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Word Amount class which implements Word Amount interface for American Engish.
    /// </summary>
    /// <seealso cref="WordAmount.Common.WordAmount"/>
    [Culture(culture: "en-US")]
    public sealed class WordAmount : Common.WordAmount
    {
        #region Private Fields

        /// <summary>
        /// The parts word.
        /// </summary>
        private static readonly string[,] partWord = new string[(int)PartCategory.Vigintillions + 1, 2];

        /// <summary>
        /// The amounts word.
        /// </summary>
        private static readonly string[] amountWord = new string[1000];

        /// <summary>
        /// The conjunction for cents.
        /// </summary>
        private static readonly string conjunctionForParts;

        #endregion Private Fields

        #region Protected Properties

        /// <summary>
        /// Value must be greater than zero message.
        /// </summary>
        /// <value>The value must be greater than zero message.</value>
        protected override string ValueMustBeGreaterThanZeroMessage => "Value must be greater than zero.";

        /// <summary>
        /// Highest category supported.
        /// </summary>
        /// <value>The highest category supported.</value>
        protected override PartCategory HighestCategorySupported => (PartCategory)partWord.GetLength(0) - 1;

        /// <summary>
        /// Maximum supported value exception message.
        /// </summary>
        /// <value>The maximum supported value exception message.</value>
        protected override string MaxSupportedValueExceptionMessage => "Highest value supported in American English is {0}";

        #endregion Protected Properties

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WordAmount"/> class.
        /// </summary>
        static WordAmount()
        {
            conjunctionForParts = " and ";

            partWord[(int)PartCategory.Cents, (int)NumberType.Singular] = "cent";
            partWord[(int)PartCategory.Cents, (int)NumberType.Plural] = "cents";

            partWord[(int)PartCategory.Units, (int)NumberType.Singular] = string.Empty;
            partWord[(int)PartCategory.Units, (int)NumberType.Plural] = string.Empty;

            partWord[(int)PartCategory.Thousands, (int)NumberType.Singular] = "thousand";
            partWord[(int)PartCategory.Thousands, (int)NumberType.Plural] = "thousand";

            partWord[(int)PartCategory.Millions, (int)NumberType.Singular] = "million";
            partWord[(int)PartCategory.Millions, (int)NumberType.Plural] = "million";

            partWord[(int)PartCategory.Billions, (int)NumberType.Singular] = "billion";
            partWord[(int)PartCategory.Billions, (int)NumberType.Plural] = "billion";

            partWord[(int)PartCategory.Trillions, (int)NumberType.Singular] = "trillion";
            partWord[(int)PartCategory.Trillions, (int)NumberType.Plural] = "trillion";

            partWord[(int)PartCategory.Quadrillions, (int)NumberType.Singular] = "quadrillion";
            partWord[(int)PartCategory.Quadrillions, (int)NumberType.Plural] = "quadrillion";

            partWord[(int)PartCategory.Quintillions, (int)NumberType.Singular] = "quintillion";
            partWord[(int)PartCategory.Quintillions, (int)NumberType.Plural] = "quintillion";

            partWord[(int)PartCategory.Sextillions, (int)NumberType.Singular] = "sextillion";
            partWord[(int)PartCategory.Sextillions, (int)NumberType.Plural] = "sextillion";

            partWord[(int)PartCategory.Septillions, (int)NumberType.Singular] = "septillion";
            partWord[(int)PartCategory.Septillions, (int)NumberType.Plural] = "septillion";

            partWord[(int)PartCategory.Octillions, (int)NumberType.Singular] = "octillion";
            partWord[(int)PartCategory.Octillions, (int)NumberType.Plural] = "octillion";

            partWord[(int)PartCategory.Nonillions, (int)NumberType.Singular] = "nonillion";
            partWord[(int)PartCategory.Nonillions, (int)NumberType.Plural] = "nonillion";

            partWord[(int)PartCategory.Decillions, (int)NumberType.Singular] = "decillion";
            partWord[(int)PartCategory.Decillions, (int)NumberType.Plural] = "decillion";

            partWord[(int)PartCategory.Undecillions, (int)NumberType.Singular] = "undecillion";
            partWord[(int)PartCategory.Undecillions, (int)NumberType.Plural] = "undecillion";

            partWord[(int)PartCategory.Duodecillions, (int)NumberType.Singular] = "duodecillion";
            partWord[(int)PartCategory.Duodecillions, (int)NumberType.Plural] = "duodecillion";

            partWord[(int)PartCategory.Tredecillions, (int)NumberType.Singular] = "tredecillion";
            partWord[(int)PartCategory.Tredecillions, (int)NumberType.Plural] = "tredecillion";

            partWord[(int)PartCategory.Quatttuordecillions, (int)NumberType.Singular] = "quatttuordecillion";
            partWord[(int)PartCategory.Quatttuordecillions, (int)NumberType.Plural] = "quatttuordecillion";

            partWord[(int)PartCategory.Quindecillions, (int)NumberType.Singular] = "quindecillion";
            partWord[(int)PartCategory.Quindecillions, (int)NumberType.Plural] = "quindecillion";

            partWord[(int)PartCategory.Sexdecillions, (int)NumberType.Singular] = "sexdecillion";
            partWord[(int)PartCategory.Sexdecillions, (int)NumberType.Plural] = "sexdecillion";

            partWord[(int)PartCategory.Septendecillions, (int)NumberType.Singular] = "septendecillion";
            partWord[(int)PartCategory.Septendecillions, (int)NumberType.Plural] = "septendecillion";

            partWord[(int)PartCategory.Octodecillions, (int)NumberType.Singular] = "octodecillion";
            partWord[(int)PartCategory.Octodecillions, (int)NumberType.Plural] = "octodecillion";

            partWord[(int)PartCategory.Novemdecillions, (int)NumberType.Singular] = "novemdecillion";
            partWord[(int)PartCategory.Novemdecillions, (int)NumberType.Plural] = "novemdecillion";

            partWord[(int)PartCategory.Vigintillions, (int)NumberType.Singular] = "vigintillion";
            partWord[(int)PartCategory.Vigintillions, (int)NumberType.Plural] = "vigintillion";

            amountWord[0] = "zero";
            amountWord[1] = "one";
            amountWord[2] = "two";
            amountWord[3] = "three";
            amountWord[4] = "four";
            amountWord[5] = "five";
            amountWord[6] = "six";
            amountWord[7] = "seven";
            amountWord[8] = "eight";
            amountWord[9] = "nine";
            amountWord[10] = "ten";
            amountWord[11] = "eleven";
            amountWord[12] = "twelve";
            amountWord[13] = "thirteen";
            amountWord[14] = "fourteen";
            amountWord[15] = "fifteen";
            amountWord[16] = "sixteen";
            amountWord[17] = "seventeen";
            amountWord[18] = "eighteen";
            amountWord[19] = "nineteen";
            amountWord[20] = "twenty";
            amountWord[30] = "thirty";
            amountWord[40] = "forty";
            amountWord[50] = "fifty";
            amountWord[60] = "sixty";
            amountWord[70] = "seventy";
            amountWord[80] = "eighty";
            amountWord[90] = "ninety";
            amountWord[100] = "one hundred";
            amountWord[200] = "two hundred";
            amountWord[300] = "three hundred";
            amountWord[400] = "four hundred";
            amountWord[500] = "five hundred";
            amountWord[600] = "six hundred";
            amountWord[700] = "seven hundred";
            amountWord[800] = "eight hundred";
            amountWord[900] = "nine hundred";

            for (int amountIndex = 21; amountIndex < 100; amountIndex++)
            {
                if (amountWord[amountIndex] == null)
                {
                    amountWord[amountIndex] = amountWord[(amountIndex / 10) * 10] + "-" + amountWord[amountIndex % 10];
                }
            }

            for (int amountIndex = 101; amountIndex < 1000; amountIndex++)
            {
                if (amountWord[amountIndex] == null)
                {
                    amountWord[amountIndex] = amountWord[(amountIndex / 100) * 100] + " " + amountWord[amountIndex - ((amountIndex / 100) * 100)];
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordAmount"/> class.
        /// </summary>
        public WordAmount()
        {
            base.conjunctionForCents = " and ";

            base.currencyWord[(int)NumberType.Singular] = "dollar";
            base.currencyWord[(int)NumberType.Plural] = "dollars";
        }

        #endregion Public Constructors

        #region Protected Methods

        /// <summary>
        /// Gets the specified value.
        /// </summary>
        /// <param name="parts">The parts.</param>
        /// <param name="pluralizeCurrency">Pluralize currency?</param>
        /// <param name="firstLetterUppercase">if set to <c>true</c> [first letter uppercase].</param>
        /// <returns>The value into word amount format.</returns>
        protected override string Get(IList<Part> parts, bool pluralizeCurrency, bool firstLetterUppercase = false)
        {
            bool addCurrency = false;
            bool currencyAdded = false;
            StringBuilder valueToReturn = new StringBuilder();
            string valueAmountWord = string.Empty;

            for (int partIndex = 0; partIndex < parts.Count; partIndex++)
            {
                valueAmountWord = amountWord[parts[partIndex].Value];
                addCurrency = !currencyAdded
                              && ((partIndex == parts.Count - 1 && parts[partIndex].Category != (int)PartCategory.Cents)
                                  || (partIndex < parts.Count - 1 && parts[partIndex + 1].Category == (int)PartCategory.Cents));

                if (partIndex == 0
                    && firstLetterUppercase)
                {
                    valueAmountWord = valueAmountWord.Substring(0, 1).ToUpperInvariant() + valueAmountWord.Substring(1, valueAmountWord.Length - 1);
                }

                valueToReturn.Append(valueAmountWord)
                             .Append(parts[partIndex].Value != 1
                                     ? (" " + partWord[(int)parts[partIndex].Category, (int)NumberType.Plural]).TrimEnd()
                                     : (" " + partWord[(int)parts[partIndex].Category, (int)NumberType.Singular]).TrimEnd());

                if (addCurrency)
                {
                    valueToReturn.Append(" ")
                                 .Append(pluralizeCurrency
                                         ? currencyWord[(int)NumberType.Plural]
                                         : currencyWord[(int)NumberType.Singular]);

                    currencyAdded = true;
                }

                if (partIndex == parts.Count - 3
                    && parts[partIndex + 1].Category == PartCategory.Units)
                {
                    valueToReturn.Append(conjunctionForParts);
                }
                else if (partIndex == parts.Count - 2)
                {
                    valueToReturn.Append(parts[partIndex + 1].Category == (int)PartCategory.Cents
                                         ? conjunctionForCents
                                         : conjunctionForParts);
                }
                else if (partIndex < parts.Count - 2)
                {
                    valueToReturn.Append(", ");
                }
            }

            return valueToReturn.ToString();
        }

        #endregion Protected Methods
    }
}