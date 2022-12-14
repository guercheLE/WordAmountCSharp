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
    using System;
    using System.Globalization;
    using WordAmount.Common;
    using Xunit;

    /// <summary>
    /// Word Amount Factory Tests.
    /// </summary>
    public class WordAmountFactoryTests
    {
        #region Public Methods

        /// <summary>
        /// Available Cultures test.
        /// </summary>
        [Fact]
        public void AvailableCulturesTest()
        {
            CultureInfo[] availableCultures = WordAmountFactory.AvailableCultures();
            Assert.True(availableCultures.Length > 0);
        }

        /// <summary>
        /// Create function test with invalid culture.
        /// </summary>
        [Fact]
        public void CreateTestWithInvalidCulture()
        {
            Assert.Throws<ArgumentException>(() => _ = WordAmountFactory.Create(CultureInfo.GetCultureInfo("il")));
        }

        /// <summary>
        /// Create function test with available culture.
        /// </summary>
        [Fact]
        public void CreateTestWithAvailableCulture()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(WordAmountFactory.AvailableCultures()[0]);
            Assert.NotNull(wordAmount);
        }

        /// <summary>
        /// Get function test with value zero (which is out of supported range).
        /// </summary>
        /// <param name="culture">The culture.</param>
        [Theory]
        [InlineData("de")]
        [InlineData("en-US")]
        [InlineData("es")]
        [InlineData("fr")]
        [InlineData("it")]
        [InlineData("pt-BR")]
        public void GetTestWithZeroValue(string culture)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo(culture));
                wordAmount.Get(0.00, true);
            });
        }

        /// <summary>
        /// Get function test with double's max value (which is out of supported range).
        /// </summary>
        /// <param name="culture">The culture.</param>
        [Theory]
        [InlineData("de")]
        [InlineData("en-US")]
        [InlineData("es")]
        [InlineData("fr")]
        [InlineData("it")]
        [InlineData("pt-BR")]
        public void GetTestWithDoubleMaxValue(string culture)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo(culture));
                wordAmount.Get(double.MaxValue, true);
            });
        }

        /// <summary>
        /// Get function test with valid value.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="value">The value.</param>
        /// <param name="expectedResult">The expected result.</param>
        [Theory]
        [InlineData("de", 0.01, "Ein Pfennig")]
        [InlineData("de", 1.00, "Ein Mark")]
        [InlineData("de", 1000.00, "Ein Tausend Mark")]
        [InlineData("de", 1000000.00, "Ein Million Mark")]
        [InlineData("de", 1001001.01, "Eine Million, eine Tausend und ein Mark und ein Pfennig")]
        [InlineData("de", 254743062813.00, "Zweihundertvierundfünfzig Milliarden, siebenhundertdreiundvierzig Millionen, zweiundsechzig Tausend und achthundertdreizehn Mark")]
        [InlineData("en-US", 0.01, "One cent")]
        [InlineData("en-US", 1.00, "One dollar")]
        [InlineData("en-US", 1000.00, "One thousand dollars")]
        [InlineData("en-US", 1000000.00, "One million dollars")]
        [InlineData("en-US", 1001001.01, "One million, one thousand and one dollars and one cent")]
        [InlineData("en-US", 254743062813.00, "Two hundred fifty-four billion, seven hundred forty-three million, sixty-two thousand and eight hundred thirteen dollars")]
        [InlineData("es", 0.01, "Uno céntimo")]
        [InlineData("es", 1.00, "Una peseta")]
        [InlineData("es", 1000.00, "Uno mil pesetas")]
        [InlineData("es", 1000000.00, "Uno millón pesetas")]
        [InlineData("es", 1001001.01, "Uno millón, uno mil y una pesetas con uno céntimo")]
        [InlineData("es", 254743062813.00, "Doscientos cincuenta y cuatro mil y setecientos cuarenta y tres millones, sesenta y dos mil y ochocientos trece pesetas")]
        [InlineData("es", 1002034056.00, "Uno mil y dos millones, treinta y cuatro mil y cincuenta y seises pesetas")]
        [InlineData("es", 2001034056.00, "Dos mil y uno millón, treinta y cuatro mil y cincuenta y seises pesetas")]
        [InlineData("fr", 0.01, "Un centime")]
        [InlineData("fr", 1.00, "Un franc")]
        [InlineData("fr", 1000.00, "Un mille francs")]
        [InlineData("fr", 1000000.00, "Un million de francs")]
        [InlineData("fr", 1001001.01, "Un million, un mille et un francs et un centime")]
        [InlineData("fr", 254743062813.00, "Deux cent cinquante-quatre milliards, sept cent quarante-trois millions, soixante-deux mille et huit cent treize francs")]
        [InlineData("it", 0.01, "Uno centesimo")]
        [InlineData("it", 1.00, "Una lira")]
        [InlineData("it", 1000.00, "Uno mille lire")]
        [InlineData("it", 1000000.00, "Uno milione di lire")]
        [InlineData("it", 1001001.01, "Uno milione, uno mille e una lire e uno centesimo")]
        [InlineData("it", 254743062813.00, "Duecentocinquantaquattro mila e settecentoquarantatre milioni, sessantadue mila e ottocentotredici lire")]
        [InlineData("it", 1002034056.00, "Uno mille e due milioni, trentaquattro mila e cinquantasei lire")]
        [InlineData("it", 2001034056.00, "Due mila e uno milione, trentaquattro mila e cinquantasei lire")]
        [InlineData("pt-BR", 0.01, "Um centavo")]
        [InlineData("pt-BR", 1.00, "Um real")]
        [InlineData("pt-BR", 1000.00, "Um mil reais")]
        [InlineData("pt-BR", 1000000.00, "Um milhão de reais")]
        [InlineData("pt-BR", 1001001.01, "Um milhão, um mil e um reais e um centavo")]
        [InlineData("pt-BR", 254743062813.00, "Duzentos e cinqüenta e quatro bilhões, setecentos e quarenta e três milhões, sessenta e dois mil e oitocentos e treze reais")]
        public void GetTestWithValidValue(string culture, double value, string expectedResult)
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo(culture));
            string actualResult = wordAmount.Get(value, true);
            Assert.Equal(expectedResult, actualResult);
        }

        /// <summary>
        /// Get function test with currency changed.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="value">The value.</param>
        /// <param name="expectedResult">The expected result.</param>
        [Theory]
        [InlineData("de", 1.00, "Ein Euro")]
        [InlineData("fr", 1.00, "Un Euro")]
        [InlineData("fr", 1000000.00, "Un million d'Euros")]
        public void GetTestWithCurrencyChanged(string culture, double value, string expectedResult)
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo(culture));

            wordAmount.CurrencyWordSingular = "Euro";
            Assert.Equal("Euro", wordAmount.CurrencyWordSingular);

            wordAmount.CurrencyWordPlural = "Euros";
            Assert.Equal("Euros", wordAmount.CurrencyWordPlural);

            string actualResult = wordAmount.Get(value, true);
            Assert.Equal(expectedResult, actualResult);
        }

        /// <summary>
        /// Get function test with culture pt-BR with changed cunjunction for cents.
        /// </summary>
        [Fact]
        public void GetTestWithCulturePTBRWithChangedCunjunctionForCents()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("pt-BR"));

            wordAmount.ConjunctionForCents = " com ";
            Assert.Equal(" com ", wordAmount.ConjunctionForCents);

            string actual = wordAmount.Get(1.01, true);
            Assert.Equal("Um real com um centavo", actual);
        }

        #endregion Public Methods
    }
}