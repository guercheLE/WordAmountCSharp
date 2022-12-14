// <copyright file="WordAmountFactory.cs" company="Guerche TI">
//     Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Luciano Evaristo Guerche</author>
// <email>guercheLE@hotmail.com</email>
// <date>August 17th, 2018 16:51</date>
// <summary>
// Word Amount factory class.
// </summary>
namespace WordAmount
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Loader;
    using WordAmount.Common;

    /// <summary>
    /// Word Amount factory class.
    /// </summary>
    public static class WordAmountFactory
    {
        #region Private Fields

        /// <summary>
        /// The available word amount dictionary.
        /// </summary>
        private static readonly Dictionary<string, Type> availableWordAmount;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes the <see cref="WordAmountFactory"/> class.
        /// </summary>
        static WordAmountFactory()
        {
            availableWordAmount = new Dictionary<string, Type>();

            string location = Assembly.GetExecutingAssembly().Location;
            string assemblyPath = Path.GetDirectoryName(new Uri(location).LocalPath);

            foreach (string libraryName in Directory.GetFiles(assemblyPath, "*.dll"))
            {
                Assembly assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(libraryName);
                foreach (Type wordAmountType in assembly.GetTypes().Where(t => typeof(IWordAmount).IsAssignableFrom(t) && t.CustomAttributes.Any(ca => ca.AttributeType == typeof(CultureAttribute))))
                {
                    CustomAttributeData culture = wordAmountType.CustomAttributes.First(ca => ca.AttributeType == typeof(CultureAttribute));
                    availableWordAmount.Add(culture.ConstructorArguments[0].Value.ToString(), wordAmountType);
                }
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Available cultures.
        /// </summary>
        /// <returns>The available cultures.</returns>
        public static CultureInfo[] AvailableCultures()
        {
            return availableWordAmount.Select(awa => new CultureInfo(awa.Key)).ToArray();
        }

        /// <summary>
        /// Creates the word amount class with specified culture.
        /// </summary>
        /// <param name="culture">
        /// The specified culture to create the word amount object targeted to.
        /// </param>
        /// <returns>The Word Amount with specified culture implementation.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static IWordAmount Create(CultureInfo culture)
        {
            bool awaFound = availableWordAmount.TryGetValue(culture.Name, out Type type);
            if (!awaFound)
            {
                throw new ArgumentException($"Word Amount for culture '{culture.Name}' not found/available");
            }
            return Activator.CreateInstance(type) as IWordAmount;
        }

        #endregion Public Methods
    }
}