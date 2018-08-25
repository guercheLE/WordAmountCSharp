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
        /// Get function test with culture DE #001.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureDE001()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("de"));
            string actual = wordAmount.Get(0.00, true);
            Assert.AreEqual(string.Empty, actual);
        }

        /// <summary>
        /// Get function test with culture DE #002.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureDE002()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("de"));
            string actual = wordAmount.Get(0.01, true);
            Assert.AreEqual("Ein Pfennig", actual);
        }

        /// <summary>
        /// Get function test with culture DE #003.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureDE003()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("de"));
            string actual = wordAmount.Get(1.00, true);
            Assert.AreEqual("Ein Mark", actual);
        }

        /// <summary>
        /// Get function test with culture DE #004.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureDE004()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("de"));

            wordAmount.CurrencyWordSingular = "Euro";
            Assert.AreEqual("Euro", wordAmount.CurrencyWordSingular);

            wordAmount.CurrencyWordPlural = "Euros";
            Assert.AreEqual("Euros", wordAmount.CurrencyWordPlural);

            string actual = wordAmount.Get(1.00, true);
            Assert.AreEqual("Ein Euro", actual);
        }

        /// <summary>
        /// Get function test with culture DE #005.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureDE005()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("de"));
            string actual = wordAmount.Get(1000.00, true);
            Assert.AreEqual("Ein Tausend Mark", actual);
        }

        /// <summary>
        /// Get function test with culture DE #006.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureDE006()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("de"));
            string actual = wordAmount.Get(1000000.00, true);
            Assert.AreEqual("Ein Million Mark", actual);
        }

        /// <summary>
        /// Get function test with culture DE #007.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureDE007()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("de"));
            string actual = wordAmount.Get(1001001.01, true);
            Assert.AreEqual("Eine Million, eine Tausend und ein Mark und ein Pfennig", actual);
        }

        /// <summary>
        /// Get function test with culture DE #008.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureDE008()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("de"));
            string actual = wordAmount.Get(254743062813.00, true);
            Assert.AreEqual("Zweihundertvierundfünfzig Milliarden, siebenhundertdreiundvierzig Millionen, zweiundsechzig Tausend und achthundertdreizehn Mark", actual);
        }

        /// <summary>
        /// Get function test with culture en-US #001.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureENUS001()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("en-US"));
            string actual = wordAmount.Get(0.01, true);
            Assert.AreEqual("One cent", actual);
        }

        /// <summary>
        /// Get function test with culture en-US #002.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureENUS002()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("en-US"));
            string actual = wordAmount.Get(1.00, true);
            Assert.AreEqual("One dollar", actual);
        }

        /// <summary>
        /// Get function test with culture ENUS #003.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureENUS003()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("en-US"));
            string actual = wordAmount.Get(1000.00, true);
            Assert.AreEqual("One thousand dollars", actual);
        }

        /// <summary>
        /// Get function test with culture ENUS #004.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureENUS004()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("en-US"));
            string actual = wordAmount.Get(1000000.00, true);
            Assert.AreEqual("One million dollars", actual);
        }

        /// <summary>
        /// Get function test with culture ENUS #005.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureENUS005()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("en-US"));
            string actual = wordAmount.Get(1001001.01, true);
            Assert.AreEqual("One million, one thousand and one dollars and one cent", actual);
        }

        /// <summary>
        /// Get function test with culture ENUS #006.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureENUS006()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("en-US"));
            string actual = wordAmount.Get(254743062813.00, true);
            Assert.AreEqual("Two hundred fifty-four billion, seven hundred forty-three million, sixty-two thousand and eight hundred thirteen dollars", actual);
        }

        /// <summary>
        /// Get function test with culture ES #001.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureES001()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("es"));
            string actual = wordAmount.Get(0.01, true);
            Assert.AreEqual("Uno céntimo", actual);
        }

        /// <summary>
        /// Get function test with culture ES #002.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureES002()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("es"));
            string actual = wordAmount.Get(1.00, true);
            Assert.AreEqual("Una peseta", actual);
        }

        /// <summary>
        /// Get function test with culture ES #003.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureES003()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("es"));
            string actual = wordAmount.Get(1000.00, true);
            Assert.AreEqual("Uno mil pesetas", actual);
        }

        /// <summary>
        /// Get function test with culture ES #004.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureES004()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("es"));
            string actual = wordAmount.Get(1000000.00, true);
            Assert.AreEqual("Uno millón pesetas", actual);
        }

        /// <summary>
        /// Get function test with culture ES #005.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureES005()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("es"));
            string actual = wordAmount.Get(1001001.01, true);
            Assert.AreEqual("Uno millón, uno mil y una pesetas con uno céntimo", actual);
        }

        /// <summary>
        /// Get function test with culture ES #006.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureES006()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("es"));
            string actual = wordAmount.Get(1002034056.00, true);
            Assert.AreEqual("Uno mil y dos millones, treinta y cuatro mil y cincuenta y seises pesetas", actual);
        }

        /// <summary>
        /// Get function test with culture ES #007.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureES007()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("es"));
            string actual = wordAmount.Get(2001034056.00, true);
            Assert.AreEqual("Dos mil y uno millón, treinta y cuatro mil y cincuenta y seises pesetas", actual);
        }

        /// <summary>
        /// Get function test with culture ES #008.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureES008()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("es"));
            string actual = wordAmount.Get(254743062813.00, true);
            Assert.AreEqual("Doscientos cincuenta y cuatro mil y setecientos cuarenta y tres millones, sesenta y dos mil y ochocientos trece pesetas", actual);
        }

        /// <summary>
        /// Get function test with culture FR #001.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureFR001()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("fr"));
            string actual = wordAmount.Get(0.01, true);
            Assert.AreEqual("Un centime", actual);
        }

        /// <summary>
        /// Get function test with culture FR #002.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureFR002()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("fr"));
            string actual = wordAmount.Get(1.00, true);
            Assert.AreEqual("Un franc", actual);
        }

        /// <summary>
        /// Get function test with culture FR #003.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureFR003()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("fr"));
            string actual = wordAmount.Get(1000.00, true);
            Assert.AreEqual("Un mille francs", actual);
        }

        /// <summary>
        /// Get function test with culture FR #004.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureFR004()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("fr"));
            string actual = wordAmount.Get(1000000.00, true);
            Assert.AreEqual("Un milliard de francs", actual);
        }

        /// <summary>
        /// Get function test with culture FR #005.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureFR005()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("fr"));
            string actual = wordAmount.Get(1001001.01, true);
            Assert.AreEqual("Un milliard, un mille et un francs et un centime", actual);
        }

        /// <summary>
        /// Get function test with culture FR #006.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureFR006()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("fr"));
            string actual = wordAmount.Get(254743062813.00, true);
            Assert.AreEqual("Deux cent cinquante-quatre mil millones, sept cent quarante-trois milliards, soixante-deux mille et huit cent treize francs", actual);
        }

        /// <summary>
        /// Get function test with culture FR #007.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureFR007()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("fr"));
            wordAmount.CurrencyWordSingular = "Euro";
            wordAmount.CurrencyWordPlural = "Euros";
            string actual = wordAmount.Get(1000000.00, true);
            Assert.AreEqual("Un milliard d'Euros", actual);
        }

        /// <summary>
        /// Get function test with culture IT #001.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureIT001()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("it"));
            string actual = wordAmount.Get(0.01, true);
            Assert.AreEqual("Uno centesimo", actual);
        }

        /// <summary>
        /// Get function test with culture IT #002.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureIT002()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("it"));
            string actual = wordAmount.Get(1.00, true);
            Assert.AreEqual("Una lira", actual);
        }

        /// <summary>
        /// Get function test with culture IT #003.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureIT003()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("it"));
            string actual = wordAmount.Get(1000.00, true);
            Assert.AreEqual("Uno mille lire", actual);
        }

        /// <summary>
        /// Get function test with culture IT #004.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureIT004()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("it"));
            string actual = wordAmount.Get(1000000.00, true);
            Assert.AreEqual("Uno milione di lire", actual);
        }

        /// <summary>
        /// Get function test with culture IT #005.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureIT005()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("it"));
            string actual = wordAmount.Get(1001001.01, true);
            Assert.AreEqual("Uno milione, uno mille e una lire e uno centesimo", actual);
        }

        /// <summary>
        /// Get function test with culture IT #006.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureIT006()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("it"));
            string actual = wordAmount.Get(1002034056.00, true);
            Assert.AreEqual("Uno mille e due milioni, trentaquattro mila e cinquantasei lire", actual);
        }

        /// <summary>
        /// Get function test with culture IT #007.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureIT007()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("it"));
            string actual = wordAmount.Get(2001034056.00, true);
            Assert.AreEqual("Due mila e uno milione, trentaquattro mila e cinquantasei lire", actual);
        }

        /// <summary>
        /// Get function test with culture IT #008.
        /// </summary>
        [TestMethod]
        public void GetTestWithCultureIT008()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("it"));
            string actual = wordAmount.Get(254743062813.00, true);
            Assert.AreEqual("Duecentocinquantaquattro mila e settecentoquarantatre milioni, sessantadue mila e ottocentotredici lire", actual);
        }

        /// <summary>
        /// Get function test with culture pt-BR #001.
        /// </summary>
        [TestMethod]
        public void GetTestWithCulturePTBR001()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("pt-BR"));
            string actual = wordAmount.Get(0.01, true);
            Assert.AreEqual("Um centavo", actual);
        }

        /// <summary>
        /// Get function test with culture pt-BR #002.
        /// </summary>
        [TestMethod]
        public void GetTestWithCulturePTBR002()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("pt-BR"));
            string actual = wordAmount.Get(1.00, true);
            Assert.AreEqual("Um real", actual);
        }

        /// <summary>
        /// Get function test with culture PTBR #003.
        /// </summary>
        [TestMethod]
        public void GetTestWithCulturePTBR003()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("pt-BR"));
            string actual = wordAmount.Get(1000.00, true);
            Assert.AreEqual("Um mil reais", actual);
        }

        /// <summary>
        /// Get function test with culture PTBR #004.
        /// </summary>
        [TestMethod]
        public void GetTestWithCulturePTBR004()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("pt-BR"));
            string actual = wordAmount.Get(1000000.00, true);
            Assert.AreEqual("Um milhão de reais", actual);
        }

        /// <summary>
        /// Get function test with culture PTBR #005.
        /// </summary>
        [TestMethod]
        public void GetTestWithCulturePTBR005()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("pt-BR"));
            string actual = wordAmount.Get(1001001.01, true);
            Assert.AreEqual("Um milhão, um mil e um reais e um centavo", actual);
        }

        /// <summary>
        /// Get function test with culture PTBR #006.
        /// </summary>
        [TestMethod]
        public void GetTestWithCulturePTBR006()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("pt-BR"));
            string actual = wordAmount.Get(254743062813.00, true);
            Assert.AreEqual("Duzentos e cinqüenta e quatro bilhões, setecentos e quarenta e três milhões, sessenta e dois mil e oitocentos e treze reais", actual);
        }

        /// <summary>
        /// Get function test with culture pt-BR #007.
        /// </summary>
        [TestMethod]
        public void GetTestWithCulturePTBR007()
        {
            IWordAmount wordAmount = WordAmountFactory.Create(CultureInfo.GetCultureInfo("pt-BR"));
            string actual = wordAmount.Get(1.01, true);
            Assert.AreEqual("Um real e um centavo", actual);
        }

        /// <summary>
        /// Get function test with culture pt-BR #008.
        /// </summary>
        [TestMethod]
        public void GetTestWithCulturePTBR008()
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