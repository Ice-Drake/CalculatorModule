using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MultiDesktop
{
    public class CategoryManager
    {
        private SortedList<string, Category> categoryList;
        private SortedList<string, Subcategory> subcategoryList;
        private SqlConnection dbConnection;

        public CategoryManager()
        {
            categoryList = new SortedList<string, Category>();
            subcategoryList = new SortedList<string, Subcategory>();

            dbConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Setting.mdf;Integrated Security=True");
        }

        public void loadDatabase()
        {
            SqlCommand categoryCommand = new SqlCommand("SELECT * FROM Category", dbConnection);
            dbConnection.Open();
            SqlDataReader categoryReader = categoryCommand.ExecuteReader();

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

            SqlCommand subcategoryCommand = new SqlCommand("SELECT * FROM Subcategory", dbConnection);
            SqlDataReader subcategoryReader = subcategoryCommand.ExecuteReader();

            try
            {
                while (subcategoryReader.Read())
                {
                    string name = subcategoryReader[0].ToString();
                    string categoryName = subcategoryReader[1].ToString();

                    if (!addSubcategory(new Subcategory(name, categoryList[categoryName])))
                    {
                        System.Windows.Forms.MessageBox.Show("Corrupted Subcategory Database! Click OK to proceed on restoring it.");

                        subcategoryList.Clear();
                        //Remove and reconstruct Calendar Table.
                    }
                }
            }
            finally
            {
                subcategoryReader.Close();
            }

            dbConnection.Close();
        }

        public void updateCategory(string name)
        {
            Category category = categoryList[name];
            SqlCommand command = new SqlCommand("UPDATE Category SET Color = @color WHERE Name = @name", dbConnection);
            command.Parameters.AddWithValue("@color", category.Color.ToString());
            command.Parameters.AddWithValue("@name", category.Name);

            dbConnection.Open();
            command.ExecuteNonQuery();
            dbConnection.Close();
        }

        public bool addSubcategory(Subcategory subcategory)
        {
            if (categoryList.ContainsKey(subcategory.Name) || subcategoryList.ContainsKey(subcategory.Name))
                return false;
            
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
            return categoryList[name];
        }

        public Subcategory getSubcategory(string name)
        {
            return subcategoryList[name];
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
