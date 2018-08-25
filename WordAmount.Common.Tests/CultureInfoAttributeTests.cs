// <copyright file="CultureInfoAttributeTests.cs" company="Guerche TI">
//     Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Luciano Evaristo Guerche</author>
// <email>guercheLE@hotmail.com</email>
// <date>August 24th, 2018 23:11</date>
// <summary>
// Culture Info Attribute Tests.
// </summary>
namespace WordAmount.Common.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Culture Info Attribute Tests.
    /// </summary>
    [TestClass]
    public class CultureInfoAttributeTests
    {
        #region Public Methods

        [TestMethod]
        public void ConstructorAndCulturePropertyTest()
        {
            CultureAttribute cultureAttribute = new CultureAttribute("en-US");
            Assert.AreEqual("en-US", cultureAttribute.Culture);
        }

        #endregion Public Methods
    }
}