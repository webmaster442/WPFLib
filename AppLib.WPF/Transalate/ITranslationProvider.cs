﻿using System.Collections.Generic;
using System.Globalization;

namespace AppLib.WPF.Transalate
{
    /// <summary>
    /// Interface for translation providers
    /// </summary>
    public interface ITranslationProvider
    {
        /// <summary>
        /// Translates the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        object Translate(string key);

        /// <summary>
        /// Gets the available languages.
        /// </summary>
        /// <value>The available languages.</value>
        IEnumerable<CultureInfo> Languages { get; }

    }
}
