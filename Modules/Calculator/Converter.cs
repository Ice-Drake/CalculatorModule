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
            double fromFactor = 1;
            double toFactor = 1;

            switch (from)
            {
                case 0: // Convert acres to square feet
                    fromFactor = 43560;
                    break;
                case 1: // Convert hectares to square feet
                    fromFactor = 107639.1041670972;
                    break;
                case 2: // Convert square centimeters to square feet
                    fromFactor = 0.001076391041671;
                    break;
                case 4: // Convert square inches to square feet
                    fromFactor = 1.0/144;
                    break;
                case 5: // Convert square kilometers to square feet
                    fromFactor = 10763910.41670972;
                    break;
                case 6: // Convert square meters to square feet
                    fromFactor = 10.76391041670972;
                    break;
                case 7: // Convert square miles to square feet
                    fromFactor = 27878400;
                    break;
                case 8: // Convert square millimeters to square feet
                    fromFactor = 1.076391041670972 * Math.Pow(10, -5);
                    break;
                case 9: // Convert square yards to square feet
                    fromFactor = 9;
                    break;
                default: // Convert square feet to square feet
                    break;
            }

            switch (to)
            {
                case 0: // Convert square feet to acres
                    toFactor = 2.295684113865932 * Math.Pow(10, -5);
                    break;
                case 1: // Convert square feet to hectares
                    toFactor = 0.000009290304;
                    break;
                case 2: // Convert square feet to square centimeters
                    toFactor = 929.0304;
                    break;
                case 4: // Convert square feet to square inches
                    toFactor = 144;
                    break;
                case 5: // Convert square feet to square kilometers
                    toFactor = 0.00000009290304;
                    break;
                case 6: // Convert square feet to square meters
                    toFactor = 0.09290304;
                    break;
                case 7: // Convert square feet to square miles
                    toFactor = 3.587006427915519 * Math.Pow(10, -8);
                    break;
                case 8: // Convert square feet to square millimeters
                    toFactor = 92903.04;
                    break;
                case 9: // Convert square feet to square yards
                    toFactor = 1.0/9;
                    break;
                default: // Convert square feet to square feet
                    break;
            }

            return value * fromFactor * toFactor;
        }

        public double convertLength(int from, int to, double value)
        {
            double fromFactor = 1;
            double toFactor = 1;

            switch (from)
            {
                case 0: // Convert angstroms to feet
                    fromFactor = 3.280839895013123 * Math.Pow(10, -10);
                    break;
                case 1: // Convert centimeters to feet
                    fromFactor = 0.0328083989501312;
                    break;
                case 2: // Convert chains to feet
                    fromFactor = 66;
                    break;
                case 3: // Convert fathoms to feet
                    fromFactor = 6;
                    break;
                case 5: // Convert hands to feet
                    fromFactor = 1.0/3;
                    break;
                case 6: // Convert inches to feet
                    fromFactor = 1.0/12;
                    break;
                case 7: // Convert kilometers to feet
                    fromFactor = 3280.839895013123;
                    break;
                case 8: // Convert links to feet
                    fromFactor = 0.66;
                    break;
                case 9: // Convert meters to feet
                    fromFactor = 3.280839895013123;
                    break;
                case 10: // Convert microns to feet
                    fromFactor = 3.280839895013123 * Math.Pow(10, -6);
                    break;
                case 11: // Convert miles to feet
                    fromFactor = 5280;
                    break;
                case 12: // Convert millimeters to feet
                    fromFactor = 0.0032808398950131;
                    break;
                case 13: // Convert nanometers to feet
                    fromFactor = 3.280839895013123 * Math.Pow(10, -9);
                    break;
                case 14: // Convert nautical miles to feet
                    fromFactor = 6076.115485564304;
                    break;
                case 15: // Convert PICAs to feet
                    fromFactor = 0.013837;
                    break;
                case 16: // Convert rods to feet
                    fromFactor = 16.5;
                    break;
                case 17: // Convert spans to feet
                    fromFactor = 0.75;
                    break;
                case 18: // Convert yards to feet
                    fromFactor = 3;
                    break;
                default: // Convert feet to feet
                    break;
            }

            switch (to)
            {
                case 0: // Convert feet to angstroms
                    toFactor = 3048000000;
                    break;
                case 1: // Convert feet to centimeters
                    toFactor = 30.48;
                    break;
                case 2: // Convert feet to chains
                    toFactor = 1.0/66;
                    break;
                case 3: // Convert feet to fathoms
                    toFactor = 1.0/6;
                    break;
                case 5: // Convert feet to hands
                    toFactor = 3;
                    break;
                case 6: // Convert feet to inches
                    toFactor = 12;
                    break;
                case 7: // Convert feet to kilometers
                    toFactor = 0.0003048;
                    break;
                case 8: // Convert feet to links
                    toFactor = 50/33;
                    break;
                case 9: // Convert feet to meters
                    toFactor = 0.3048;
                    break;
                case 10: // Convert feet to microns
                    toFactor = 304800;
                    break;
                case 11: // Convert feet to miles
                    toFactor = 1/5280;
                    break;
                case 12: // Convert feet to millimeters
                    toFactor = 304.8;
                    break;
                case 13: // Convert feet to nanometers
                    toFactor = 304800000;
                    break;
                case 14: // Convert feet to nautical miles
                    toFactor = 1.645788336933045 * Math.Pow(10, -4);
                    break;
                case 15: // Convert feet to PICAs
                    toFactor = 72.27000072270001;
                    break;
                case 16: // Convert feet to rods
                    toFactor = 2.0/33;
                    break;
                case 17: // Convert feet to spans
                    toFactor = 4.0/3;
                    break;
                case 18: // Convert feet to yards
                    toFactor = 1.0/3;
                    break;
                default: // Convert feet to feet
                    break;
            }

            return value * fromFactor * toFactor;
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
            double fromFactor = 1;
            double toFactor = 1;

            switch (from)
            {
                case 0: // Convert cubic centimeter to fluid ounce (US)
                    fromFactor = 0.033814022701843;
                    break;
                case 1: // Convert cubic feet to fluid ounce (US)
                    fromFactor = 957.5064935064935;
                    break;
                case 2: // Convert cubic inch to fluid ounce (US)
                    fromFactor = 0.5541125541125541;
                    break;
                case 3: // Convert cubic meter to fluid ounce (US)
                    fromFactor = 33814.022701843;
                    break;
                case 4: // Convert cubic yard to fluid ounce (US)
                    fromFactor = 25852.67532467532;
                    break;
                case 5: // Convert fluid ounce (UK) to fluid ounce (US)
                    fromFactor = 0.9607599404038839;
                    break;
                case 7: // Convert gallon (UK) to fluid ounce (US)
                    fromFactor = 153.7215904646214;
                    break;
                case 8: // Convert gallon (US) to fluid ounce (US)
                    fromFactor = 128;
                    break;
                case 9: // Convert liter to fluid ounce (US)
                    fromFactor = 33.814022701843;
                    break;
                case 10: // Convert pint (UK) to fluid ounce (US)
                    fromFactor = 19.21519880807768;
                    break;
                case 11: // Convert pint (US) to fluid ounce (US)
                    fromFactor = 16;
                    break;
                case 12: // Convert quart (UK) to fluid ounce (US)
                    fromFactor = 38.43039761615536;
                    break;
                case 13: // Convert quart (US) to fluid ounce (US)
                    fromFactor = 32;
                    break;
                default: // Convert fluid ounce (US) to fluid ounce (US)
                    break;
            }

            switch (to)
            {
                case 0: // Convert fluid ounce (US) to cubic centimeter
                    toFactor = 29.5735295625;
                    break;
                case 1: // Convert fluid ounce (US) to cubic feet
                    toFactor = 0.0010443793402778;
                    break;
                case 2: // Convert fluid ounce (US) to cubic inch
                    toFactor = 1.8046875;
                    break;
                case 3: // Convert fluid ounce (US) to cubic meter
                    toFactor = 0.0000295735295625;
                    break;
                case 4: // Convert fluid ounce (US) to cubic yard
                    toFactor = 3.868071630658436 * Math.Pow(10, -5);
                    break;
                case 5: // Convert fluid ounce (US) to fluid ounce (UK)
                    toFactor = 1.040842730786236;
                    break;
                case 7: // Convert fluid ounce (US) to gallon (UK)
                    toFactor = 0.006505267067414;
                    break;
                case 8: // Convert fluid ounce (US) to gallon (US)
                    toFactor = 0.0078125;
                    break;
                case 9: // Convert fluid ounce (US) to liter
                    toFactor = 0.0295735295625;
                    break;
                case 10: // Convert fluid ounce (US) to pint (UK)
                    toFactor = 0.0520421365393118;
                    break;
                case 11: // Convert fluid ounce (US) to pint (US)
                    toFactor = 0.0625;
                    break;
                case 12: // Convert fluid ounce (US) to quart (UK)
                    toFactor = 0.0260210682696559;
                    break;
                case 13: // Convert fluid ounce (US) to quart (US)
                    toFactor = 0.03125;
                    break;
                default: // Convert fluid ounce (US) to fluid ounce (US)
                    break;
            }

            return value * fromFactor * toFactor;
        }

        public double convertWeight(int from, int to, double value)
        {
            double fromFactor = 1;
            double toFactor = 1;

            switch (from)
            {
                case 0: // Convert carat to gram
                    fromFactor = 0.2;
                    break;
                case 1: // Convert centigram to gram
                    fromFactor = 1.0/100;
                    break;
                case 2: // Convert decigram to gram
                    fromFactor = 0.1;
                    break;
                case 3: // Convert dekagram to gram
                    fromFactor = 10;
                    break;
                case 5: // Convert hectogram to gram
                    fromFactor = 100;
                    break;
                case 6: // Convert kilogram to gram
                    fromFactor = 1000;
                    break;
                case 7: // Convert long ton to gram
                    fromFactor = 1016046.9088;
                    break;
                case 8: // Convert milligram to gram
                    fromFactor = 1.0/1000;
                    break;
                case 9: // Convert ounce to gram
                    fromFactor = 28.349523125;
                    break;
                case 10: // Convert pound to gram
                    fromFactor = 453.59237;
                    break;
                case 11: // Convert short ton to gram
                    fromFactor = 907184.74;
                    break;
                case 12: // Convert stone to gram
                    fromFactor = 6350.29318;
                    break;
                case 13: // Convert tonne to gram
                    fromFactor = 1000000;
                    break;
                default: // Convert gram to gram
                    break;
            }

            switch (to)
            {
                case 0: // Convert gram to carat
                    toFactor = 5;
                    break;
                case 1: // Convert gram to centigram
                    toFactor = 100;
                    break;
                case 2: // Convert gram to decigram
                    toFactor = 10;
                    break;
                case 3: // Convert gram to dekagram
                    toFactor = 0.1;
                    break;
                case 5: // Convert gram to hectogram
                    toFactor = 1.0/100;
                    break;
                case 6: // Convert gram to kilogram
                    toFactor = 1.0/1000;
                    break;
                case 7: // Convert gram to long ton
                    toFactor = 9.842065276110606 * Math.Pow(10, -7);
                    break;
                case 8: // Convert gram to milligram
                    toFactor = 1000;
                    break;
                case 9: // Convert gram to ounce
                    toFactor = 0.0352739619495804;
                    break;
                case 10: // Convert gram to pound
                    toFactor = 0.0022046226218488;
                    break;
                case 11: // Convert gram to short ton
                    toFactor = 1.102311310924388 * Math.Pow(10, -6);
                    break;
                case 12: // Convert gram to stone
                    toFactor = 1.574730444177697 * Math.Pow(10, -4);
                    break;
                case 13: // Convert gram to tonne
                    toFactor = 0.000001;
                    break;
                default: // Convert gram to gram
                    break;
            }

            return value * fromFactor * toFactor;
        }
    }
}
