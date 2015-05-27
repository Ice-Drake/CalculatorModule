using System;
using System.Xml;
using System.Configuration;
using PluginSDK;
using System.Collections;
using System.Collections.Generic;

namespace MultiDesktop
{
	/// <summary>
	/// This class implements IConfigurationSectionHandler and allows
	/// us to parse the "plugin" XML nodes found inside App.Config
	/// and return a PluginCollection object
	/// </summary>
	public class PluginSectionHandler:IConfigurationSectionHandler
	{
		public PluginSectionHandler()
		{
		}

		#region IConfigurationSectionHandler Members

		/// <summary>
		/// Iterate through all the child nodes
		///	of the XMLNode that was passed in and create instances
		///	of the specified Types by reading the attribite values of the nodes
		///	we use a try/Catch here because some of the nodes
		///	might contain an invalid reference to a plugin type
		///	</summary>
		/// <param name="parent"></param>
		/// <param name="configContext"></param>
		/// <param name="section">The XML section we will iterate against</param>
		/// <returns></returns>
		public object Create(object parent, object configContext, System.Xml.XmlNode section)
		{
            Dictionary<string, ArrayList> collection = new Dictionary<string, ArrayList>();
            ArrayList projectPlugins = new ArrayList();
            ArrayList databasePlugins = new ArrayList();
            ArrayList panelPlugins = new ArrayList();
			
            foreach(XmlNode node in section.ChildNodes)
			{
				try
				{
                    //Use the Activator class's 'CreateInstance' method
                    //to try and create an instance of the plugin by
                    //passing in the type name specified in the attribute value
                    object plugObject = Activator.CreateInstance(Type.GetType(node.Attributes["name"].Value));

                    //Project Database Plugin
                    if (node.Attributes["type"].Value.Equals("IProjDatabase"))
                    {
                        //Add this to the project plugin list
                        projectPlugins.Add(plugObject);
                    }
                    //Database Plugin
                    else if (node.Attributes["type"].Value.Equals("IDatabasePlugin"))
                    {
                        //Add this to the project plugin list
                        databasePlugins.Add(plugObject);
                    }
                    //Panel Plugin
                    else if (node.Attributes["type"].Value.Equals("IPanelPlugin"))
                    {
                        //Add this to the panel plugin list
                        panelPlugins.Add(plugObject);
                    }
				}
				catch(Exception)
				{
					//Catch any exceptions
					//but continue iterating for more plugins
				}
			}

            collection.Add("IProjDatabase", projectPlugins);
            collection.Add("IDatabasePlugin", databasePlugins);
            collection.Add("IPanelPlugin", panelPlugins);

			return collection;
		}

		#endregion
	}

}
