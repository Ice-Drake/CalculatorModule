using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MultiDesktop
{
    public class Category
    {
        public Category(string name)
        {
            Name = name;
            Subcategories = new List<Subcategory>();
        }

        public string Name
        {
            get;
            internal set;
        }

        public Color Color
        {
            get;
            set;
        }

        public List<Subcategory> Subcategories
        {
            get;
            internal set;
        }
    }
}
