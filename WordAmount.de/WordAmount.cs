// <copyright file="WordAmount.cs" company="Guerche TI">
//     Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Luciano Evaristo Guerche</author>
// <email>guercheLE@hotmail.com</email>
// <date>August 22nd, 2018 21:51</date>
// <summary>
// Word Amount class which implements Word Amount interface for German.
// </summary>
namespace WordAmount.de
{
    using global::WordAmount.Common;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Word Amount class which implements Word Amount interface for German.
    /// </summary>
    /// <seealso cref="WordAmount.Common.WordAmount"/>
    [Culture(culture: "de")]
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
        protected override string ValueMustBeGreaterThanZeroMessage => "Der Wert muss größer als Null sein.";

        /// <summary>
        /// Highest category supported.
        /// </summary>
        /// <value>The highest category supported.</value>
        protected override PartCategory HighestCategorySupported => (PartCategory)partWord.GetLength(0) - 1;

        /// <summary>
        /// Maximum supported value exception message.
        /// </summary>
        /// <value>The maximum supported value exception message.</value>
        protected override string MaxSupportedValueExceptionMessage => "Der höchste unterstützte Wert in Deutsch ist {0}";

        #endregion Protected Properties

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WordAmount"/> class.
        /// </summary>
        static WordAmount()
        {
            conjunctionForParts = "und";

            partWord[(int)PartCategory.Cents, (int)NumberType.Singular] = "Pfennig";
            partWord[(int)PartCategory.Cents, (int)NumberType.Plural] = "Pfennige";

            partWord[(int)PartCategory.Units, (int)NumberType.Singular] = string.Empty;
            partWord[(int)PartCategory.Units, (int)NumberType.Plural] = string.Empty;

            partWord[(int)PartCategory.Thousands, (int)NumberType.Singular] = "Tausend";
            partWord[(int)PartCategory.Thousands, (int)NumberType.Plural] = "Tausend";

            partWord[(int)PartCategory.Millions, (int)NumberType.Singular] = "Million";
            partWord[(int)PartCategory.Millions, (int)NumberType.Plural] = "Millionen";

            partWord[(int)PartCategory.Billions, (int)NumberType.Singular] = "Milliarde";
            partWord[(int)PartCategory.Billions, (int)NumberType.Plural] = "Milliarden";

            partWord[(int)PartCategory.Trillions, (int)NumberType.Singular] = "Billion";
            partWord[(int)PartCategory.Trillions, (int)NumberType.Plural] = "Billionen";

            partWord[(int)PartCategory.Quadrillions, (int)NumberType.Singular] = "Billiarde";
            partWord[(int)PartCategory.Quadrillions, (int)NumberType.Plural] = "Billiarden";

            partWord[(int)PartCategory.Quintillions, (int)NumberType.Singular] = "Trillion";
            partWord[(int)PartCategory.Quintillions, (int)NumberType.Plural] = "Trillionen";

            partWord[(int)PartCategory.Sextillions, (int)NumberType.Singular] = "Trilliarde";
            partWord[(int)PartCategory.Sextillions, (int)NumberType.Plural] = "Trilliarden";

            partWord[(int)PartCategory.Septillions, (int)NumberType.Singular] = "Quartillion";
            partWord[(int)PartCategory.Septillions, (int)NumberType.Plural] = "Quartillionen";

            partWord[(int)PartCategory.Octillions, (int)NumberType.Singular] = "quadrilliarde";
            partWord[(int)PartCategory.Octillions, (int)NumberType.Plural] = "quadrilliarden";

            partWord[(int)PartCategory.Nonillions, (int)NumberType.Singular] = "quintillion";
            partWord[(int)PartCategory.Nonillions, (int)NumberType.Plural] = "quintillionen";

            partWord[(int)PartCategory.Decillions, (int)NumberType.Singular] = "quintilliarde";
            partWord[(int)PartCategory.Decillions, (int)NumberType.Plural] = "quintilliarden";

            partWord[(int)PartCategory.Undecillions, (int)NumberType.Singular] = "sextillion";
            partWord[(int)PartCategory.Undecillions, (int)NumberType.Plural] = "sextillionen";

            partWord[(int)PartCategory.Duodecillions, (int)NumberType.Singular] = "sextilliarde";
            partWord[(int)PartCategory.Duodecillions, (int)NumberType.Plural] = "sextilliarden";

            partWord[(int)PartCategory.Tredecillions, (int)NumberType.Singular] = "septillion";
            partWord[(int)PartCategory.Tredecillions, (int)NumberType.Plural] = "septillionen";

            partWord[(int)PartCategory.Quatttuordecillions, (int)NumberType.Singular] = "septilliarde";
            partWord[(int)PartCategory.Quatttuordecillions, (int)NumberType.Plural] = "septilliarden";

            partWord[(int)PartCategory.Quindecillions, (int)NumberType.Singular] = "oktillion";
            partWord[(int)PartCategory.Quindecillions, (int)NumberType.Plural] = "oktillionen";

            partWord[(int)PartCategory.Sexdecillions, (int)NumberType.Singular] = "oktilliarde";
            partWord[(int)PartCategory.Sexdecillions, (int)NumberType.Plural] = "oktilliarden";

            partWord[(int)PartCategory.Septendecillions, (int)NumberType.Singular] = "nonillion";
            partWord[(int)PartCategory.Septendecillions, (int)NumberType.Plural] = "nonillionen";

            partWord[(int)PartCategory.Octodecillions, (int)NumberType.Singular] = "nonilliarde";
            partWord[(int)PartCategory.Octodecillions, (int)NumberType.Plural] = "nonilliarden";

            partWord[(int)PartCategory.Novemdecillions, (int)NumberType.Singular] = "dezillion";
            partWord[(int)PartCategory.Novemdecillions, (int)NumberType.Plural] = "dezillionen";

            partWord[(int)PartCategory.Vigintillions, (int)NumberType.Singular] = "dezilliarde";
            partWord[(int)PartCategory.Vigintillions, (int)NumberType.Plural] = "dezilliarden";

            amountWord[0] = "null";
            amountWord[1] = "ein";
            amountWord[2] = "zwei";
            amountWord[3] = "drei";
            amountWord[4] = "vier";
            amountWord[5] = "fünf";
            amountWord[6] = "sechs";
            amountWord[7] = "sieben";
            amountWord[8] = "acht";
            amountWord[9] = "neun";
            amountWord[10] = "zehn";
            amountWord[11] = "elf";
            amountWord[12] = "zwölf";
            amountWord[13] = "dreizehn";
            amountWord[14] = "vierzehn";
            amountWord[15] = "fünfzehn";
            amountWord[16] = "sechzehn";
            amountWord[17] = "siebzehn";
            amountWord[18] = "achtzehn";
            amountWord[19] = "neunzehn";
            amountWord[20] = "zwanzig";
            amountWord[30] = "dreißig";
            amountWord[40] = "vierzig";
            amountWord[50] = "fünfzig";
            amountWord[60] = "sechzig";
            amountWord[70] = "siebzig";
            amountWord[80] = "achtzig";
            amountWord[90] = "neunzig";
            amountWord[100] = "einhundert";
            amountWord[200] = "zweihundert";
            amountWord[300] = "dreihundert";
            amountWord[400] = "vierhundert";
            amountWord[500] = "fünfhundert";
            amountWord[600] = "sechshundert";
            amountWord[700] = "siebenhundert";
            amountWord[800] = "achthundert";
            amountWord[900] = "neunhundert";

            for (int amountIndex = 21; amountIndex < 100; amountIndex++)
            {
                if (amountWord[amountIndex] == null)
                {
                    amountWord[amountIndex] = amountWord[amountIndex % 10] + conjunctionForParts + amountWord[(amountIndex / 10) * 10];
                }
            }

            for (int amountIndex = 101; amountIndex < 1000; amountIndex++)
            {
                if (amountWord[amountIndex] == null)
                {
                    amountWord[amountIndex] = amountWord[(amountIndex / 100) * 100] + amountWord[amountIndex - ((amountIndex / 100) * 100)];
                }
            }

            conjunctionForParts = " und ";
            amountWord[1] = "eine";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordAmount"/> class.
        /// </summary>
        public WordAmount()
        {
            base.conjunctionForCents = " und ";

            base.currencyWord[(int)NumberType.Singular] = "Mark";
            base.currencyWord[(int)NumberType.Plural] = "Mark";
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

                if (valueAmountWord == "eine"
                    && (addCurrency
                        || parts[partIndex].Category == (int)PartCategory.Cents))
                {
                    valueAmountWord = "ein";
                }

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