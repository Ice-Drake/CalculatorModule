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

                    Subcategory newSubcategory = new Subcategory(name, categoryList[categoryName]);
                    subcategoryList.Add(name, newSubcategory);
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

            SqlCommand command = new SqlCommand("INSERT INTO Subcategory (Name, Category) VALUES (@Name, @Category)", dbConnection);

            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters["@Name"].Value = subcategory.Name;

            command.Parameters.Add("@Category", SqlDbType.VarChar);
            command.Parameters["@Category"].Value = subcategory.Category.Name;

            dbConnection.Open();
            command.ExecuteNonQuery();
            dbConnection.Close();
            
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

                SqlCommand command = new SqlCommand("UPDATE Subcategory SET Name = @NewName WHERE Name = @OldName", dbConnection);

                command.Parameters.Add("@OldName", SqlDbType.VarChar);
                command.Parameters["@OldName"].Value = oldName;

                command.Parameters.Add("@NewName", SqlDbType.VarChar);
                command.Parameters["@NewName"].Value = newName;

                dbConnection.Open();
                command.ExecuteNonQuery();
                dbConnection.Close();

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

                SqlCommand command = new SqlCommand("DELETE FROM Subcategory WHERE Name = @Name", dbConnection);

                command.Parameters.Add("@Name", SqlDbType.VarChar);
                command.Parameters["@Name"].Value = name;

                dbConnection.Open();
                command.ExecuteNonQuery();
                dbConnection.Close();

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
