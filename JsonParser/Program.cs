using System;

namespace JsonParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var j = new Json();
            var data = j.LoadJson();

            j.PrintJsonData(data);
            j.ExportToTextFile(data);

            Console.ReadKey();
        }
    }
}
