// <copyright file="WordAmount.cs" company="Guerche TI">
//     Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Luciano Evaristo Guerche</author>
// <email>guercheLE@hotmail.com</email>
// <date>August 22nd, 2018 21:44</date>
// <summary>
// Word Amount class which implements Word Amount interface for Italian.
// </summary>
namespace WordAmount.it
{
    using global::WordAmount.Common;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Word Amount class which implements Word Amount interface for Italian.
    /// </summary>
    /// <seealso cref="WordAmount.Common.WordAmount"/>
    [Culture(culture: "it")]
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
            conjunctionForParts = " e ";

            partWord[(int)PartCategory.Cents, (int)NumberType.Singular] = "centesimo";
            partWord[(int)PartCategory.Cents, (int)NumberType.Plural] = "centesimi";

            partWord[(int)PartCategory.Units, (int)NumberType.Singular] = string.Empty;
            partWord[(int)PartCategory.Units, (int)NumberType.Plural] = string.Empty;

            partWord[(int)PartCategory.Thousands, (int)NumberType.Singular] = "mille";
            partWord[(int)PartCategory.Thousands, (int)NumberType.Plural] = "mila";

            partWord[(int)PartCategory.Millions, (int)NumberType.Singular] = "milione";
            partWord[(int)PartCategory.Millions, (int)NumberType.Plural] = "milioni";

            partWord[(int)PartCategory.Billions, (int)NumberType.Singular] = "miliardo";
            partWord[(int)PartCategory.Billions, (int)NumberType.Plural] = "miliardi";

            partWord[(int)PartCategory.Trillions, (int)NumberType.Singular] = "trilione";
            partWord[(int)PartCategory.Trillions, (int)NumberType.Plural] = "trilioni";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "???";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "???";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "???";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "???";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "???";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "???";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "???";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "???";

            amountWord[0] = "zero";
            amountWord[1] = "uno";
            amountWord[2] = "due";
            amountWord[3] = "tre";
            amountWord[4] = "quattro";
            amountWord[5] = "cinque";
            amountWord[6] = "sei";
            amountWord[7] = "sette";
            amountWord[8] = "otto";
            amountWord[9] = "nove";
            amountWord[10] = "dieci";
            amountWord[11] = "undici";
            amountWord[12] = "dodici";
            amountWord[13] = "tredici";
            amountWord[14] = "quattordici";
            amountWord[15] = "quindici";
            amountWord[16] = "sedici";
            amountWord[17] = "diciassette";
            amountWord[18] = "diciotto";
            amountWord[19] = "diciannove";
            amountWord[20] = "venti";
            amountWord[30] = "trenta";
            amountWord[40] = "quaranta";
            amountWord[50] = "cinquanta";
            amountWord[60] = "sessanta";
            amountWord[70] = "settanta";
            amountWord[80] = "ottanta";
            amountWord[90] = "novanta";
            amountWord[100] = "cento";
            amountWord[200] = "duecento";
            amountWord[300] = "trecento";
            amountWord[400] = "quattrocento";
            amountWord[500] = "cinquecento";
            amountWord[600] = "seicento";
            amountWord[700] = "settecento";
            amountWord[800] = "ottocento";
            amountWord[900] = "novecento";

            string tenthWord;
            string hundredWord;

            for (int amountIndex = 21; amountIndex < 100; amountIndex++)
            {
                if (amountWord[amountIndex] == null)
                {
                    tenthWord = amountWord[amountIndex % 10];
                    hundredWord = amountWord[(amountIndex / 10) * 10];
                    amountWord[amountIndex] = ("aeiou".Contains(tenthWord.Substring(0, 1)) ? hundredWord.Substring(0, hundredWord.Length - 1) : hundredWord) + tenthWord;
                }
            }

            for (int amountIndex = 101; amountIndex < 1000; amountIndex++)
            {
                if (amountWord[amountIndex] == null)
                {
                    amountWord[amountIndex] = amountWord[(amountIndex / 100) * 100] + amountWord[amountIndex - ((amountIndex / 100) * 100)];
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordAmount"/> class.
        /// </summary>
        public WordAmount()
        {
            base.conjunctionForCents = " e ";

            base.currencyWord[(int)NumberType.Singular] = "lira";
            base.currencyWord[(int)NumberType.Plural] = "lire";
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
            string valuePartWord = string.Empty;
            bool forceConjunctionForParts = false;

            for (int partIndex = 0; partIndex < parts.Count; partIndex++)
            {
                valueAmountWord = amountWord[parts[partIndex].Value];
                addCurrency = !currencyAdded
                              && ((partIndex == parts.Count - 1 && parts[partIndex].Category != (int)PartCategory.Cents)
                                  || (partIndex < parts.Count - 1 && parts[partIndex + 1].Category == (int)PartCategory.Cents));

                if (addCurrency)
                {
                    if (valueAmountWord == "uno"
                        && parts[partIndex].Category == PartCategory.Units)
                    {
                        valueAmountWord = "una";
                    }
                }

                if (partIndex == 0
                    && firstLetterUppercase)
                {
                    valueAmountWord = valueAmountWord.Substring(0, 1).ToUpperInvariant() + valueAmountWord.Substring(1, valueAmountWord.Length - 1);
                }

                if (((int)parts[partIndex].Category - 4) % 2 == 0
                    && partIndex + 1 < parts.Count - 1
                    && parts[partIndex].Category == parts[partIndex + 1].Category + 1)
                {
                    valuePartWord = parts[partIndex].Value != 1
                                    ? partWord[(int)PartCategory.Thousands, (int)NumberType.Plural]
                                    : partWord[(int)PartCategory.Thousands, (int)NumberType.Singular];

                    forceConjunctionForParts = true;
                }
                else
                {
                    valuePartWord = parts[partIndex].Value != 1
                                    ? partWord[(int)parts[partIndex].Category, (int)NumberType.Plural]
                                    : partWord[(int)parts[partIndex].Category, (int)NumberType.Singular];

                    forceConjunctionForParts = false;
                }

                valueToReturn.Append(valueAmountWord)
                             .Append((" " + valuePartWord).TrimEnd());

                if (addCurrency)
                {
                    valueToReturn.Append(" ")
                                 .Append(value > 1.99
                                         ? (parts[partIndex].Category >= PartCategory.Millions
                                            ? "di "
                                            : "") + currencyWord[(int)NumberType.Plural]
                                         : currencyWord[(int)NumberType.Singular]);

                    currencyAdded = true;
                }

                if (forceConjunctionForParts
                    || (partIndex == parts.Count - 3
                        && parts[partIndex + 1].Category == PartCategory.Units))
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