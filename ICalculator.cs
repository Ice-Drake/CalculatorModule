using System;

namespace PluginSDK
{
    /// <summary>
    ///  All calculator plugins will implement this interface.
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Property for plugin selection name.
        /// </summary>
        /// <returns>Returns the selection name of the plugin.</returns>
        string SelectionName { get; }
    }
}
