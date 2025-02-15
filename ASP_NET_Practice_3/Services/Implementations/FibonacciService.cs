﻿using ASP_NET_Practice_3.Services.Abstract;
using System.Text;

namespace ASP_NET_Practice_3.Services.Implementations
{
    public class FibonacciService : INumberService
    {
        public string GetNumberResult(int number)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<label class=\"mresult\">");
            sb.Append($"{CheckFNumber(number)}");
            sb.Append("</label>");
            return sb.ToString();
        }

        // Fibonacci number calculation function
        int FibonacciNumber(int a)
        {
            if (a > 40 || a < 0) // Returning `-1` if value is out of our bounds
            {
                return -1;
            }
            if (a == 0) // if `0`, number is `0`
                return 0;
            else if (a == 1)
            {
                return 1; // if `1`, number is `1`
            }
            else
            {
                return FibonacciNumber(a - 1) + FibonacciNumber(a - 2);
            }
        }

        // Function to check result from FibonacciNumber function
        string CheckFNumber(int t)
        {
            int a = FibonacciNumber(t);
            if (a == -1)
                return "Please check that your value is in range: <code>0 &lt; n &lt; 40</code>. Thank you very much.";
            return a.ToString();
        }


    }
    
}
