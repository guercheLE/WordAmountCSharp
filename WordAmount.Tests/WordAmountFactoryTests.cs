// <copyright file="WordAmountFactoryTests.cs" company="Guerche TI">
//     Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Luciano Evaristo Guerche</author>
// <email>guercheLE@hotmail.com</email>
// <date>August 22nd, 2018 22:10</date>
// <summary>
// Word Amount Factory Tests.
// </summary>
namespace WordAmount.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Globalization;
    using WordAmount.Common;

    /// <summary>
    /// Word Amount Factory Tests.
    /// </summary>
    [TestClass]
    public class WordAmountFactoryTests
    {
        #region Public Methods

        /// <summary>
        /// Available Cultures test.
        /// </summary>
        [TestMethod]
        public void AvailableCulturesTest()
        {
            CultureInfo[] availableCultures = WordAmountFactory.AvailableCultures();
            Assert.IsTrue(availableCultures.Length > 0);
        }

        /// <summary>
        /// Create function test with invalid culture.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTestWithInvalidCulture()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("il"));
        }

        /// <summary>
        /// Create function test with available culture.
        /// </summary>
        [TestMethod]
        public void CreateTestWithAvailableCulture()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(WordAmountFactory.AvailableCultures()[0]);
            Assert.IsNotNull(wordAmount);
        }

        /// <summary>
        /// Get function test with value zero (which is out of supported range).
        /// </summary>
        /// <param name="culture">The culture.</param>
        [DataTestMethod]
        [DataRow("de")]
        [DataRow("en-US")]
        [DataRow("es")]
        [DataRow("fr")]
        [DataRow("it")]
        [DataRow("pt-BR")]
        [ExpectedException(typeof(ArgumentException))]
        public void GetTestWithZeroValue(string culture)
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo(culture));
            wordAmount.Get(0.00, true);
        }

        /// <summary>
        /// Get function test with double's max value (which is out of supported range).
        /// </summary>
        /// <param name="culture">The culture.</param>
        [DataTestMethod]
        [DataRow("de")]
        [DataRow("en-US")]
        [DataRow("es")]
        [DataRow("fr")]
        [DataRow("it")]
        [DataRow("pt-BR")]
        [ExpectedException(typeof(ApplicationException))]
        public void GetTestWithDoubleMaxValue(string culture)
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo(culture));
            wordAmount.Get(double.MaxValue, true);
        }

        /// <summary>
        /// Get function test with valid value.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="value">The value.</param>
        /// <param name="expectedResult">The expected result.</param>
        [DataTestMethod]
        [DataRow("de", 0.01, "Ein Pfennig")]
        [DataRow("de", 1.00, "Ein Mark")]
        [DataRow("de", 1000.00, "Ein Tausend Mark")]
        [DataRow("de", 1000000.00, "Ein Million Mark")]
        [DataRow("de", 1001001.01, "Eine Million, eine Tausend und ein Mark und ein Pfennig")]
        [DataRow("de", 254743062813.00, "Zweihundertvierundfünfzig Milliarden, siebenhundertdreiundvierzig Millionen, zweiundsechzig Tausend und achthundertdreizehn Mark")]
        [DataRow("en-US", 0.01, "One cent")]
        [DataRow("en-US", 1.00, "One dollar")]
        [DataRow("en-US", 1000.00, "One thousand dollars")]
        [DataRow("en-US", 1000000.00, "One million dollars")]
        [DataRow("en-US", 1001001.01, "One million, one thousand and one dollars and one cent")]
        [DataRow("en-US", 254743062813.00, "Two hundred fifty-four billion, seven hundred forty-three million, sixty-two thousand and eight hundred thirteen dollars")]
        [DataRow("es", 0.01, "Uno céntimo")]
        [DataRow("es", 1.00, "Una peseta")]
        [DataRow("es", 1000.00, "Uno mil pesetas")]
        [DataRow("es", 1000000.00, "Uno millón pesetas")]
        [DataRow("es", 1001001.01, "Uno millón, uno mil y una pesetas con uno céntimo")]
        [DataRow("es", 254743062813.00, "Doscientos cincuenta y cuatro mil y setecientos cuarenta y tres millones, sesenta y dos mil y ochocientos trece pesetas")]
        [DataRow("es", 1002034056.00, "Uno mil y dos millones, treinta y cuatro mil y cincuenta y seises pesetas")]
        [DataRow("es", 2001034056.00, "Dos mil y uno millón, treinta y cuatro mil y cincuenta y seises pesetas")]
        [DataRow("fr", 0.01, "Un centime")]
        [DataRow("fr", 1.00, "Un franc")]
        [DataRow("fr", 1000.00, "Un mille francs")]
        [DataRow("fr", 1000000.00, "Un million de francs")]
        [DataRow("fr", 1001001.01, "Un million, un mille et un francs et un centime")]
        [DataRow("fr", 254743062813.00, "Deux cent cinquante-quatre milliards, sept cent quarante-trois millions, soixante-deux mille et huit cent treize francs")]
        [DataRow("it", 0.01, "Uno centesimo")]
        [DataRow("it", 1.00, "Una lira")]
        [DataRow("it", 1000.00, "Uno mille lire")]
        [DataRow("it", 1000000.00, "Uno milione di lire")]
        [DataRow("it", 1001001.01, "Uno milione, uno mille e una lire e uno centesimo")]
        [DataRow("it", 254743062813.00, "Duecentocinquantaquattro mila e settecentoquarantatre milioni, sessantadue mila e ottocentotredici lire")]
        [DataRow("it", 1002034056.00, "Uno mille e due milioni, trentaquattro mila e cinquantasei lire")]
        [DataRow("it", 2001034056.00, "Due mila e uno milione, trentaquattro mila e cinquantasei lire")]
        [DataRow("pt-BR", 0.01, "Um centavo")]
        [DataRow("pt-BR", 1.00, "Um real")]
        [DataRow("pt-BR", 1000.00, "Um mil reais")]
        [DataRow("pt-BR", 1000000.00, "Um milhão de reais")]
        [DataRow("pt-BR", 1001001.01, "Um milhão, um mil e um reais e um centavo")]
        [DataRow("pt-BR", 254743062813.00, "Duzentos e cinqüenta e quatro bilhões, setecentos e quarenta e três milhões, sessenta e dois mil e oitocentos e treze reais")]
        public void GetTestWithValidValue(string culture, double value, string expectedResult)
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo(culture));
            string actualResult = wordAmount.Get(value, true);
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Get function test with currency changed.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="value">The value.</param>
        /// <param name="expectedResult">The expected result.</param>
        [DataTestMethod]
        [DataRow("de", 1.00, "Ein Euro")]
        [DataRow("fr", 1.00, "Un Euro")]
        [DataRow("fr", 1000000.00, "Un million d'Euros")]
        public void GetTestWithCurrencyChanged(string culture, double value, string expectedResult)
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo(culture));

            wordAmount.CurrencyWordSingular = "Euro";
            Assert.AreEqual("Euro", wordAmount.CurrencyWordSingular);

            wordAmount.CurrencyWordPlural = "Euros";
            Assert.AreEqual("Euros", wordAmount.CurrencyWordPlural);

            string actualResult = wordAmount.Get(value, true);
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Get function test with culture pt-BR with changed cunjunction for cents.
        /// </summary>
        [TestMethod]
        public void GetTestWithCulturePTBRWithChangedCunjunctionForCents()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("pt-BR"));

            wordAmount.ConjunctionForCents = " com ";
            Assert.AreEqual(" com ", wordAmount.ConjunctionForCents);

            string actual = wordAmount.Get(1.01, true);
            Assert.AreEqual("Um real com um centavo", actual);
        }

        #endregion Public Methods
    }
}