// <copyright file="WordAmount.cs" company="Guerche TI">
//     Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Luciano Evaristo Guerche</author>
// <email>guercheLE@hotmail.com</email>
// <date>August 22nd, 2018 21:48</date>
// <summary>
// Word Amount class which implements Word Amount interface for French.
// </summary>
namespace WordAmount.fr
{
    using global::WordAmount.Common;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Word Amount class which implements Word Amount interface for French.
    /// </summary>
    /// <seealso cref="WordAmount.Common.WordAmount"/>
    [Culture(culture: "fr")]
    public sealed class WordAmount : Common.WordAmount
    {
        #region Private Fields

        /// <summary>
        /// The parts word.
        /// </summary>
        private static readonly string[,] partWord = new string[(int)PartCategory.Septillions + 1, 2];

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
        protected override string ValueMustBeGreaterThanZeroMessage => "La valeur doit être supérieure à zéro.";

        /// <summary>
        /// Highest category supported.
        /// </summary>
        /// <value>The highest category supported.</value>
        protected override PartCategory HighestCategorySupported => (PartCategory)partWord.GetLength(0) - 1;

        /// <summary>
        /// Maximum supported value exception message.
        /// </summary>
        /// <value>The maximum supported value exception message.</value>
        protected override string MaxSupportedValueExceptionMessage => "La valeur la plus élevée prise en charge en français est {0}";

