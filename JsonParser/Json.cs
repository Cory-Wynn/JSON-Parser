using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace JsonParser
{
    class Json
    {
        public List<Item> LoadJson()
        {
            using (StreamReader r = new StreamReader(@"TestFiles\Test.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Item>>(json);
            }
        }

        public void PrintJsonData(List<Item> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.Message);
                Console.WriteLine(item.Id);
            }
        }

        public void ExportToTextFile(List<Item> items)
        {
            using (TextWriter tw = new StreamWriter("JsonData.txt"))
            {
                foreach (var item in items)
                    tw.WriteLine(item.Id + item.Message);
            }
        }
    }
}
