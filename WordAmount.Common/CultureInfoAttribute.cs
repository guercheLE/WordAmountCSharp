// <copyright file="CultureInfoAttribute.cs" company="Guerche TI">
//     Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Luciano Evaristo Guerche</author>
// <email>guercheLE@hotmail.com</email>
// <date>August 17th, 2018 17:06</date>
// <summary>
// Culture attribute class.
// </summary>
namespace WordAmount.Common
{
    using System;

    /// <summary>
    /// Culture attribute class.
    /// </summary>
    /// <seealso cref="System.Attribute"/>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CultureAttribute : Attribute
    {
        #region Public Properties

        /// <summary>
        /// Gets the culture.
        /// </summary>
        /// <value>The culture.</value>
        public string Culture { get; }

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CultureAttribute"/> class.
        /// </summary>
        /// <param name="culture">The culture.</param>
        public CultureAttribute(string culture)
        {
            Culture = culture;
        }

        #endregion Public Constructors

        #region Private Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="CultureAttribute"/> class from being created.
        /// </summary>
        private CultureAttribute()
        {
        }

        #endregion Private Constructors
    }
}