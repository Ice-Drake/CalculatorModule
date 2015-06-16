﻿using System;
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
                    case 0: // Convert degree to gradian
                        return value;
                    case 1: // Convert degree to radian
                        return value * 10 / 9;
                    case 2: // Convert degree to radian
                        return 0;
                    default: // Invalid unit
                        return 0;
                }
            }
            return 0; // Invalid unit
        }

        public double convertArea(int from, int to, double value)
        {
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
