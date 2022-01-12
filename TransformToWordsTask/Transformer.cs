using System;
using System.Collections.Generic;
using System.Globalization;

#pragma warning disable CA1822

namespace TransformToWordsTask
{
    /// <summary>
    /// Provides transformer methods.
    /// </summary>
    public sealed class Transformer
    {
        private readonly Dictionary<double, string> transformEx = new Dictionary<double, string>()
            {
                { double.NaN, "NaN" }, { double.NegativeInfinity, "Negative Infinity" },
                { double.PositiveInfinity, "Positive Infinity" }, { double.Epsilon, "Double Epsilon" },
            };

        private readonly Dictionary<char, string> transformToWords = new Dictionary<char, string>()
            {
                { '-', "minus " }, { '0', "zero " },
                { '1', "one " }, { '2', "two " },
                { '3', "three " }, { '4', "four " },
                { '5', "five " }, { '6', "six " },
                { '7', "seven " }, { '8', "eight " },
                { '9', "nine " }, { 'E', "E " },
                { '.', "point " }, { '+', "plus " },
            };

        /// <summary>
        /// Converts number's digital representation into words.
        /// </summary>
        /// <param name="number">Number to convert.</param>
        /// <returns>Words representation.</returns>
        public string TransformToWords(double number)
        {
            if (this.transformEx.ContainsKey(number))
            {
                return this.transformEx[number];
            }

            string numberToStr = number.ToString(CultureInfo.InvariantCulture);
            string words = string.Empty;         
            foreach (char ch in numberToStr)
            {
                if (this.transformToWords.ContainsKey(ch))
                {
                    words = string.Concat(words, this.transformToWords[ch]);
                }
            }

            words = words[..1].ToUpper(CultureInfo.InvariantCulture) + words[1..];
            return words.Trim();
        }        
    }
}