        #endregion Protected Properties

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WordAmount"/> class.
        /// </summary>
        static WordAmount()
        {
            conjunctionForParts = " et ";

            partWord[(int)PartCategory.Cents, (int)NumberType.Singular] = "centime";
            partWord[(int)PartCategory.Cents, (int)NumberType.Plural] = "centimes";

            partWord[(int)PartCategory.Units, (int)NumberType.Singular] = string.Empty;
            partWord[(int)PartCategory.Units, (int)NumberType.Plural] = string.Empty;

            partWord[(int)PartCategory.Thousands, (int)NumberType.Singular] = "mille";
            partWord[(int)PartCategory.Thousands, (int)NumberType.Plural] = "mille";

            partWord[(int)PartCategory.Millions, (int)NumberType.Singular] = "million";
            partWord[(int)PartCategory.Millions, (int)NumberType.Plural] = "millions";

            partWord[(int)PartCategory.Billions, (int)NumberType.Singular] = "milliard";
            partWord[(int)PartCategory.Billions, (int)NumberType.Plural] = "milliards";

            partWord[(int)PartCategory.Trillions, (int)NumberType.Singular] = "billion";
            partWord[(int)PartCategory.Trillions, (int)NumberType.Plural] = "billions";

            partWord[(int)PartCategory.Quadrillions, (int)NumberType.Singular] = "billiard";
            partWord[(int)PartCategory.Quadrillions, (int)NumberType.Plural] = "billiards";

            partWord[(int)PartCategory.Quintillions, (int)NumberType.Singular] = "trillion";
            partWord[(int)PartCategory.Quintillions, (int)NumberType.Plural] = "trillions";

            partWord[(int)PartCategory.Sextillions, (int)NumberType.Singular] = "trilliard";
            partWord[(int)PartCategory.Sextillions, (int)NumberType.Plural] = "trilliards";

            partWord[(int)PartCategory.Septillions, (int)NumberType.Singular] = "quatrillion";
            partWord[(int)PartCategory.Septillions, (int)NumberType.Plural] = "quatrillions";

            amountWord[0] = "zéro";
            amountWord[1] = "un";
            amountWord[2] = "deux";
            amountWord[3] = "trois";
            amountWord[4] = "quatre";
            amountWord[5] = "cinq";
            amountWord[6] = "six";
            amountWord[7] = "sept";
            amountWord[8] = "huit";
            amountWord[9] = "neuf";
            amountWord[10] = "dix";
            amountWord[11] = "onze";
            amountWord[12] = "douze";
            amountWord[13] = "treize";
            amountWord[14] = "quatorze";
            amountWord[15] = "quinze";
            amountWord[16] = "seize";
            amountWord[17] = "dix-sept";
            amountWord[18] = "dix-huit";
            amountWord[19] = "dix-neuf";
            amountWord[20] = "vingt";
            amountWord[21] = "vingt et un";
            amountWord[22] = "vingt-deux";
            amountWord[23] = "vingt-trois";
            amountWord[24] = "vingt-quatre";
            amountWord[25] = "vingt-cinq";
            amountWord[26] = "vingt-six";
            amountWord[27] = "vingt-sept";
            amountWord[28] = "vingt-huit";
            amountWord[29] = "vingt-neuf";
            amountWord[30] = "trente";
            amountWord[31] = "trente et un";
            amountWord[32] = "trente-deux";
            amountWord[33] = "trente-trois";
            amountWord[34] = "trente-quatre";
            amountWord[35] = "trente-cinq";
            amountWord[36] = "trente-six";
            amountWord[37] = "trente-sept";
            amountWord[38] = "trente-huit";
            amountWord[39] = "trente-neuf";
            amountWord[40] = "quarante";
            amountWord[41] = "quarante et un";
            amountWord[42] = "quarante-deux";
            amountWord[43] = "quarante-trois";
            amountWord[44] = "quarante-quatre";
            amountWord[45] = "quarante-cinq";
            amountWord[46] = "quarante-six";
            amountWord[47] = "quarante-sept";
            amountWord[48] = "quarante-huit";
            amountWord[49] = "quarante-neuf";
            amountWord[50] = "cinquante";
            amountWord[51] = "cinquante et un";
            amountWord[52] = "cinquante-deux";
            amountWord[53] = "cinquante-trois";
            amountWord[54] = "cinquante-quatre";
            amountWord[55] = "cinquante-cinq";
            amountWord[56] = "cinquante-six";
            amountWord[57] = "cinquante-sept";
            amountWord[58] = "cinquante-huit";
            amountWord[59] = "cinquante-neuf";
            amountWord[60] = "soixante";
            amountWord[61] = "soixante et un";
            amountWord[62] = "soixante-deux";
            amountWord[63] = "soixante-trois";
            amountWord[64] = "soixante-quatre";
            amountWord[65] = "soixante-cinq";
            amountWord[66] = "soixante-six";
            amountWord[67] = "soixante-sept";
            amountWord[68] = "soixante-huit";
            amountWord[69] = "soixante-neuf";
            amountWord[70] = "soixante-dix";
            amountWord[71] = "soixante et onze";
            amountWord[72] = "soixante-douze";
            amountWord[73] = "soixante-treize";
            amountWord[74] = "soixante-quatorze";
            amountWord[75] = "soixante-quinze";
            amountWord[76] = "soixante-seize";
            amountWord[77] = "soixante-dix-sept";
            amountWord[78] = "soixante-dix-huit";
            amountWord[79] = "soixante-dix-neuf";
            amountWord[80] = "quatre-vingts";
            amountWord[81] = "quatre-vingt et un";
            amountWord[82] = "quatre-vingt-deux";
            amountWord[83] = "quatre-vingt-trois";
            amountWord[84] = "quatre-vingt-quatre";
            amountWord[85] = "quatre-vingt-cinq";
            amountWord[86] = "quatre-vingt-six";
            amountWord[87] = "quatre-vingt-sept";
            amountWord[88] = "quatre-vingt-huit";
            amountWord[89] = "quatre-vingt-neuf";
            amountWord[90] = "quatre-vingt-dix";
            amountWord[91] = "quatre-vingt-onze";
            amountWord[92] = "quatre-vingt-douze";
            amountWord[93] = "quatre-vingt-treize";
            amountWord[94] = "quatre-vingt-quatorze";
            amountWord[95] = "quatre-vingt-quinze";
            amountWord[96] = "quatre-vingt-seize";
            amountWord[97] = "quatre-vingt-dix-sept";
            amountWord[98] = "quatre-vingt-dix-huit";
            amountWord[99] = "quatre-vingt-dix-neuf";
            amountWord[100] = "cent";
            amountWord[200] = "deux cents";
            amountWord[300] = "trois cents";
            amountWord[400] = "quatre cents";
            amountWord[500] = "cinq cents";
            amountWord[600] = "six cents";
            amountWord[700] = "sept cents";
            amountWord[800] = "huit cents";
            amountWord[900] = "neuf cents";

            string hundredWord;

            for (int amountIndex = 101; amountIndex < 1000; amountIndex++)
            {
                if (amountWord[amountIndex] == null)
                {
                    hundredWord = amountWord[(amountIndex / 100) * 100];
                    amountWord[amountIndex] = (hundredWord.EndsWith('s') ? hundredWord.Substring(0, hundredWord.Length - 1) : hundredWord) + " " + amountWord[amountIndex - ((amountIndex / 100) * 100)];
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordAmount"/> class.
        /// </summary>
        public WordAmount()
        {
            base.conjunctionForCents = " et ";

            base.currencyWord[(int)NumberType.Singular] = "franc";
            base.currencyWord[(int)NumberType.Plural] = "francs";
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
                                         ? (parts[partIndex].Category >= PartCategory.Millions
                                            ? (currencyWord[(int)NumberType.Plural] == "Euros"
                                               ? "d'"
                                               : "de ")
                                            : "") + currencyWord[(int)NumberType.Plural]
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