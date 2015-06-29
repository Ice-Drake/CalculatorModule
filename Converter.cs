using System;
using System.Collections.Generic;

namespace MultiDesktop
{
    public class Converter
    {
        public Converter() { }

        public double convertAngle(int from, int to, double value)
        {
            if (from == 0)
            {
                switch(to)
                {
                    case 0: // Convert degree to degree
                        return value;
                    case 1: // Convert degree to gradian
                        return value * 10 / 9;
                    case 2: // Convert degree to radian
                        return value * Math.PI / 180.0;
                    default: // Invalid unit
                        return 0;
                }
            }

            else if (from == 1)
            {
                switch (to)
                {
                    case 0: //Convert degree to degree
                        return value;
                    case 1: //Convert gradian to degree
                        return value * 9 / 10;
                    case 2: //Convert degree to radian
                        return value * Math.PI / 180.0;
                    default: // Invalid unit
                        return 0;
                }
            }

            else if (from == 2)
            {
                switch (to)
                {
                    case 0: //Convert degree to degree
                        return value;
                    case 1: //Convert degree to gradian
                        return value * 10 / 9;
                    case 2: //Convert radian to degree
                        return value * 180.0 / Math.PI;
                    default: // Invalid unit
                        return 0;
                }
            }

            return 0; // Invalid unit
        }

        public double convertArea(int from, int to, double value)
        {
            if (from == 0)
            {
                switch(to)
                {
                    case 0: //Convert square inches to square inches
                        return value;
                    case 1: //Convert square inches to acres
                        return value / 6272640;
                    case 2: //Convert square inches to hectares
                        return value / 15500000;
                    case 3: //Convert square inches to square centimeters
                        return value / 6.4516;
                    case 4: //Convert square inches to square feet
                        return value / 144.0;
                    default: //Invalid unit
                        return 0;
                }
            }

            return 0;
        }

        public double convertLength(int from, int to, double value)
        {
            return 0;
        }

        public double convertTemp(int from, int to, double value)
        {
            return 0;
        }

        public double convertVolume(int from, int to, double value)
        {
            return 0;
        }

        public double convertWeight(int from, int to, double value)
        {
            return 0;
        }
    }
}
