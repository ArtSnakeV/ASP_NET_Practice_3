using ASP_NET_Practice_3.Services.Abstract;
using ASP_NET_Practice_3.Services.Implementations;

namespace ASP_NET_Practice_3.Middleware
{
    public class NumberMiddleware
    {
        private RequestDelegate next;
        private INumberService numberService;

        // Dependency Injection
        public NumberMiddleware(RequestDelegate next, INumberService numberService) {
            this.next = next;
            this.numberService = numberService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path;
            if (!string.IsNullOrEmpty(path) && path.ToString() == "/calculate")
            {
                // Let's try to get value of our number ("index")
                if (int.TryParse(context.Request.Query["index"], out int indexValue))
                {
                    // Find out which radio button is choosen 
                    if (int.TryParse(context.Request.Query["rad_button"], out int radButton))
                    {
                        // Creating our abstract service for the result
                        INumberService resService;
                        context.Response.ContentType = "text/html";
                        // Adding top part of the page
                        string result = "<!DOCTYPE html> " +
                            "<html> " +
                            "<head> " +
                            "<meta charset=\"utf-8\" /> " +
                            " <title></title> " +
                            " <link href=\"../css/style.css\" rel=\"stylesheet\" /> " +
                            "</head> " +
                            "<body> " +
                            "<div class=\"container\"> ";


                        // Depending of choosen `radio button` calculating corresponding number
                        if (radButton == 0) // User wants `Fibonacci` calculation
                        {
                            resService = new FibonacciService();
                            result += "<h1>Fibonacci number</h1>  <div>Your Fibonacci number is </div> <div>";
                            result += resService.GetNumberResult(indexValue).ToString();
                            result += "</div>";
                        }
                        else // Factorial calculation
                        {
                            resService = new FactorialService();
                            result += "<h1>Factorial number</h1>  <div>Your factorial number is </div> <div>";
                            result += resService.GetNumberResult(indexValue).ToString();
                            result += "</div>";
                            
                        }
                        
                        // Adding bottom part of the page
                        result += "<input type=\"submit\" value=\"To home page\" class=\"button\"> " +
                            " </div> " +
                            "</body> " +
                            "</html>";
                        await context.Response.WriteAsync(result);
                    }
                }
            }
            else
            {
                await next(context);
            }
        }
    }
}
