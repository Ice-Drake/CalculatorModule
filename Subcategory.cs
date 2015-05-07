using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MultiDesktop
{
    public class Subcategory
    {
        public Subcategory(string name, Category category)
        {
            Name = name;
            Category = category;
            category.Subcategories.Add(this);
        }

        public string Name
        {
            get;
            internal set;
        }

        public Category Category
        {
            get;
            private set;
        }
    }
}
