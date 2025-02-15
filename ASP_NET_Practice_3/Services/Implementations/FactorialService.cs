using ASP_NET_Practice_3.Services.Abstract;
using System.Numerics;
using System.Text;

namespace ASP_NET_Practice_3.Services.Implementations
{
    public class FactorialService : INumberService
    {
        public string GetNumberResult(int number)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"mresult\">");
            sb.Append($"{CheckFNumber(number)}");
            sb.Append("</div>");
            return sb.ToString();
        }

        // Fibonacci number calculation function
        BigInteger FactorialNumber(BigInteger a)
        {
            if (a > 40 || a < 0) // Returning `-1` if value is out of our bounds
            {
                return -1;
            }
            if (a == 0)
                return 1;
            else return a * FactorialNumber(a - 1);
        }

        // Function to check result from FibonacciNumber function
        string CheckFNumber(int t)
        {
            BigInteger a = FactorialNumber((BigInteger)t);
            if (a == -1)
                return "Please check that your value is in range: <code>0 &lt; n &lt; 40</code>. Thank you very much.";
            return a.ToString();
        }
    }
}
