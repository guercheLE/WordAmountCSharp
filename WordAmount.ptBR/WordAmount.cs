// <copyright file="WordAmount.cs" company="Guerche TI">
//     Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Luciano Evaristo Guerche</author>
// <email>guercheLE@hotmail.com</email>
// <date>August 22nd, 2018 21:43</date>
// <summary>
// Word Amount class which implements Word Amount interface for Brazilian Portuguese.
// </summary>
namespace WordAmount.ptBR
{
    using global::WordAmount.Common;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Word Amount class which implements Word Amount interface for Brazilian Portuguese.
    /// </summary>
    /// <seealso cref="WordAmount.Common.WordAmount"/>
    [Culture(culture: "pt-BR")]
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

            partWord[(int)PartCategory.Cents, (int)NumberType.Singular] = "centavo";
            partWord[(int)PartCategory.Cents, (int)NumberType.Plural] = "centavos";

            partWord[(int)PartCategory.Units, (int)NumberType.Singular] = string.Empty;
            partWord[(int)PartCategory.Units, (int)NumberType.Plural] = string.Empty;

            partWord[(int)PartCategory.Thousands, (int)NumberType.Singular] = "mil";
            partWord[(int)PartCategory.Thousands, (int)NumberType.Plural] = "mil";

            partWord[(int)PartCategory.Millions, (int)NumberType.Singular] = "milhão";
            partWord[(int)PartCategory.Millions, (int)NumberType.Plural] = "milhões";

            partWord[(int)PartCategory.Billions, (int)NumberType.Singular] = "bilhão";
            partWord[(int)PartCategory.Billions, (int)NumberType.Plural] = "bilhões";

            partWord[(int)PartCategory.Trillions, (int)NumberType.Singular] = "trilhão";
            partWord[(int)PartCategory.Trillions, (int)NumberType.Plural] = "trilhões";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "???";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "???";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "???";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "???";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "???";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "???";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "???";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "???";

            amountWord[0] = "zero";
            amountWord[1] = "um";
            amountWord[2] = "dois";
            amountWord[3] = "três";
            amountWord[4] = "quatro";
            amountWord[5] = "cinco";
            amountWord[6] = "seis";
            amountWord[7] = "sete";
            amountWord[8] = "oito";
            amountWord[9] = "nove";
            amountWord[10] = "dez";
            amountWord[11] = "onze";
            amountWord[12] = "doze";
            amountWord[13] = "treze";
            amountWord[14] = "quatorze";
            amountWord[15] = "quinze";
            amountWord[16] = "dezesseis";
            amountWord[17] = "dezessete";
            amountWord[18] = "dezoito";
            amountWord[19] = "dezenove";
            amountWord[20] = "vinte";
            amountWord[30] = "trinta";
            amountWord[40] = "quarenta";
            amountWord[50] = "cinqüenta";
            amountWord[60] = "sessenta";
            amountWord[70] = "setenta";
            amountWord[80] = "oitenta";
            amountWord[90] = "noventa";
            amountWord[100] = "cento";
            amountWord[200] = "duzentos";
            amountWord[300] = "trezentos";
            amountWord[400] = "quatrocentos";
            amountWord[500] = "quinhentos";
            amountWord[600] = "seiscentos";
            amountWord[700] = "setecentos";
            amountWord[800] = "oitocentos";
            amountWord[900] = "novecentos";

            for (int amountIndex = 21; amountIndex < 100; amountIndex++)
            {
                if (amountWord[amountIndex] == null)
                {
                    amountWord[amountIndex] = amountWord[(amountIndex / 10) * 10] + conjunctionForParts + amountWord[amountIndex % 10];
                }
            }

            for (int amountIndex = 101; amountIndex < 1000; amountIndex++)
            {
                if (amountWord[amountIndex] == null)
                {
                    amountWord[amountIndex] = amountWord[(amountIndex / 100) * 100] + conjunctionForParts + amountWord[amountIndex - ((amountIndex / 100) * 100)];
                }
            }

            amountWord[100] = "cem";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordAmount"/> class.
        /// </summary>
        public WordAmount()
        {
            base.conjunctionForCents = " e ";

            base.currencyWord[(int)NumberType.Singular] = "real";
            base.currencyWord[(int)NumberType.Plural] = "reais";
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
                                         ? (parts[partIndex].Category >= PartCategory.Millions
                                            ? "de "
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