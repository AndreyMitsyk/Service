using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class Filter
    {
        private static readonly string[] Hashtag = new[] { "#akvelon", "#Akvelon"};
        private static readonly string[] Username = new[] { "Akvelon" , "AkvelonRU", "Sevenmi007"};

        /// <summary>
        /// Check hashtag.
        /// </summary>
        /// <param name="text">tag</param>
        /// <returns>bool value</returns>
        public bool Hashcheck(string text)
        {
            return Hashtag.Any(text.Contains);
        }

        /// <summary>
        /// Check username.
        /// </summary>
        /// <param name="text">name</param>
        /// <returns>bool value</returns>
        public bool Usercheck(string text)
        {
            return Username.Any(text.Contains);
        }
    }
}
