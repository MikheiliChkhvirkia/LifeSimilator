using System;
using LifeSimilator.Enums;

namespace LifeSimilator.Models.ReusableMethods
{
    public static class NumberOption
    {

        public static void DisplayNumberedOptions<T>(T[] options) where T : Enum
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {options[i]}");
            }
        }
    }
}