using System.Windows.Controls;

namespace PluginSDK
{
    /// <summary>
    ///  All calculator plugins using Windows Presentation Foundation should implement this abstract class.
    /// </summary>
    public abstract class ICalculatorWPFPlugin : UserControl, ICalculator
    {
        public ICalculatorWPFPlugin()
        {
            
        }

        /// <summary>
        /// Shared data with the calculator and all its plugin.
        /// </summary>
        protected SharedData sharedData;

        #region Method from the ICalculator interface

        /// <summary>
        /// Property for plugin selection name.
        /// </summary>
        /// <returns>Returns the selection name of the plugin.</returns>
        public abstract string SelectionName { get; }

        #endregion

        #region Methods from the IPlugin interface

        /// <summary>
        /// Property for plugin author's name.
        /// </summary>
        /// <returns>Returns the name of the author who created the plugin.</returns>
        public abstract string AuthorName { get; }

        /// <summary>
        /// Property for plugin name.
        /// </summary>
        /// <returns>Returns the name of the plugin.</returns>
        public abstract string PluginName { get; }

        /// <summary>
        /// Property for plugin version.
        /// </summary>
        /// <returns>Returns the version of the plugin.</returns>
        public abstract string PluginVersion { get; }

        #endregion
    }
}
