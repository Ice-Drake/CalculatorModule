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
