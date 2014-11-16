using System;
using System.Collections.Generic;
using DDay.iCal;

namespace MultiDesktop
{
    public class Calendar
    {
        public Calendar(string name, string filename)
        {
            Name = name;
            Filename = filename;
            Included = true;
        }

        public string Name { get; set; }
        public string Filename { get; private set; }
        public bool Included { get; set; }
        public IICalendar IICalendar { get; set; }
    }
}
