using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMiningProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> items = Util.ReadFromFile(@"D:\Master\Data Mining\DataMiningProject\apriori.txt");

            string[] transactions = { "abc", "ac" };            

            var apriori = new Apriori();
            var result = apriori.ProcessTransaction(1, 1, items, transactions);

            foreach (var item in result.FrequentItems)
            {
                Console.WriteLine("Name: " + item.Name + "; Support: " + item.Support);
            }
        }

    }
    }

