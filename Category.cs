using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MultiDesktop
{
    public class Category
    {
        private int id;
        private string name;
        private Color color;
        private List<Subcategory> subcategories;

        public Category(int id)
        {
            this.id = id;
            subcategories = new List<Subcategory>();
        }

        public int ID
        {
            get
            {
                return id;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public List<Subcategory> Subcategories
        {
            get
            {
                return subcategories;
            }
        }
    }
}
