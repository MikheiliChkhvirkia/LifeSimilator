using System;

namespace LifeSimilator.Models.ReusableMethods
{
    public static class Response
    {
        public static bool GetYesNoResponse(string question)
        {
            Console.WriteLine(question);
            string input = Console.ReadLine()?.Trim().ToLower();
            return input == "y";
        }
    }
}
