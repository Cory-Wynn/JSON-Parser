using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace JsonParser
{
    class Json
    {
        private readonly string _testFilePath = ConfigurationSettings.AppSettings["TestFilePath"];

        public List<Item> LoadJson()
        {
            using (StreamReader r = new StreamReader(_testFilePath))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Item>>(json);
            }
        }

        public void PrintJsonData(List<Item> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(GetAllProperties(item));
            }
        }

        public void ExportToTextFile(List<Item> items)
        {
            using (TextWriter tw = new StreamWriter("JsonData.txt"))
            {
                foreach (var item in items)
                    tw.WriteLine(GetAllProperties(item));
            }
        }

        #region Helpers

        private static string GetAllProperties(object obj)
        {
            return string.Join(" ", obj.GetType()
                .GetProperties()
                .Select(prop => prop.GetValue(obj)));
        }

        #endregion

    }
}
