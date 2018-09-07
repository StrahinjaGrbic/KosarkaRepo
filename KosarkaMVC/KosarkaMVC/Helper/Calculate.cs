using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KosarkaMVC.Helper
{
    public class Calculate
    {
        public static double Percentage(double a, double b)
        {
            return (a / (a + b) * 100);
        }

        public static int Points(int a, int b)
        {
            return (a * 2 + b);
        }

        public static int PointDifference(int a, int b)
        {
            return (a - b);
        }
    }
}