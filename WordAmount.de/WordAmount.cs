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
    public class WordAmount : Common.WordAmount
    {
        #region Protected Fields

        /// <summary>
        /// The parts word.
        /// </summary>
        protected static readonly string[,] partWord = new string[6, 2];

        /// <summary>
        /// The amounts word.
        /// </summary>
        protected static readonly string[] amountWord = new string[1000];

        /// <summary>
        /// The conjunction for cents.
        /// </summary>
        protected static readonly string conjunctionForParts;

        #endregion Protected Fields

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

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "Billiarde";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "Billiarden";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "Trillion";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "Trillionen";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "Trilliarde";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "Trilliarden";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "Quartillion";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "Quartillionen";

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
        /// <param name="value">The value.</param>
        /// <param name="parts">The parts.</param>
        /// <param name="firstLetterUppercase">if set to <c>true</c> [first letter uppercase].</param>
        /// <returns>The value into word amount format.</returns>
        protected override string Get(double value, IList<Part> parts, bool firstLetterUppercase = false)
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
                                 .Append(value > 1.99
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