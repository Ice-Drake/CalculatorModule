using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiDesktop
{
    public class Vision
    {
        public int ID { get; private set; }
        public string Summary { get; set; }
        public string Desc { get; set; }

        public Vision(int id)
        {
            ID = id;
        }
    }
}
