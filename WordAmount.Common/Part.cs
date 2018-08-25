// <copyright file="WordAmount.cs" company="Guerche TI">
//     Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Luciano Evaristo Guerche</author>
// <email>guercheLE@hotmail.com</email>
// <date>August 24nd, 2018 22:18</date>
// <summary>
// Part class.
// </summary>
namespace WordAmount.Common
{
    /// <summary>
    /// Part class.
    /// </summary>
    public class Part
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public PartCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value { get; set; }

        #endregion Public Properties
    }
}