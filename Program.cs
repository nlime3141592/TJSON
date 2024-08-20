using System;

namespace nl.TJSON
{
    internal class Program
    {
        private static TJSON tjson = new TJSON();

        private static void Main(string[] args)
        {
            TryParseNumber("-60");
            TryParseNumber("32.23e2");
            TryParseNumber("+68.67e-10");
            TryParseNumber("0x7b6");
            TryParseNumber("-0b1010011110");
            TryParseNumber("01012345678");
        }

        private static void TryParseNumber(string _str)
        {
            Console.WriteLine("Parse Number {0, -16} == {1}", _str, tjson.ParseNumber(_str));
        }
    }
}