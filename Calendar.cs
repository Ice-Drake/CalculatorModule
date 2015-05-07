using System;
using System.Collections.Generic;
using DDay.iCal;

namespace MultiDesktop
{
    public class Calendar
    {
        public Calendar(int id, string filename)
        {
            ID = id;
            Filename = filename;
            Included = true;
        }

        public int ID { get; private set; }
        public string Name { get; set; }
        public string Filename { get; private set; }
        public bool Included { get; set; }
        public IICalendar IICalendar { get; set; }
    }
}
