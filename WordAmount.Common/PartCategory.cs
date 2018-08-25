// <copyright file="NumberType.cs" company="Guerche TI">
//     Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Luciano Evaristo Guerche</author>
// <email>guercheLE@hotmail.com</email>
// <date>August 22nd, 2018 20:04</date>
// <summary>
// Part Category enumeration.
// </summary>
namespace WordAmount.Common
{
    /// <summary>
    /// Part Category enumeration.
    /// </summary>
    public enum PartCategory
    {
        /// <summary>
        /// The cents.
        /// </summary>
        Cents,

        /// <summary>
        /// The units.
        /// </summary>
        Units,

        /// <summary>
        /// The thousands.
        /// </summary>
        Thousands,

        /// <summary>
        /// The millions.
        /// </summary>
        Millions,

        /// <summary>
        /// The billions.
        /// </summary>
        Billions,

        /// <summary>
        /// The trillions.
        /// </summary>
        Trillions
    }
}