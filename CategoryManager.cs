using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace MultiDesktop
{
    public class CategoryManager
    {
        private SortedList<string, Category> categoryList;
        private SortedList<string, Subcategory> subcategoryList;
        private SQLiteConnection connection;

        public CategoryManager()
        {
            categoryList = new SortedList<string, Category>();
            subcategoryList = new SortedList<string, Subcategory>();

            connection = new SQLiteConnection("Data Source=Setting.sqlite;Version=3;");
        }

        public void loadDatabase()
        {
            SQLiteCommand categoryCommand = new SQLiteCommand("SELECT * FROM Category", connection);
            connection.Open();
            SQLiteDataReader categoryReader = categoryCommand.ExecuteReader();

            try
            {
                while (categoryReader.Read())
                {
                    string name = categoryReader[0].ToString();
                    string colorName = categoryReader[1].ToString();

                    Category newCategory = new Category(name);
                    newCategory.Color = Color.FromName(colorName);
                    categoryList.Add(name, newCategory);
                }
            }
            finally
            {
                categoryReader.Close();
            }

            SQLiteCommand subcategoryCommand = new SQLiteCommand("SELECT * FROM Subcategory", connection);
            SQLiteDataReader subcategoryReader = subcategoryCommand.ExecuteReader();

            try
            {
                while (subcategoryReader.Read())
                {
                    string name = subcategoryReader[0].ToString();
                    string categoryName = subcategoryReader[1].ToString();

                    Subcategory newSubcategory = new Subcategory(name, categoryList[categoryName]);
                    subcategoryList.Add(name, newSubcategory);
                }
            }
            finally
            {
                subcategoryReader.Close();
            }

            connection.Close();
        }

        public void updateCategory(string name)
        {
            Category category = categoryList[name];
            
            string query = String.Format("UPDATE Category SET Color = '{0}' WHERE Name = '{1}'", category.Color.ToString(), category.Name);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public bool addSubcategory(Subcategory subcategory)
        {
            if (categoryList.ContainsKey(subcategory.Name) || subcategoryList.ContainsKey(subcategory.Name))
                return false;

            string query = String.Format("INSERT INTO Subcategory (Name, Category) VALUES ('{0}', '{1}')", subcategory.Name, subcategory.Category.Name);
            SQLiteCommand command = new SQLiteCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            
            subcategoryList.Add(subcategory.Name, subcategory);

            if (CategoryModified != null)
                CategoryModified(this, new EventArgs());

            return true;
        }

        public bool renameSubcategory(string newName, string oldName)
        {
            if (categoryList.ContainsKey(newName) || subcategoryList.ContainsKey(newName))
                return false;
            else if (subcategoryList.ContainsKey(oldName))
            {
                Subcategory subcategory = subcategoryList[oldName];
                subcategoryList.Remove(oldName);

                string query = String.Format("UPDATE Subcategory SET Name = '{0}' WHERE Name = '{1}'", newName, oldName);
                SQLiteCommand command = new SQLiteCommand(query, connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                subcategory.Name = newName;
                subcategoryList.Add(newName, subcategory);
                return true;
            }

            return false;
        }

        public bool deleteSubcategory(string name)
        {
            if (subcategoryList.ContainsKey(name))
            {
                subcategoryList.Remove(name);

                string query = String.Format("DELETE FROM Subcategory WHERE Name = '{0}'", name);
                SQLiteCommand command = new SQLiteCommand(query, connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                if (CategoryModified != null)
                    CategoryModified(this, new EventArgs());

                return true;
            }
            else
                return false;
        }

        public List<string> getCategoryList()
        {
            List<string> catList = new List<string>();
            catList.AddRange(categoryList.Keys);
            catList.AddRange(subcategoryList.Keys);

            return catList;
        }

        public Category getCategory(string name)
        {
            if (categoryList.ContainsKey(name))
                return categoryList[name];
            else
                return null;
        }

        public Subcategory getSubcategory(string name)
        {
            if (subcategoryList.ContainsKey(name))
                return subcategoryList[name];
            else
                return null;
        }

        public List<TreeNode> CategoryNodeList
        {
            get
            {
                List<TreeNode> treeNodeList = new List<TreeNode>();
                
                foreach (Category category in categoryList.Values)
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
                    treeNodeList.Add(newNode);
                }

                return treeNodeList;
            }
        }

        public event EventHandler CategoryModified;
    }
}
