using System;
using System.Collections.Generic;
using System.Text;

/*
 * By Michael Evans
 * student ID P288106
 *
 * AlgebraicLibrary Version 3
 * 
 */

namespace AlgebraicLibrary
{
    // Supply basic algebraic function such as square Root, cubed root and inverse.
    // The results of all Algebraic functions are rounded to 8 decimal places.
    public class Algebraic
    {
        // how many decimal places answers will be rounded to.
        private static int decimalRounding = 8;

        public static double squareRoot(double x)
        {   
            x = Math.Sqrt(x);
            return Math.Round(x, decimalRounding);
        }

        public static double cubeRoot(double x)
        {
            // Deals with negative root number by converting into positive.
            // Then converts back to negative.
            if (x < 0)
            {
                x *= -1;
                x = Math.Pow(x, (1.0 / 3.0));
                x *= -1;
                return Math.Round(x, decimalRounding);
            }

            x = Math.Pow(x, (1.0 / 3.0));
            return Math.Round(x, decimalRounding);
        }

        public static double inverse(double x)
        {
            return Math.Round(1/x, decimalRounding); 
        }
    }
}
