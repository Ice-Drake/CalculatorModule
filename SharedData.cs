using System;
using System.Collections.Generic;

namespace PluginSDK
{
    /// <summary>
    ///  This class represents the shared data used by Calculator and all its ICalculator plugins.
    /// </summary>
    public class SharedData
    {
        private static SortedList<string, Numeral> data;

        /// <summary>
        /// Initializes a new instance of the SharedData class along with the initialization of a common shared data if it hasn't been done so already.
        /// </summary>
        public SharedData()
        {
            if (data == null)
            {
                data = new SortedList<string, Numeral>();
            }
        }

        /// <summary>
        /// Clear all common shared data.
        /// </summary>
        public void clear()
        {
            data.Clear();
        }

        /// <summary>
        /// Retrieve the value with the supplied variable name.
        /// </summary>
        /// <param name="varName">Stored variable name.</param>
        /// <returns>Returns the numeral value of the supplied variable name. If the supplied variable name is invalid, return null.</returns>
        public Numeral retrieve(string varName)
        {
            if (data.ContainsKey(varName))
                return data[varName];
            else
                return null;
        }

        /// <summary>
        /// Store the supplied value as the supplied variable name.
        /// </summary>
        /// <param name="varName">Variable name.</param>
        /// <param name="value">Variable value.</param>
        /// <remarks>If the supplied variable name already exists, the original value of the variable will be overwritten.</remarks>
        public void store(string varName, Numeral value)
        {
            if (data.ContainsKey(varName))
                data[varName] = value;
            else
                data.Add(varName, value);
        }
    }
}
