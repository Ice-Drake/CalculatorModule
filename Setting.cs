using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using DDay.iCal;

namespace MultiDesktop
{
    public class Setting
    {
        private List<Category> categoryList;
        private SortedList<string, string> calendarList;
        private static Setting setting;
        private string filename;

        private Setting()
        {
            categoryList = new List<Category>();
            calendarList = new SortedList<string, string>();
            filename = "User.config";
            
            SplashScreen.SetStatus("now loading skins");
            SplashScreen.Progress = 0.02;

            SplashScreen.SetStatus("now initializing calendar panel");
            SplashScreen.Progress = 0.12;
            
            SplashScreen.SetStatus("now initializing todo panel");
            SplashScreen.Progress = 0.14;
            
            SplashScreen.SetStatus("now loading ical database");
            SplashScreen.Progress = 0.16;
            initializeCalendar();

            SplashScreen.SetStatus("now loading categories");
            SplashScreen.Progress = 0.36;
            initializeCategory();
        }

        public static void initialize()
        {
            if(setting == null)
                setting = new Setting();
        }

        private XmlNodeList getXmlNodeList(string filename, string expression)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNodeList nodes = doc.SelectNodes(expression);
            return nodes;
        }

        private void initializeCalendar()
        {         
            string calendarAbsPath = System.IO.Path.GetFullPath("Calendars");
            XmlNodeList icalNodes = getXmlNodeList(filename, "/configuration/ical/file");

            // Iterate on the node set
            foreach (XmlNode node in icalNodes)
            {
                string fname = node.Attributes["filename"].Value;
                string name = node.Attributes["name"].Value;
                calendarList.Add(name, fname);
            }
        }

        private void initializeCategory()
        {
            // Iterate on the node set
            try
            {
                XmlNodeList categories = getXmlNodeList(filename, "/configuration/categories/category");
                foreach (XmlNode node in categories)
                {
                    Category newCategory = new Category(Int32.Parse(node.Attributes["id"].Value));
                    newCategory.Name = node.Attributes["name"].Value;
                    newCategory.Color = Color.FromName(node.Attributes["color"].Value);
                    categoryList.Insert(Int32.Parse(node.Attributes["order"].Value) - 1, newCategory);
                }

                XmlNodeList subcategories = getXmlNodeList(filename, "/configuration/categories/subcategory");
                foreach (XmlNode node in subcategories)
                {
                    int index = 0;
                    while (categoryList[index].ID != Int32.Parse(node.Attributes["category"].Value) && ++index <= categoryList.Count) ;
                    Subcategory newSubcategory = new Subcategory(Int32.Parse(node.Attributes["id"].Value), categoryList[index]);
                    newSubcategory.Name = node.Attributes["name"].Value;
                    categoryList[index].Subcategories.Insert(Int32.Parse(node.Attributes["order"].Value) - 1, newSubcategory);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static string findCalendarName(string filename)
        {
            if (setting != null)
            {
                int calIndex = setting.calendarList.IndexOfValue(filename);
                return setting.calendarList.Keys[calIndex];
            }
            return null;
        }

        public static SortedList<string, string> CalendarList
        {
            get
            {
                if (setting != null)
                    return setting.calendarList;
                else
                    return null;
            }
        }
        
        public static List<Category> CategoryList
        {
            get
            {
                if (setting != null)
                    return setting.categoryList;
                else
                    return null;
            }
        }

        /*public static void fillCalendar(ComboBox comboBox)
        {
            IEnumerator<string> cals = calendarList.Keys.GetEnumerator();
            while (cals.MoveNext())
            {
                comboBox.Items.Add(System.IO.Path.GetFileNameWithoutExtension(cals.Current));
            }
        }
        */
        public static void fillCategory(ComboBox comboBox)
        {
            if (setting != null)
            {
                foreach (Category category in setting.categoryList)
                {
                    comboBox.Items.Add(category.Name);
                    foreach (Subcategory subcategory in category.Subcategories)
                    {
                        comboBox.Items.Add(subcategory.Name);
                    }
                }

                if (comboBox.Items.Count > 0)
                    comboBox.SelectedIndex = 0;
            }
        }
        /*
        public static void fillCategory(ComboBox comboBox)
        {
            foreach (Category category in categoryList)
            {
                comboBox.Items.Add(category.Name);
            }

            if (comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
        }

        public static void fillCategory(ListBox listBox)
        {
            foreach (Category category in categoryList)
            {
                listBox.Items.Add(category.Name);
                if (category.Subcategories.Count != 0)
                {
                    foreach (Subcategory subcategory in category.Subcategories)
                    {
                        listBox.Items.Add(subcategory.Name);
                    }
                }
            }
        }

        public static void fillCategory(TreeView treeView)
        {
            foreach (Category category in categoryList)
            {
                TreeNode newNode = new TreeNode(category.Name);
                if (category.Subcategories.Count != 0)
                {
                    foreach (Subcategory subcategory in category.Subcategories)
                    {
                        TreeNode newSubNode = new TreeNode(subcategory.Name);
                        newNode.Nodes.Add(newSubNode);
                    }
                }
                treeView.Nodes.Add(newNode);
            }
        }*/
    }
}