using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMiningProject
{
    public class Util
    {
        public static IList<string> ReadFromFile(string filepath)
        {
            int counter = 0;
            string line;
            IList<string> items = new List<string>();

            System.IO.StreamReader file = new System.IO.StreamReader(filepath);
            while ((line = file.ReadLine()) != null)
            {
                string[] names = line.Split(' ');
                foreach (var name in names)
                    items.Add(name);
                counter++;
            }
            file.Close();
            return items;
        }
    }
}
