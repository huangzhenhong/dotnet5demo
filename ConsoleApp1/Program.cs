using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string tempStr = "abcdefghijkl";

            Console.WriteLine(tempStr.Substring(1, 3));
            Console.WriteLine(tempStr[1..^2]);


            // csharp_style_prefer_range_operator = true
            string sentence = "the quick brown fox";
            var sub = sentence[0..4];

            Console.WriteLine(sub);

            // csharp_style_prefer_range_operator = false
            //string sentence = "the quick brown fox";
            //var sub = sentence.Substring(0, sentence.Length - 4);



            Console.ReadLine();



        }
    }
}
