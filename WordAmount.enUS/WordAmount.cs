﻿// <copyright file="WordAmount.cs" company="Guerche TI">
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

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "???";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "???";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "???";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "???";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "???";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "???";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "???";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "???";

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