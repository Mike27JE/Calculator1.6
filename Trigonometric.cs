using System;
using System.Collections.Generic;
using System.Text;

/*Assignment 1.6
 * 
 * By Michael Evans 
 * student ID P288106
 * 
 * TrigonometricLibrary Version 2
 */

namespace TrigonometricLibrary
{
    // The results of all Algebraic functions are rounded to 8 decimal places.
    public class Trigonometric
    {
        // how many decimal places answers will be rounded to.
        private static int decimalRounding = 8;

        private static double degreeToRads(double x)
        {
            x = (Math.PI * x) / 180.0;
            return x;
        }

        public static double tan(double x)
        {
            x = Math.Tan(degreeToRads(x));
            return Math.Round(x, decimalRounding);
        }

        public static double sine(double x)
        {
            x = Math.Sin(degreeToRads(x));
            return Math.Round(x, decimalRounding);
        }

        public static double cosine(double x)
        {
            x = Math.Cos(degreeToRads(x));
            return Math.Round(x, decimalRounding);
        }
    }
}
