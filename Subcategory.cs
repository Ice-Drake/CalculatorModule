using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MultiDesktop
{
    public class Subcategory
    {
        private int id;
        private string name;
        private Category category;

        public Subcategory(int id, Category category)
        {
            this.id = id;
            this.category = category;
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

        public Category Category
        {
            get
            {
                return category;
            }
        }
    }
}
