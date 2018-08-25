// <copyright file="WordAmount.cs" company="Guerche TI">
//     Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Luciano Evaristo Guerche</author>
// <email>guercheLE@hotmail.com</email>
// <date>August 22nd, 2018 21:49</date>
// <summary>
// Word Amount class which implements Word Amount interface for Spanish.
// </summary>
namespace WordAmount.es
{
    using global::WordAmount.Common;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Word Amount class which implements Word Amount interface for Spanish.
    /// </summary>
    /// <seealso cref="WordAmount.Common.WordAmount"/>
    [Culture(culture: "es")]
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
            conjunctionForParts = " y ";

            partWord[(int)PartCategory.Cents, (int)NumberType.Singular] = "céntimo";
            partWord[(int)PartCategory.Cents, (int)NumberType.Plural] = "céntimos";

            partWord[(int)PartCategory.Units, (int)NumberType.Singular] = string.Empty;
            partWord[(int)PartCategory.Units, (int)NumberType.Plural] = string.Empty;

            partWord[(int)PartCategory.Thousands, (int)NumberType.Singular] = "mil";
            partWord[(int)PartCategory.Thousands, (int)NumberType.Plural] = "mil";

            partWord[(int)PartCategory.Millions, (int)NumberType.Singular] = "millón";
            partWord[(int)PartCategory.Millions, (int)NumberType.Plural] = "millones";

            partWord[(int)PartCategory.Billions, (int)NumberType.Singular] = "mil millones";
            partWord[(int)PartCategory.Billions, (int)NumberType.Plural] = "mil millones";

            partWord[(int)PartCategory.Trillions, (int)NumberType.Singular] = "billón";
            partWord[(int)PartCategory.Trillions, (int)NumberType.Plural] = "billones";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "mil billones";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "mil billones";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "trillón";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "trillones";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "mil trillones";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "mil trillones";

            //partWord[(int)PartCategory.???, (int)NumberType.Singular] = "???";
            //partWord[(int)PartCategory.???, (int)NumberType.Plural] = "???";

            amountWord[0] = "cero";
            amountWord[1] = "uno";
            amountWord[2] = "dos";
            amountWord[3] = "tres";
            amountWord[4] = "cuatro";
            amountWord[5] = "cinco";
            amountWord[6] = "seises";
            amountWord[7] = "siete";
            amountWord[8] = "ocho";
            amountWord[9] = "nueve";
            amountWord[10] = "diez";
            amountWord[11] = "once";
            amountWord[12] = "doce";
            amountWord[13] = "trece";
            amountWord[14] = "catorce";
            amountWord[15] = "quince";
            amountWord[16] = "dieciséis";
            amountWord[17] = "diecisiete";
            amountWord[18] = "dieciocho";
            amountWord[19] = "diecinueve";
            amountWord[20] = "veinte";
            amountWord[21] = "veintiuno";
            amountWord[22] = "veintidós";
            amountWord[23] = "veintitrés";
            amountWord[24] = "veinticuatro";
            amountWord[25] = "veinticinco";
            amountWord[26] = "veintiséis";
            amountWord[27] = "veintisiete";
            amountWord[28] = "veintiocho";
            amountWord[29] = "veintinueve";
            amountWord[30] = "treinta";
            amountWord[40] = "cuarenta";
            amountWord[50] = "cincuenta";
            amountWord[60] = "sesenta";
            amountWord[70] = "setenta";
            amountWord[80] = "ochenta";
            amountWord[90] = "noventa";
            amountWord[100] = "ciento";
            amountWord[200] = "doscientos";
            amountWord[300] = "trescientos";
            amountWord[400] = "cuatrocientos";
            amountWord[500] = "quinientos";
            amountWord[600] = "seiscientos";
            amountWord[700] = "setecientos";
            amountWord[800] = "ochocientos";
            amountWord[900] = "novecientos";

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
                    amountWord[amountIndex] = amountWord[(amountIndex / 100) * 100] + " " + amountWord[amountIndex - ((amountIndex / 100) * 100)];
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordAmount"/> class.
        /// </summary>
        public WordAmount()
        {
            base.conjunctionForCents = " con ";

            base.currencyWord[(int)NumberType.Singular] = "peseta";
            base.currencyWord[(int)NumberType.Plural] = "pesetas";
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
            string valueCurrencyWord = string.Empty;
            bool forceConjunctionForParts = false;

            for (int partIndex = 0; partIndex < parts.Count; partIndex++)
            {
                valueAmountWord = amountWord[parts[partIndex].Value];
                addCurrency = !currencyAdded
                              && ((partIndex == parts.Count - 1 && parts[partIndex].Category != (int)PartCategory.Cents)
                                  || (partIndex < parts.Count - 1 && parts[partIndex + 1].Category == (int)PartCategory.Cents));

                if (addCurrency)
                {
                    valueCurrencyWord = value > 1.99
                                        ? currencyWord[(int)NumberType.Plural]
                                        : currencyWord[(int)NumberType.Singular];

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

                if (parts[partIndex].Category >= PartCategory.Billions
                    && ((int)parts[partIndex].Category - 4) % 2 == 0
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
                                 .Append(valueCurrencyWord);

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