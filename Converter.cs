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
                    case 0: // Convert gradian to degree
                        return value * 9 / 10;
                    case 1: // Convert gradian to gradian
                        return value;
                    case 2: // Convert gradian to radian
                        return value * Math.PI / 200;
                    default: // Invalid unit
                        return 0;
                }
            }

            else if (from == 2)
            {
                switch (to)
                {
                    case 0: // Convert radian to degree
                        return value * 180 / Math.PI;
                    case 1: // Convert radian to gradian
                        return value * 200 / Math.PI;
                    case 2: // Convert radian to radian
                        return value;
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
                switch (to)
                {
                    case 0: // Convert acres to acres
                        return value;
                    case 1: // Convert acres to hectares
                        return value / 2.4711;
                    case 2: // Convert acres to square centimeters
                        return value / (2.4710538 * Math.Pow(10, 8));
                    case 3: // Convert acres to square inches
                        return value * 6272600;
                    case 4: // Convert acres to square kilometers
                        return value / 247.11;
                    case 5: // Convert acres to square meters
                        return value / 0.00024711;
                    case 6: // Convert acres to square miles
                        return value * 0.0015625;
                    case 7: // Convert acres to square millimeters
                        return value / (2.4710538 * Math.Pow(10, -10));
                    case 8: // Convert acres to square yards
                        return value * 4840;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 1)
            {
                switch (to)
                {
                    case 0: // Convert hectares to acres
                        return value * 2.4711;
                    case 1: // Convert hectares to hectares
                        return value;
                    case 2: // Convert hectares to square centimeters
                        return value / (1 * Math.Pow(10, -8));
                    case 3: // Convert hectares to square inches
                        return value * 15500000;
                    case 4: // Convert hectares to square kilometers
                        return value / 100;
                    case 5: // Convert hectares to square meters
                        return value / 0.0001000;
                    case 6: // Convert hectares to square miles
                        return value * 0.0038610;
                    case 7: // Convert hectares to square millimeters
                        return value / (1 * Math.Pow(10, -10));
                    case 8: // Convert hectares to square yards
                        return value * 11960;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 2)
            {
                switch (to)
                {
                    case 0: // Convert square centimeters to acres
                        return value * 2.4710538 * Math.Pow(10, 8);
                    case 1: // Convert square centimeters to hectares
                        return value * 1 * Math.Pow(10, -8);
                    case 2: // Convert square centimeters to square centimeters
                        return value;
                    case 3: // Convert square centimeters to square inches
                        return value * 0.15500;
                    case 4: // Convert square centimeters to square kilometers
                        return value / 10000000000;
                    case 5: // Convert square centimeters to square meters
                        return value / 10000;
                    case 6: // Convert square centimeters to square miles
                        return value * 3.8610216 * Math.Pow(10, -11);
                    case 7: // Convert square centimeters to square millimeters
                        return value / 0.01000;
                    case 8: // Convert square centimeters to square yards
                        return value * 0.00011960;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 3)
            {
                switch (to)
                {
                    case 0: // Convert square inches to acres
                        return value / 6272600;
                    case 1: // Convert square inches to hectares
                        return value / 15500000;
                    case 2: // Convert square inches to square centimeters
                        return value / 0.15500;
                    case 3: // Convert square inches to square inches
                        return value;
                    case 4: // Convert square inches to square kilometers
                        return value / 1550000000;
                    case 5: // Convert square inches to square meters
                        return value / 0.00024711;
                    case 6: // Convert square inches to square miles
                        return value / 1550;
                    case 7: // Convert square inches to square millimeters
                        return value / 0.0015500;
                    case 8: // Convert square inches to square yards
                        return value * 0.00077160;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 4)
            {
                switch (to)
                {
                    case 0: // Convert square kilometers to acres
                        return value * 247.11;
                    case 1: // Convert square kilometers to hectares
                        return value * 100;
                    case 2: // Convert square kilometers to square centimeters
                        return value * 10000000000;
                    case 3: // Convert square kilometers to square inches
                        return value * 1550000000;
                    case 4: // Convert square kilometers to square kilometers
                        return value;
                    case 5: // Convert square kilometers to square meters
                        return value / (1 * Math.Pow(10, 6));
                    case 6: // Convert square kilometers to square miles
                        return value * 0.38610;
                    case 7: // Convert square kilometers to square millimeters
                        return value / (1 * Math.Pow(10, -12));
                    case 8: // Convert square kilometers to square yards
                        return value * 1196000;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 5)
            {
                switch (to)
                {
                    case 0: // Convert square meters to acres
                        return value * 0.00024711;
                    case 1: // Convert square meters to hectares
                        return value * 0.0001000;
                    case 2: // Convert square meters to square centimeters
                        return value * 10000;
                    case 3: // Convert square meters to square inches
                        return value * 0.00024711;
                    case 4: // Convert square meters to square kilometers
                        return value * 1 * Math.Pow(10, 6);
                    case 5: // Convert square meters to square meters
                        return value;
                    case 6: // Convert square meters to square miles
                        return value / (3.8610216 * Math.Pow(10, -7));
                    case 7: // Convert square meters to square millimeters
                        return value / (1 * Math.Pow(10, -6));
                    case 8: // Convert square meters to square yards
                        return value * 1.1960;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 6)
            {
                switch (to)
                {
                    case 0: // Convert square miles to acres
                        return value * 640;
                    case 1: // Convert square miles to hectares
                        return value / 0.0038610;
                    case 2: // Convert square miles to square centimeters
                        return value / (3.8610216 * Math.Pow(10, -11));
                    case 3: // Convert square miles to square inches
                        return value * 4014500000;
                    case 4: // Convert square miles to square kilometers
                        return value / 0.38610;
                    case 5: // Convert square miles to square meters
                        return value / (3.8610216 * Math.Pow(10, -7));
                    case 6: // Convert square miles to square miles
                        return value;
                    case 7: // Convert square miles to square millimeters
                        return value / (3.8610216 * Math.Pow(10, -13));
                    case 8: // Convert square miles to square yards
                        return value * 3097600;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 7)
            {
                switch (to)
                {
                    case 0: // Convert square millimeters to acres
                        return value * 2.4710538 * Math.Pow(10, -10);
                    case 1: // Convert square millimeters to hectares
                        return value / 10000000000;
                    case 2: // Convert square millimeters to square centimeters
                        return value / 100;
                    case 3: // Convert square millimeters to square inches
                        return value * 0.0015500;
                    case 4: // Convert square millimeters to square kilometers
                        return value / 1000000000000;
                    case 5: // Convert square millimeters to square meters
                        return value / 1000000;
                    case 6: // Convert square millimeters to square miles
                        return value * 3.8610216 * Math.Pow(10, -13);
                    case 7: // Convert square millimeters to square millimeters
                        return value;
                    case 8: // Convert square millimeters to square yards
                        return value * 1.19599 * Math.Pow(10, -6);
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 8)
            {
                switch (to)
                {
                    case 0: // Convert square yards to acres
                        return value * 0.00020661;
                    case 1: // Convert square yards to hectares
                        return value / 11960;
                    case 2: // Convert square yards to square centimeters
                        return value / 0.00011960;
                    case 3: // Convert square yards to square inches
                        return value * 1296;
                    case 4: // Convert square yards to square kilometers
                        return value / 1196000;
                    case 5: // Convert square yards to square meters
                        return value / 1.1960;
                    case 6: // Convert square yards to square miles
                        return value * 3.22830592229032 * Math.Pow(10, -7);
                    case 7: // Convert square yards to square millimeters
                        return value / (1.19599 * Math.Pow(10, -6));
                    case 8: // Convert square yards to square yards
                        return value;
                    default: // Invalid unit
                        return 0;
                }
            }
            return 0;
        }

        public double convertLength(int from, int to, double value)
        {
            if (from == 0)
            {
                switch (to)
                {
                    case 0: // Convert angstroms to angstroms
                        return value;
                    case 1: // Convert angstroms to centimeters
                        return value / 100000000;
                    case 2: // Convert angstroms to chains
                        return value / (4.970969538 * Math.Pow(10, -12));
                    case 3: // Convert angstroms to fathoms
                        return value / (1.8288 * Math.Pow(10, 10));
                    case 4: // Convert angstroms to feet
                        return value / 3048000000;
                    case 5: // Convert angstroms to hands
                        return value / 1016000000;
                    case 6: // Convert angstroms to inches
                        return value / 250000000;
                    case 7: // Convert angstroms to kilometers
                        return value / (1 * Math.Log10(13));
                    case 8: // Convert angstroms to links
                        return value / 2011684023.3678832;
                    case 9: // Convert angstroms to meters
                        return value / (1 * Math.Pow(10, 10));
                    case 10: // Convert angstroms to microns
                        return value / 10000;
                    case 11: // Convert angstroms to miles
                        return value / (1.609347219 * Math.Pow(10, 13));
                    case 12: // Convert angstroms to millimeters
                        return value / 10000000;
                    case 13: // Convert angstroms to nanometers
                        return value / 10;
                    case 14: // Convert angstroms to nautical miles
                        return value / (1.852 * Math.Pow(10, 13));
                    case 15: // Convert angstroms to PICAs
                        return value / 42333333.333333;
                    case 16: // Convert angstroms to rods
                        return value / (5.0292 * Math.Pow(10, 10));
                    case 17: // Convert angstroms to spans
                        return value / 2286000000;
                    case 18: // Convert angstroms to yards
                        return value / 9144000000;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 1)
            {
                switch (to)
                {
                    case 0: // Convert centimeters to angstroms
                        return value * 100000000;
                    case 1: // Convert centimeters to centimeters
                        return value;
                    case 2: // Convert centimeters to chains
                        return value / 2011.684;
                    case 3: // Convert centimeters to fathoms
                        return value / 182.88;
                    case 4: // Convert centimeters to feet
                        return value / 0.032808;
                    case 5: // Convert centimeters to hands
                        return value / 10.16;
                    case 6: // Convert centimeters to inches
                        return value / 0.39370;
                    case 7: // Convert centimeters to kilometers
                        return value / 100000;
                    case 8: // Convert centimeters to links
                        return value / 20.1168;
                    case 9: // Convert centimeters to meters
                        return value / 100;
                    case 10: // Convert centimeters to microns
                        return value / 0.00010000;
                    case 11: // Convert centimeters to miles
                        return value / (6.2137119 * Math.Pow(10, -6));
                    case 12: // Convert centimeters to millimeters
                        return value / 0.10000;
                    case 13: // Convert centimeters to nanometers
                        return value / 0.0000001;
                    case 14: // Convert centimeters to nautical miles
                        return value / 185200;
                    case 15: // Convert centimeters to PICAs
                        return value / 0.423333333;
                    case 16: // Convert centimeters to rods
                        return value / 502.92;
                    case 17: // Convert centimeters to spans
                        return value / 22.86;
                    case 18: // Convert centimeters to yards
                        return value / 0.010936;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 2)
            {
                switch (to)
                {
                    case 0: // Convert chains to angstroms
                        return value * 4.970969538 * Math.Pow(10, -12);
                    case 1: // Convert chains to centimeters
                        return value * 2011.684;
                    case 2: // Convert chains to chains
                        return value;
                    case 3: // Convert chains to fathoms
                        return value / 0.0909091;
                    case 4: // Convert chains to feet
                        return value / 0.015151515;
                    case 5: // Convert chains to hands
                        return value / 0.005050505;
                    case 6: // Convert chains to inches
                        return value / 792;
                    case 7: // Convert chains to kilometers
                        return value / 49.709695379;
                    case 8: // Convert chains to links
                        return value / 0.01;
                    case 9: // Convert chains to meters
                        return value / 0.049710;
                    case 10: // Convert chains to microns
                        return value / 0.00000005;
                    case 11: // Convert chains to miles
                        return value / 80;
                    case 12: // Convert chains to millimeters
                        return value / (4.9709596 * Math.Pow(10, -5));
                    case 13: // Convert chains to nanometers
                        return value / (4.970959596 * Math.Pow(10, -11));
                    case 14: // Convert chains to nautical miles
                        return value / 92.0624;
                    case 15: // Convert chains to PICAs
                        return value / 0.000210438;
                    case 16: // Convert chains to rods
                        return value / 0.25;
                    case 17: // Convert chains to spans
                        return value / 0.011363614;
                    case 18: // Convert chains to yards
                        return value / 0.045454545;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 3)
            {
                switch (to)
                {
                    case 0: // Convert fathoms to angstroms
                        return value * 1.8288 * Math.Pow(10, 10);
                    case 1: // Convert fathoms to centimeters
                        return value * 182.88;
                    case 2: // Convert fathoms to chains
                        return value * 0.0909091;
                    case 3: // Convert fathoms to fathoms
                        return value;
                    case 4: // Convert fathoms to feet
                        return value / 0.166666667;
                    case 5: // Convert fathoms to hands
                        return value / 0.055555556;
                    case 6: // Convert fathoms to inches
                        return value / 0.0138889;
                    case 7: // Convert fathoms to kilometers
                        return value / 546.806649169;
                    case 8: // Convert fathoms to links
                        return value / 0.11;
                    case 9: // Convert fathoms to meters
                        return value / 0.546806649;
                    case 10: // Convert fathoms to microns
                        return value / 0.000000547;
                    case 11: // Convert fathoms to miles
                        return value / 880;
                    case 12: // Convert fathoms to millimeters
                        return value / 0.000546807;
                    case 13: // Convert fathoms to nanometers
                        return value / (5.468066492 * Math.Pow(10, -10));
                    case 14: // Convert fathoms to nautical miles
                        return value / 1012.6859142605401;
                    case 15: // Convert fathoms to PICAs
                        return value / 0.002314815;
                    case 16: // Convert fathoms to rods
                        return value / 2.75;
                    case 17: // Convert fathoms to spans
                        return value / 0.125;
                    case 18: // Convert fathoms to yards
                        return value / 0.5;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 4)
            {
                switch (to)
                {
                    case 0: // Convert feet to angstroms
                        return value * 3048000000;
                    case 1: // Convert feet to centimeters
                        return value * 0.032808;
                    case 2: // Convert feet to chains
                        return value * 0.015151515;
                    case 3: // Convert feet to fathoms
                        return value * 0.166666667;
                    case 4: // Convert feet to feet
                        return value;
                    case 5: // Convert feet to hands
                        return value / 0.333333;
                    case 6: // Convert feet to inches
                        return value / 0.0833333;
                    case 7: // Convert feet to kilometers
                        return value / 3280.84;
                    case 8: // Convert feet to links
                        return value / 0.659449;
                    case 9: // Convert feet to meters
                        return value / 3.28084;
                    case 10: // Convert feet to microns
                        return value / 304800;
                    case 11: // Convert feet to miles
                        return value / 5280;
                    case 12: // Convert feet to millimeters
                        return value / 0.00328084;
                    case 13: // Convert feet to nanometers
                        return value / (3.2808 * Math.Pow(10, -9));
                    case 14: // Convert feet to nautical miles
                        return value / 6076.12;
                    case 15: // Convert feet to PICAs
                        return value / 0.013888889;
                    case 16: // Convert feet to rods
                        return value / 16.5;
                    case 17: // Convert feet to spans
                        return value / 0.75;
                    case 18: // Convert feet to yards
                        return value / 3;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 5)
            {
                switch (to)
                {
                    case 0: // Convert hands to angstroms
                        return value * 1016000000;
                    case 1: // Convert hands to centimeters
                        return value * 10.16;
                    case 2: // Convert hands to chains
                        return value * 0.005050505;
                    case 3: // Convert hands to fathoms
                        return value * 0.055555556;
                    case 4: // Convert hands to feet
                        return value * 0.333333;
                    case 5: // Convert hands to hands
                        return value;
                    case 6: // Convert hands to inches
                        return value / 0.25;
                    case 7: // Convert hands to kilometers
                        return value / 9842.52;
                    case 8: // Convert hands to links
                        return value / 1.98000396;
                    case 9: // Convert hands to meters
                        return value / 9.84252;
                    case 10: // Convert hands to microns
                        return value / (9.8425 * Math.Pow(10, -6));
                    case 11: // Convert hands to miles
                        return value / 15840;
                    case 12: // Convert hands to millimeters
                        return value / 0.00984252;
                    case 13: // Convert hands to nanometers
                        return value / (9.8425 * Math.Pow(10, -9));
                    case 14: // Convert hands to nautical miles
                        return value / 18228.3;
                    case 15: // Convert hands to PICAs
                        return value / 0.041666667;
                    case 16: // Convert hands to rods
                        return value / 49.5;
                    case 17: // Convert hands to spans
                        return value / 2.25;
                    case 18: // Convert hands to yards
                        return value / 9;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 6)
            {
                switch (to)
                {
                    case 0: // Convert inches to angstroms
                        return value * 254000000;
                    case 1: // Convert inches to centimeters
                        return value * 0.39370;
                    case 2: // Convert inches to chains
                        return value * 792;
                    case 3: // Convert inches to fathoms
                        return value * 0.0138889;
                    case 4: // Convert inches to feet
                        return value * 0.0833333;
                    case 5: // Convert inches to hands
                        return value * 0.25;
                    case 6: // Convert inches to inches
                        return value;
                    case 7: // Convert inches to kilometers
                        return value / 39370.1;
                    case 8: // Convert inches to links
                        return value / 7.91339;
                    case 9: // Convert inches to meters
                        return value / 39.3701;
                    case 10: // Convert inches to microns
                        return value / (3.937 * Math.Pow(10, -5));
                    case 11: // Convert inches to miles
                        return value / 63360;
                    case 12: // Convert inches to millimeters
                        return value / 0.0393701;
                    case 13: // Convert inches to nanometers
                        return value / (3.937 * Math.Pow(10, -8));
                    case 14: // Convert inches to nautical miles
                        return value / 72913.4;
                    case 15: // Convert inches to PICAs
                        return value / 0.166666667;
                    case 16: // Convert inches to rods
                        return value / 198;
                    case 17: // Convert inches to spans
                        return value / 9;
                    case 18: // Convert inches to yards
                        return value / 36;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 7)
            {
                switch (to)
                {
                    case 0: // Convert kilometers to angstroms
                        return value * 1 * Math.Pow(10, 13);
                    case 1: // Convert kilometers to centimeters
                        return value * 100000;
                    case 2: // Convert kilometers to chains
                        return value * 49.709695379;
                    case 3: // Convert kilometers to fathoms
                        return value * 546.806649169;
                    case 4: // Convert kilometers to feet
                        return value * 3280.84;
                    case 5: // Convert kilometers to hands
                        return value * 9842.52;
                    case 6: // Convert kilometers to inches
                        return value * 39370.1;
                    case 7: // Convert kilometers to kilometers
                        return value;
                    case 8: // Convert kilometers to links
                        return value / 0.000201;
                    case 9: // Convert kilometers to meters
                        return value / 0.001;
                    case 10: // Convert kilometers to microns
                        return value / (1 * Math.Pow(10, -9));
                    case 11: // Convert kilometers to miles
                        return value / 1.60934;
                    case 12: // Convert kilometers to millimeters
                        return value / (1 * Math.Pow(10, -6));
                    case 13: // Convert kilometers to nanometers
                        return value / (1 * Math.Pow(10, -12));
                    case 14: // Convert kilometers to nautical miles
                        return value / 1.852;
                    case 15: // Convert kilometers to PICAs
                        return value / 0.000004233;
                    case 16: // Convert kilometers to rods
                        return value / 0.0050292;
                    case 17: // Convert kilometers to spans
                        return value / 0.0002286;
                    case 18: // Convert kilometers to yards
                        return value / 0.0009144;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 8)
            {
                switch (to)
                {
                    case 0: // Convert links to angstroms
                        return value * 2011684023.3678832;
                    case 1: // Convert links to centimeters
                        return value * 20.1168;
                    case 2: // Convert links to chains
                        return value * 0.01;
                    case 3: // Convert links to fathoms
                        return value * 0.11;
                    case 4: // Convert links to feet
                        return value * 0.659449;
                    case 5: // Convert links to hands
                        return value * 1.98000396;
                    case 6: // Convert links to inches
                        return value * 7.91339;
                    case 7: // Convert links to kilometers
                        return value * 0.000201;
                    case 8: // Convert links to links
                        return value;
                    case 9: // Convert links to meters
                        return value / 4.97512;
                    case 10: // Convert links to microns
                        return value / 0.000004971;
                    case 11: // Convert links to miles
                        return value / 8000;
                    case 12: // Convert links to millimeters
                        return value / 0.00497097;
                    case 13: // Convert links to nanometers
                        return value / 0.000000005;
                    case 14: // Convert links to nautical miles
                        return value / 9206.235584188;
                    case 15: // Convert links to PICAs
                        return value / 0.021043729;
                    case 16: // Convert links to rods
                        return value / 25.00005;
                    case 17: // Convert links to spans
                        return value / 1.136363636;
                    case 18: // Convert links to yards
                        return value / 4.545454545;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 9)
            {
                switch (to)
                {
                    case 0: // Convert meters to angstroms
                        return value * 1 * Math.Pow(10, 10);
                    case 1: // Convert meters to centimeters
                        return value * 100;
                    case 2: // Convert meters to chains
                        return value * 0.049710;
                    case 3: // Convert meters to fathoms
                        return value * 0.546806649;
                    case 4: // Convert meters to feet
                        return value * 3.28084;
                    case 5: // Convert meters to hands
                        return value * 9.84252;
                    case 6: // Convert meters to inches
                        return value * 39.3701;
                    case 7: // Convert meters to kilometers
                        return value * 0.01;
                    case 8: // Convert meters to links
                        return value * 4.97512;
                    case 9: // Convert meters to meters
                        return value;
                    case 10: // Convert meters to microns
                        return value / (1 * Math.Pow(10, -6));
                    case 11: // Convert meters to miles
                        return value / 1609.34;
                    case 12: // Convert meters to millimeters
                        return value / 0.001;
                    case 13: // Convert meters to nanometers
                        return value / (1 * Math.Pow(10, -9));
                    case 14: // Convert meters to nautical miles
                        return value / 1852;
                    case 15: // Convert meters to PICAs
                        return value / 0.004233333;
                    case 16: // Convert meters to rods
                        return value / 5.0292;
                    case 17: // Convert meters to spans
                        return value / 0.2286;
                    case 18: // Convert meters to yards
                        return value / 0.9144;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 10)
            {
                switch (to)
                {
                    case 0: // Convert microns to angstroms
                        return value * 10000;
                    case 1: // Convert microns to centimeters
                        return value * 0.00010000;
                    case 2: // Convert microns to chains
                        return value * 0.00000005;
                    case 3: // Convert microns to fathoms
                        return value * 0.000000547;
                    case 4: // Convert microns to feet
                        return value * 304800;
                    case 5: // Convert microns to hands
                        return value * 9.8425 * Math.Pow(10, -6);
                    case 6: // Convert microns to inches
                        return value * 3.937 * Math.Pow(10, -5);
                    case 7: // Convert microns to kilometers
                        return value * 1 * Math.Pow(10, -9);
                    case 8: // Convert microns to links
                        return value * 0.000004971;
                    case 9: // Convert microns to meters
                        return value * 1 * Math.Pow(10, -6);
                    case 10: // Convert microns to microns
                        return value;
                    case 11: // Convert microns to miles
                        return value / (1 * Math.Pow(10, 6));
                    case 12: // Convert microns to millimeters
                        return value / 1000;
                    case 13: // Convert microns to nanometers
                        return value / 0.001;
                    case 14: // Convert microns to nautical miles
                        return value / (1.852 * Math.Pow(10, 9));
                    case 15: // Convert microns to PICAs
                        return value / 4233.333333333;
                    case 16: // Convert microns to rods
                        return value * 10 / 9;
                    case 17: // Convert microns to spans
                        return value / (5.029 * Math.Pow(10, 6));
                    case 18: // Convert microns to yards
                        return value / 228600;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 11)
            {
                switch (to)
                {
                    case 0: // Convert miles to angstroms
                        return value * 1.609347219 * Math.Pow(10, 13);
                    case 1: // Convert miles to centimeters
                        return value * 6.2137119 * Math.Pow(10, -6);
                    case 2: // Convert miles to chains
                        return value * 80;
                    case 3: // Convert miles to fathoms
                        return value * 880;
                    case 4: // Convert miles to feet
                        return value * 304800;
                    case 5: // Convert miles to hands
                        return value * 15840;
                    case 6: // Convert miles to inches
                        return value * 63360;
                    case 7: // Convert miles to kilometers
                        return value * 1.60934;
                    case 8: // Convert miles to links
                        return value * 8000;
                    case 9: // Convert miles to meters
                        return value * 1609.34;
                    case 10: // Convert miles to microns
                        return value * 1 * Math.Log10(6);
                    case 11: // Convert miles to miles
                        return value;
                    case 12: // Convert miles to millimeters
                        return value / (6.2137 * Math.Pow(10, -7));
                    case 13: // Convert miles to nanometers
                        return value / (6.2137 * Math.Pow(10, -13));
                    case 14: // Convert miles to nautical miles
                        return value / 1.15078;
                    case 15: // Convert miles to PICAs
                        return value / 0.00000263;
                    case 16: // Convert miles to rods
                        return value / 0.003125;
                    case 17: // Convert miles to spans
                        return value / 0.000142045;
                    case 18: // Convert miles to yards
                        return value / 0.000568182;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 12)
            {
                switch (to)
                {
                    case 0: // Convert millimeters to angstroms
                        return value * 10000000;
                    case 1: // Convert millimeters to centimeters
                        return value * 0.10000;
                    case 2: // Convert millimeters to chains
                        return value * 4.9709596 * Math.Pow(10, -5);
                    case 3: // Convert millimeters to fathoms
                        return value * 0.000546807;
                    case 4: // Convert millimeters to feet
                        return value * 0.00328084;
                    case 5: // Convert millimeters to hands
                        return value * 0.00984252;
                    case 6: // Convert millimeters to inches
                        return value * 0.0393701;
                    case 7: // Convert millimeters to kilometers
                        return value * 1 * Math.Pow(10, -6);
                    case 8: // Convert millimeters to links
                        return value * 0.00497097;
                    case 9: // Convert millimeters to meters
                        return value * 0.001;
                    case 10: // Convert milimeters to microns
                        return value * 1000;
                    case 11: // Convert millimeters to miles
                        return value * 6.2137 * Math.Pow(10, -7);
                    case 12: // Convert millimeters to millimeters
                        return value;
                    case 13: // Convert millimeters to nanometers
                        return value / 0.000001;
                    case 14: // Convert millimeters to nautical miles
                        return value / (1.852 * Math.Pow(10, 6));
                    case 15: // Convert millimeters to PICAs
                        return value / 4.2175176;
                    case 16: // Convert millimeters to rods
                        return value / 5029.2;
                    case 17: // Convert millimeters to spans
                        return value / 228.6;
                    case 18: // Convert millimeters to yards
                        return value / 914.4;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 13)
            {
                switch (to)
                {
                    case 0: // Convert nanometers to angstroms
                        return value * 10;
                    case 1: // Convert nanometers to centimeters
                        return value * 0.0000001;
                    case 2: // Convert nanometers to chains
                        return value * 4.970959596 * Math.Pow(10, -11);
                    case 3: // Convert nanometers to fathoms
                        return value * 5.468066492 * Math.Pow(10, -10);
                    case 4: // Convert nanometers to feet
                        return value * 3.2808 * Math.Pow(10, -9);
                    case 5: // Convert nanometers to hands
                        return value * 9.8425 * Math.Pow(10, -9);
                    case 6: // Convert nanometers to inches
                        return value * 3.937 * Math.Pow(10, -8);
                    case 7: // Convert nanometers to kilometers
                        return value * 1 * Math.Pow(10, -12);
                    case 8: // Convert nanometers to links
                        return value * 0.000000005;
                    case 9: // Convert nanometers to meters
                        return value * 1 * Math.Pow(10, -9);
                    case 10: // Convert nanometers to microns
                        return value * 0.001;
                    case 11: // Convert nanometers to miles
                        return value * 6.2137 * Math.Pow(10, -13);
                    case 12: // Convert nanometers to millimeters
                        return value * 0.000001;
                    case 13: // Convert nanometers to nanometers
                        return value;
                    case 14: // Convert nanometers to nautical miles
                        return value / (1.852 * Math.Pow(10, 12));
                    case 15: // Convert nanometers to PICAs
                        return value / 4233333.3333333;
                    case 16: // Convert nanometers to rods
                        return value / (5.029 * Math.Pow(10, 9));
                    case 17: // Convert nanometers to spans
                        return value / (2.286 * Math.Pow(10, 8));
                    case 18: // Convert nanometers to yards
                        return value / (9.144 * Math.Pow(10, 8));
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 14)
            {
                switch (to)
                {
                    case 0: // Convert nautical miles to angstroms
                        return value * 1.852 * Math.Pow(10, 13);
                    case 1: // Convert nautical miles to centimeters
                        return value * 185200;
                    case 2: // Convert nautical miles to chains
                        return value * 92.0624;
                    case 3: // Convert nautical miles to fathoms
                        return value * 1012.6859142605401;
                    case 4: // Convert nautical miles to feet
                        return value * 6076.12;
                    case 5: // Convert nautical miles to hands
                        return value * 18228.3;
                    case 6: // Convert nautical miles to inches
                        return value * 72913.4;
                    case 7: // Convert nautical miles to kilometers
                        return value * 1.852;
                    case 8: // Convert nautical miles to links
                        return value * 9206.235584188;
                    case 9: // Convert nautical miles to meters
                        return value * 1852;
                    case 10: // Convert nautical miles to microns
                        return value * 1.852 * Math.Pow(10, 9);
                    case 11: // Convert nautical miles to miles
                        return value * 1.15078;
                    case 12: // Convert nautical miles to millimeters
                        return value * 1.852 * Math.Pow(10, 6);
                    case 13: // Convert nautical miles to nanometers
                        return value * 1.852 * Math.Pow(10, 12);
                    case 14: // Convert nautical miles to nautical miles
                        return value;
                    case 15: // Convert nautical miles to PICAs
                        return value / 0.000002284;
                    case 16: // Convert nautical miles to rods
                        return value / 0.00271555;
                    case 17: // Convert nautical miles to spans
                        return value / 0.000123434;
                    case 18: // Convert nautical miles to yards
                        return value / 0.000493737;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 15)
            {
                switch (to)
                {
                    case 0: // Convert PICAs to angstroms
                        return value * 42333333.333333;
                    case 1: // Convert PICAs to centimeters
                        return value * 0.423333333;
                    case 2: // Convert PICAs to chains
                        return value * 0.000210438;
                    case 3: // Convert PICAs to fathoms
                        return value * 0.002314815;
                    case 4: // Convert PICAs to feet
                        return value * 0.013888889;
                    case 5: // Convert PICAs to hands
                        return value * 0.041666667;
                    case 6: // Convert PICAs to inches
                        return value * 0.166666667;
                    case 7: // Convert PICAs to kilometers
                        return value * 0.000004233;
                    case 8: // Convert PICAs to links
                        return value * 0.021043729;
                    case 9: // Convert PICAs to meters
                        return value * 0.004233333;
                    case 10: // Convert PICAs to microns
                        return value * 4233.333333333;
                    case 11: // Convert PICAs to miles
                        return value * 0.00000263;
                    case 12: // Convert PICAs to millimeters
                        return value * 4.2175176;
                    case 13: // Convert PICAs to nanometers
                        return value * 4233333.3333333;
                    case 14: // Convert PICAs to nautical miles
                        return value * 0.000002284;
                    case 15: // Convert PICAs to PICAs
                        return value;
                    case 16: // Convert PICAs to rods
                        return value / 1188;
                    case 17: // Convert PICAs to spans
                        return value / 54;
                    case 18: // Convert PICAs to yards
                        return value / 216;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 16)
            {
                switch (to)
                {
                    case 0: // Convert rods to angstroms
                        return value * 5.0292 * Math.Pow(10, 10);
                    case 1: // Convert rods to centimeters
                        return value * 502.92;
                    case 2: // Convert rods to chains
                        return value * 0.25;
                    case 3: // Convert rods to fathoms
                        return value * 2.75;
                    case 4: // Convert rods to feet
                        return value * 0.013888889;
                    case 5: // Convert rods to hands
                        return value * 49.5;
                    case 6: // Convert rods to inches
                        return value * 198;
                    case 7: // Convert rods to kilometers
                        return value * 0.0050292;
                    case 8: // Convert rods to links
                        return value * 25.00005;
                    case 9: // Convert rods to meters
                        return value * 5.0292;
                    case 10: // Convert rods to microns
                        return value * 5.029 * Math.Pow(10, 6);
                    case 11: // Convert rods to miles
                        return value * 0.003125;
                    case 12: // Convert rods to millimeters
                        return value * 5029.2;
                    case 13: // Convert rods to nanometers
                        return value * 5.029 * Math.Pow(10, 9);
                    case 14: // Convert rods to nautical miles
                        return value * 0.00271555;
                    case 15: // Convert rods to PICAs
                        return value * 1188;
                    case 16: // Convert rods to rods
                        return value;
                    case 17: // Convert rods to spans
                        return value / 0.0454545;
                    case 18: // Convert rods to yards
                        return value / 0.181818;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 17)
            {
                switch (to)
                {
                    case 0: // Convert spans to angstroms
                        return value * 2286000000;
                    case 1: // Convert spans to centimeters
                        return value * 22.86;
                    case 2: // Convert spans to chains
                        return value * 0.011363614;
                    case 3: // Convert spans to fathoms
                        return value * 0.125;
                    case 4: // Convert spans to feet
                        return value * 0.75;
                    case 5: // Convert spans to hands
                        return value * 2.25;
                    case 6: // Convert spans to inches
                        return value * 9;
                    case 7: // Convert spans to kilometers
                        return value * 0.0002286;
                    case 8: // Convert spans to links
                        return value * 1.136363636;
                    case 9: // Convert spans to meters
                        return value * 0.2286;
                    case 10: // Convert spans to microns
                        return value * 228600;
                    case 11: // Convert spans to miles
                        return value * 0.000142045;
                    case 12: // Convert spans to millimeters
                        return value * 228.6;
                    case 13: // Convert spans to nanometers
                        return value * 2.286 * Math.Pow(10, 8);
                    case 14: // Convert spans to nautical miles
                        return value * 0.000123434;
                    case 15: // Convert spans to PICAs
                        return value * 54;
                    case 16: // Convert spans to rods
                        return value * 0.0454545;
                    case 17: // Convert spans to spans
                        return value;
                    case 18: // Convert spans to yards
                        return value / 4;
                    default: // Invalid unit
                        return 0;
                }
            }

            if (from == 18)
            {
                switch (to)
                {
                    case 0: // Convert yards to angstroms
                        return value * 9144000000;
                    case 1: // Convert yards to centimeters
                        return value * 0.010936;
                    case 2: // Convert yards to chains
                        return value * 0.045454545;
                    case 3: // Convert yards to fathoms
                        return value * 0.5;
                    case 4: // Convert yards to feet
                        return value * 3;
                    case 5: // Convert yards to hands
                        return value * 9;
                    case 6: // Convert yards to inches
                        return value * 36;
                    case 7: // Convert yards to kilometers
                        return value * 0.0009144;
                    case 8: // Convert yards to links
                        return value * 4.545454545;
                    case 9: // Convert yards to meters
                        return value * 0.9144;
                    case 10: // Convert yards to microns
                        return value * 228600;
                    case 11: // Convert yards to miles
                        return value * 0.000568182;
                    case 12: // Convert yards to millimeters
                        return value * 914.4;
                    case 13: // Convert yards to nanometers
                        return value * 9.144 * Math.Pow(10, 8);
                    case 14: // Convert yards to nautical miles
                        return value * 0.000493737;
                    case 15: // Convert yards to PICAs
                        return value * 216;
                    case 16: // Convert yards to rods
                        return value * 0.181818;
                    case 17: // Convert yards to spans
                        return value * 4;
                    case 18: // Convert yards to yards
                        return value;
                    default: // Invalid unit
                        return 0;
                }
            }

            return 0;
        }

        public double convertTemp(int from, int to, double value)
        {
            if (from == 0) //Unit is celsius
            {
                switch (to)
                {
                    case 0: // Convert celsius to celsius
                        return value;
                    case 1: // Convert celsius to fahrenheit
                        return value * 9.0 / 5.0 + 32.0;
                    case 2: // Convert celsius to kelvin
                        return value + 273.15;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 1) //Unit is fahrenheit
            {
                switch (to)
                {
                    case 0: 
                        return (value - 32.0) * 5.0 / 9.0;
                    case 1:
                        return value;
                    case 2: 
                        return (value - 32.0) * 5.0 / 9.0 + 273.15;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 2) //Unit is kelvins
            {
                switch (to)
                {
                    case 0:
                        return value - 273.15;
                    case 1:
                        return (value - 273.15) * 9.0 / 5.0 + 32.0;
                    case 2:
                        return value;
                    default: // Invalid unit
                        return 0;
                }
            }
            return 0; // Invalid unit
        }

        public double convertVolume(int from, int to, double value)
        {
            if (from == 0) //Unit is cubic centimeter
            {
                switch (to)
                {
                    case 0:
                        return value;
                    case 1:
                        return value * 3.5315e-5;
                    case 2:
                        return value * 0.0610237;
                    case 3:
                        return value * 1e-6;
                    case 4:
                        return value * 1.30795e-6;
                    case 5:
                        return value * 0.0351951;
                    case 6:
                        return value * 0.033814;
                    case 7:
                        return value * 0.000219969;
                    case 8:
                        return value * 0.000264172;
                    case 9:
                        return value * 0.001;
                    case 10:
                        return value * 0.00175975;
                    case 11:
                        return value * 0.00211338;
                    case 12:
                        return value * 0.000879877;
                    case 13:
                        return value * 0.00105669;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 1) //Unit is cubic feet
            {
                switch (to)
                {
                    case 0:
                        return value * 28316.8;
                    case 1:
                        return value;
                    case 2:
                        return value * 1728;
                    case 3:
                        return value * 0.0283168;
                    case 4:
                        return value * 0.037037;
                    case 5:
                        return value * 996.614;
                    case 6:
                        return value * 957.506;
                    case 7:
                        return value * 6.22884;
                    case 8:
                        return value * 7.48052;
                    case 9:
                        return value * 28.3168;
                    case 10:
                        return value * 49.8307;
                    case 11:
                        return value * 59.8442;
                    case 12:
                        return value * 24.9153;
                    case 13:
                        return value * 29.9221;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 2) //Unit is cubic inch
            {
                switch (to)
                {
                    case 0:
                        return value * 16.3871;
                    case 1:
                        return value * 0.000578704;
                    case 2:
                        return value;
                    case 3:
                        return value * 1.6387e-5;
                    case 4:
                        return value * 2.1433e-5;
                    case 5:
                        return value * 0.576744;
                    case 6:
                        return value * 0.554113;
                    case 7:
                        return value * 0.00360465;
                    case 8:
                        return value * 0.004329;
                    case 9:
                        return value * 0.0163871;
                    case 10:
                        return value * 0.0288372;
                    case 11:
                        return value * 0.034632;
                    case 12:
                        return value * 0.0144186;
                    case 13:
                        return value * 0.017316;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 3) //Unit is cubic meter
            {
                switch (to)
                {
                    case 0:
                        return value * 1e+6;
                    case 1:
                        return value * 35.3147;
                    case 2:
                        return value * 61023.7;
                    case 3:
                        return value;
                    case 4:
                        return value * 1.30795;
                    case 5:
                        return value * 35195.1;
                    case 6:
                        return value * 33814;
                    case 7:
                        return value * 219.969;
                    case 8:
                        return value * 264.172;
                    case 9:
                        return value * 1000;
                    case 10:
                        return value * 1759.75;
                    case 11:
                        return value * 2113.38;
                    case 12:
                        return value * 879.877;
                    case 13:
                        return value * 1056.69;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 4) //Unit is cubic yard
            {
                switch (to)
                {
                    case 0:
                        return value * 764555;
                    case 1:
                        return value * 27;
                    case 2:
                        return value * 46656;
                    case 3:
                        return value * 0.764555;
                    case 4:
                        return value;
                    case 5:
                        return value * 26908.6;
                    case 6:
                        return value * 25852.7;
                    case 7:
                        return value * 168.179;
                    case 8:
                        return value * 201.974;
                    case 9:
                        return value * 764.555;
                    case 10:
                        return value * 1345.43;
                    case 11:
                        return value * 1615.79;
                    case 12:
                        return value * 672.714;
                    case 13:
                        return value * 807.896;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 5) //Unit is fluid ounce (UK)
            {
                switch (to)
                {
                    case 0:
                        return value * 28.4131;
                    case 1:
                        return value * 0.0010034;
                    case 2:
                        return value * 1.73387;
                    case 3:
                        return value * 2.8413e-5;
                    case 4:
                        return value * 3.7163e-5;
                    case 5:
                        return value;
                    case 6:
                        return value * 0.96076;
                    case 7:
                        return value * 0.00625;
                    case 8:
                        return value * 0.00750594;
                    case 9:
                        return value * 0.0284131;
                    case 10:
                        return value * 0.05;
                    case 11:
                        return value * 0.0600475;
                    case 12:
                        return value * 0.025;
                    case 13:
                        return value * 0.0300237;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 6) //Unit is fluid ounce (US)
            {
                switch (to)
                {
                    case 0:
                        return value * 29.5735;
                    case 1:
                        return value * 0.00104438;
                    case 2:
                        return value * 1.80469;
                    case 3:
                        return value * 2.9574e-5;
                    case 4:
                        return value * 3.8681e-5;
                    case 5:
                        return value * 1.04084;
                    case 6:
                        return value;
                    case 7:
                        return value * 0.00650527;
                    case 8:
                        return value * 0.0078125;
                    case 9:
                        return value * 0.0295735;
                    case 10:
                        return value * 0.0520421;
                    case 11:
                        return value * 0.0625;
                    case 12:
                        return value * 0.0260211;
                    case 13:
                        return value * 0.03125;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 7) //Unit is gallon (UK)
            {
                switch (to)
                {
                    case 0:
                        return value * 4546.09;
                    case 1:
                        return value * 0.160544;
                    case 2:
                        return value * 277.419;
                    case 3:
                        return value * 0.00454609;
                    case 4:
                        return value * 0.00594606;
                    case 5:
                        return value * 160;
                    case 6:
                        return value * 153.722;
                    case 7:
                        return value;
                    case 8:
                        return value * 1.20095;
                    case 9:
                        return value * 4.54609;
                    case 10:
                        return value * 8;
                    case 11:
                        return value * 9.6076;
                    case 12:
                        return value * 4;
                    case 13:
                        return value * 4.8038;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 8) //Unit is gallon(US)
            {
                switch (to)
                {
                    case 0:
                        return value * 3785.41;
                    case 1:
                        return value * 0.133681;
                    case 2:
                        return value * 231;
                    case 3:
                        return value * 0.00378541;
                    case 4:
                        return value * 0.00495113;
                    case 5:
                        return value * 133.228;
                    case 6:
                        return value * 128;
                    case 7:
                        return value * 0.832674;
                    case 8:
                        return value;
                    case 9:
                        return value * 3.78541;
                    case 10:
                        return value * 6.66139;
                    case 11:
                        return value * 8;
                    case 12:
                        return value * 3.3307;
                    case 13:
                        return value * 4;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 9) //Unit is liter
            {
                switch (to)
                {
                    case 0:
                        return value * 1000;
                    case 1:
                        return value * 0.0353147;
                    case 2:
                        return value * 61.0237;
                    case 3:
                        return value * 0.001;
                    case 4:
                        return value * 0.00130795;
                    case 5:
                        return value * 35.1951;
                    case 6:
                        return value * 33.814;
                    case 7:
                        return value * 0.219969;
                    case 8:
                        return value * 0.264172;
                    case 9:
                        return value;
                    case 10:
                        return value * 1.75975;
                    case 11:
                        return value * 2.11338;
                    case 12:
                        return value * 0.879877;
                    case 13:
                        return value * 1.05669;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 10) //Unit is pint (UK)
            {
                switch (to)
                {
                    case 0:
                        return value * 568.261;
                    case 1:
                        return value * 0.020068;
                    case 2:
                        return value * 34.6774;
                    case 3:
                        return value * 0.000568261;
                    case 4:
                        return value * 0.000743258;
                    case 5:
                        return value * 20;
                    case 6:
                        return value * 19.2152;
                    case 7:
                        return value * 0.125;
                    case 8:
                        return value * 0.150119;
                    case 9:
                        return value * 0.568261;
                    case 10:
                        return value;
                    case 11:
                        return value * 1.20095;
                    case 12:
                        return value * 0.5;
                    case 13:
                        return value * 0.600475;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 11) //Unit is pint (US)
            {
                switch (to)
                {
                    case 0:
                        return value * 473.176;
                    case 1:
                        return value * 0.0167101;
                    case 2:
                        return value * 28.875;
                    case 3:
                        return value * 0.000473176;
                    case 4:
                        return value * 0.000618891;
                    case 5:
                        return value * 16.6535;
                    case 6:
                        return value * 16;
                    case 7:
                        return value * 0.104084;
                    case 8:
                        return value * 0.125;
                    case 9:
                        return value * 0.473176;
                    case 10:
                        return value * 0.832674;
                    case 11:
                        return value;
                    case 12:
                        return value * 0.416337;
                    case 13:
                        return value * 0.5;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 12) //Unit is quart (UK)
            {
                switch (to)
                {
                    case 0:
                        return value * 1136.52;
                    case 1:
                        return value * 0.0401359;
                    case 2:
                        return value * 69.3549;
                    case 3:
                        return value * 0.00113652;
                    case 4:
                        return value * 0.00148652;
                    case 5:
                        return value * 40;
                    case 6:
                        return value * 38.4304;
                    case 7:
                        return value * 0.25;
                    case 8:
                        return value * 0.300237;
                    case 9:
                        return value * 1.13652;
                    case 10:
                        return value * 2;
                    case 11:
                        return value * 2.4019;
                    case 12:
                        return value;
                    case 13:
                        return value * 1.20095;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 13) //Unit is quart (US)
            {
                switch (to)
                {
                    case 0:
                        return value * 946.353;
                    case 1:
                        return value * 0.0334201;
                    case 2:
                        return value * 57.75;
                    case 3:
                        return value * 0.000946353;
                    case 4:
                        return value * 0.00123778;
                    case 5:
                        return value * 33.307;
                    case 6:
                        return value * 32;
                    case 7:
                        return value * 0.208169;
                    case 8:
                        return value * 0.25;
                    case 9:
                        return value * 0.946353;
                    case 10:
                        return value * 1.66535;
                    case 11:
                        return value * 2;
                    case 12:
                        return value * 0.832674;
                    case 13:
                        return value;
                    default: // Invalid unit
                        return 0;
                }
            }
            return 0;
        }

        public double convertWeight(int from, int to, double value)
        {
            if (from == 0) //Unit is carat
            {
                switch (to)
                {
                    case 0:
                        return value;
                    case 1:
                        return value * 20.0;
                    case 2:
                        return value * 2.0;
                    case 3:
                        return value * 0.02;
                    case 4:
                        return value * 0.2;
                    case 5:
                        return value * 0.002;
                    case 6:
                        return value * 0.0002;
                    case 7:
                        return value * 1.96841306 * Math.Pow(10, -7);
                    case 8:
                        return value * 200.0;
                    case 9:
                        return value * 0.00705479239;
                    case 10:
                        return value * 0.000440924524;
                    case 11:
                        return value * 2.20462262 * Math.Pow(10, -7);
                    case 12:
                        return value * 3.14946089 * Math.Pow(10, -5);
                    case 13:
                        return value * 2.0 * Math.Pow(10, -7);
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 1) //Unit is centigram
            {
                switch (to)
                {
                    case 0:
                        return value * 0.05;
                    case 1:
                        return value;
                    case 2:
                        return value * 0.1;
                    case 3:
                        return value * 0.001;
                    case 4:
                        return value * 0.01;
                    case 5:
                        return value * 0.0001;
                    case 6:
                        return value * 1.0 * Math.Pow(10, -5);
                    case 7:
                        return value * 9.84206528 * Math.Pow(10, -9);
                    case 8:
                        return value * 10.0;
                    case 9:
                        return value * 0.000352739619;
                    case 10:
                        return value * 0.000022046;
                    case 11:
                        return value * 1.10231131 * Math.Pow(10, -8);
                    case 12:
                        return value * 1.57473044 * Math.Pow(10, -6);
                    case 13:
                        return value * 1.0 * Math.Pow(10, -8);
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 2) //Unit is decigram
            {
                switch (to)
                {
                    case 0:
                        return value * 0.5;
                    case 1:
                        return value * 10;
                    case 2:
                        return value;
                    case 3:
                        return value * 0.01;
                    case 4:
                        return value * 0.1;
                    case 5:
                        return value * 0.001;
                    case 6:
                        return value * 0.0001;
                    case 7:
                        return value * 9.84206528 * Math.Pow(10, -8);
                    case 8:
                        return value * 100.0;
                    case 9:
                        return value * 0.00352739619;
                    case 10:
                        return value * 0.000220462262;
                    case 11:
                        return value * 1.10231131 * Math.Pow(10, -7);
                    case 12:
                        return value * 1.57473044 * Math.Pow(10, -5);
                    case 13:
                        return value * 1.0 * Math.Pow(10, -7);
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 3) //Unit is dekagram
            {
                switch (to)
                {
                    case 0:
                        return value * 50.0;
                    case 1:
                        return value * 1000.0;
                    case 2:
                        return value * 100.0;
                    case 3:
                        return value;
                    case 4:
                        return value * 10.0;
                    case 5:
                        return value * 0.1;
                    case 6:
                        return value * 0.01;
                    case 7:
                        return value * 9.84206528 * Math.Pow(10, -6);
                    case 8:
                        return value * 10000.0;
                    case 9:
                        return value * 0.352739619;
                    case 10:
                        return value * 0.0220462262;
                    case 11:
                        return value * 1.10231131 * Math.Pow(10, -5);
                    case 12:
                        return value * 0.00157473044;
                    case 13:
                        return value * 1.0 * Math.Pow(10, -5);
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 4) //Unit is gram
            {
                switch (to)
                {
                    case 0:
                        return value * 5.0;
                    case 1:
                        return value * 100.0;
                    case 2:
                        return value * 10.0;
                    case 3:
                        return value * 0.1;
                    case 4:
                        return value;
                    case 5:
                        return value * 0.01;
                    case 6:
                        return value * 0.001;
                    case 7:
                        return value * 9.84207 * Math.Pow(10, -7);
                    case 8:
                        return value * 1000.0;
                    case 9:
                        return value * 0.035274;
                    case 10:
                        return value * 0.00220462;
                    case 11:
                        return value * 1.1023 * Math.Pow(10, -6);
                    case 12:
                        return value * 0.000157473;
                    case 13:
                        return value * 1.0 * Math.Pow(10, -6);
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 5) //Unit is hectogram
            {
                switch (to)
                {
                    case 0:
                        return value * 500.0;
                    case 1:
                        return value * 10000.0;
                    case 2:
                        return value * 1000.0;
                    case 3:
                        return value * 10.0;
                    case 4:
                        return value * 100;
                    case 5:
                        return value;
                    case 6:
                        return value * 0.1;
                    case 7:
                        return value * 9.84206528 * Math.Pow(10, -5);
                    case 8:
                        return value * 100000.0;
                    case 9:
                        return value * 3.52739619;
                    case 10:
                        return value * 0.220462262;
                    case 11:
                        return value * 0.000110231131;
                    case 12:
                        return value * 0.0157473044;
                    case 13:
                        return value * 0.0001;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 6) //Unit is kilogram
            {
                switch (to)
                {
                    case 0:
                        return value * 5000.0;
                    case 1:
                        return value * 100000.0;
                    case 2:
                        return value * 10000.0;
                    case 3:
                        return value * 100.0;
                    case 4:
                        return value * 1000.0;
                    case 5:
                        return value * 10.0;
                    case 6:
                        return value;
                    case 7:
                        return value * 0.000984207;
                    case 8:
                        return value * 1000000.0;
                    case 9:
                        return value * 35.274;
                    case 10:
                        return value * 2.20462;
                    case 11:
                        return value * 0.00110231;
                    case 12:
                        return value * 0.157473;
                    case 13:
                        return value * 0.001;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 7) //Unit is long ton
            {
                switch (to)
                {
                    case 0:
                        return value * 5080234.54;
                    case 1:
                        return value * 101604691;
                    case 2:
                        return value * 10160469.1;
                    case 3:
                        return value * 101604.691;
                    case 4:
                        return value * 1.01605 * Math.Pow(10, 6);
                    case 5:
                        return value * 10160.4691;
                    case 6:
                        return value * 1016.05;
                    case 7:
                        return value;
                    case 8:
                        return value * 1.01605 * Math.Pow(10, 9);
                    case 9:
                        return value * 35840;
                    case 10:
                        return value * 2240;
                    case 11:
                        return value * 1.12;
                    case 12:
                        return value * 160;
                    case 13:
                        return value * 1.01605;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 8) //Unit is milligram
            {
                switch (to)
                {
                    case 0:
                        return value * 0.005;
                    case 1:
                        return value * 0.1;
                    case 2:
                        return value * 0.01;
                    case 3:
                        return value * 0.0001;
                    case 4:
                        return value * 0.001;
                    case 5:
                        return value * 1.0 * Math.Pow(10, -5);
                    case 6:
                        return value * 1.0 * Math.Pow(10, -6);
                    case 7:
                        return value * 9.84207 * Math.Pow(10, -10);
                    case 8:
                        return value;
                    case 9:
                        return value * 3.5274 * Math.Pow(10, -5);
                    case 10:
                        return value * 2.20462 * Math.Pow(10, -6);
                    case 11:
                        return value * 1.10231 * Math.Pow(10, -9);
                    case 12:
                        return value * 1.57473 * Math.Pow(10, -7);
                    case 13:
                        return value * 1.0 * Math.Pow(10, -9);
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 9) //Unit is ounce
            {
                switch (to)
                {
                    case 0:
                        return value * 141.747616;
                    case 1:
                        return value * 2834.95231;
                    case 2:
                        return value * 283.495231;
                    case 3:
                        return value * 2.83495231;
                    case 4:
                        return value * 28.3495;
                    case 5:
                        return value * 0.283495231;
                    case 6:
                        return value * 0.0283495;
                    case 7:
                        return value * 2.79018 * Math.Pow(10, -5);
                    case 8:
                        return value * 28349.5;
                    case 9:
                        return value;
                    case 10:
                        return value / 16.0;
                    case 11:
                        return value * 3.125 * Math.Pow(10, -5);
                    case 12:
                        return value * 0.00446429;
                    case 13:
                        return value * 2.835 * Math.Pow(10, -5);
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 10) //Unit is pound
            {
                switch (to)
                {
                    case 0:
                        return value * 2267.96185;
                    case 1:
                        return value * 45359.237;
                    case 2:
                        return value * 4535.9237;
                    case 3:
                        return value * 45.359237;
                    case 4:
                        return value * 453.592;
                    case 5:
                        return value * 4.5359237;
                    case 6:
                        return value * 0.453592;
                    case 7:
                        return value * 0.000446429;
                    case 8:
                        return value * 453592.0;
                    case 9:
                        return value * 16.0;
                    case 10:
                        return value;
                    case 11:
                        return value * 0.0005;
                    case 12:
                        return value * 0.0714286;
                    case 13:
                        return value * 0.000453592;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 11) //Unit is short ton
            {
                switch (to)
                {
                    case 0:
                        return value * 4535923.7;
                    case 1:
                        return value * 90718474.0;
                    case 2:
                        return value * 9071847.4;
                    case 3:
                        return value * 90718.474;
                    case 4:
                        return value * 907185.0;
                    case 5:
                        return value * 9071.8474;
                    case 6:
                        return value * 907.185;
                    case 7:
                        return value * 0.892857;
                    case 8:
                        return value * 907184740.0;
                    case 9:
                        return value * 32000.0;
                    case 10:
                        return value * 2000.0;
                    case 11:
                        return value;
                    case 12:
                        return value * 142.857;
                    case 13:
                        return value * 0.907185;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 12) //Unit is stone
            {
                switch (to)
                {
                    case 0:
                        return value * 31751.4659;
                    case 1:
                        return value * 635029.318;
                    case 2:
                        return value * 63502.9318;
                    case 3:
                        return value * 635.029318;
                    case 4:
                        return value * 6350.29;
                    case 5:
                        return value * 63.5029318;
                    case 6:
                        return value * 6.35029;
                    case 7:
                        return value * 0.00625;
                    case 8:
                        return value * 6.35029 * Math.Pow(10, 6);
                    case 9:
                        return value * 224.0;
                    case 10:
                        return value * 14.0;
                    case 11:
                        return value * 0.007;
                    case 12:
                        return value;
                    case 13:
                        return value * 0.00635029;
                    default: // Invalid unit
                        return 0;
                }
            }
            else if (from == 13) //Unit is tonne
            {
                switch (to)
                {
                    case 0:
                        return value * 5000000.0;
                    case 1:
                        return value * 100000000.0;
                    case 2:
                        return value * 10000000.0;
                    case 3:
                        return value * 100000.0;
                    case 4:
                        return value * 1000000.0;
                    case 5:
                        return value * 10000.0;
                    case 6:
                        return value * 1000.0;
                    case 7:
                        return value * 0.984207;
                    case 8:
                        return value * 1.0 * Math.Pow(10, 9);
                    case 9:
                        return value * 35274.0;
                    case 10:
                        return value * 2204.62;
                    case 11:
                        return value * 1.10231;
                    case 12:
                        return value * 157.473;
                    case 13:
                        return value;
                    default: // Invalid unit
                        return 0;
                }
            }
            return 0; // Invalid unit
        }
    }
}
