using System;

/*
 * By Michael Evans
 * student ID P288106
 *
 * ArithmeticLibrary Version 2
 * 
 */

namespace ArithmeticLibrary
{
    //supplies basic arithmetic functions.
    // The results of all Algebraic functions are rounded to 8 decimal places.
    public class Arithmetic
    {
        // how many decimal places answers will be  rounded to.
        private static int decimalRounding = 8;

        public static double add(double a, double b)
        {
            return Math.Round((a + b), decimalRounding);
        }

        public static double subtract(double a, double b)
        {
            return Math.Round((a - b), decimalRounding);
        }

        public static double divide(double a, double b)
        {
            return Math.Round((a / b), decimalRounding);
        }

        public static double multiply(double a, double b)
        {
            return Math.Round((a * b), decimalRounding);
        }
    }
}
