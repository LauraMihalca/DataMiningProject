using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace DataMiningProject
{
    class Apriori
    {

        readonly ISorter _sorter;


        public Apriori()
        {
            _sorter = new Sorter();
        }


        public Output ProcessTransaction(double minSupport, double minConfidence, IEnumerable<string> items, string[] transactions)
        {
            IList<Item> frequentItems = GetL1FrequentItems(minSupport, items, transactions);
            ItemsDictionary allFrequentItems = new ItemsDictionary();
            allFrequentItems.ConcatItems(frequentItems);
            IDictionary<string, double> candidates = new Dictionary<string, double>();
            double transactionsCount = transactions.Count();

            //do
            //{
            //    candidates = GenerateCandidates(frequentItems, transactions);
            //    frequentItems = GetFrequentItems(candidates, minSupport, transactionsCount);
            //    allFrequentItems.ConcatItems(frequentItems);
            //}
            //while (candidates.Count != 0);

                       return new Output
            {
                FrequentItems = allFrequentItems
            };
        }

        private List<Item> GetL1FrequentItems(double minSupport, IEnumerable<string> items, IEnumerable<string> transactions)
        {
            var frequentItemsL1 = new List<Item>();
            double transactionsCount = transactions.Count();

            foreach (var item in items)
            {
                double support = GetSupport(item, transactions);

                if (support / transactionsCount >= minSupport)
                {
                    frequentItemsL1.Add(new Item { Name = item, Support = support });
                }
            }
            frequentItemsL1.Sort();
            return frequentItemsL1;
        }

        private double GetSupport(string generatedCandidate, IEnumerable<string> transactionsList)
        {
            double support = 0;

            foreach (string transaction in transactionsList)
            {
                if (CheckIsSubset(generatedCandidate, transaction))
                {
                    support++;
                }
            }

            return support;
        }

        private bool CheckIsSubset(string child, string parent)
        {
            foreach (char c in child)
            {
                if (!parent.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }

        //private Dictionary<string, double> GenerateCandidates(IList<Item> frequentItems, IEnumerable<string> transactions)
        //{
        //    Dictionary<string, double> candidates = new Dictionary<string, double>();

        //    for (int i = 0; i < frequentItems.Count - 1; i++)
        //    {
        //        string firstItem = _sorter.Sort(frequentItems[i].Name);

        //        for (int j = i + 1; j < frequentItems.Count; j++)
        //        {
        //            string secondItem = _sorter.Sort(frequentItems[j].Name);
        //            string generatedCandidate = GenerateCandidate(firstItem, secondItem);

        //            if (generatedCandidate != string.Empty)
        //            {
        //                double support = GetSupport(generatedCandidate, transactions);
        //                candidates.Add(generatedCandidate, support);
        //            }
        //        }
        //    }

        //    return candidates;
        //}

        //private string GenerateCandidate(string firstItem, string secondItem)
        //{
        //    int length = firstItem.Length;

        //    if (length == 1)
        //    {
        //        return firstItem + secondItem;
        //    }
        //    else
        //    {
        //        string firstSubString = firstItem.Substring(0, length - 1);
        //        string secondSubString = secondItem.Substring(0, length - 1);

        //        if (firstSubString == secondSubString)
        //        {
        //            return firstItem + secondItem[length - 1];
        //        }

        //        return string.Empty;
        //    }
        //}

        //private List<Item> GetFrequentItems(IDictionary<string, double> candidates, double minSupport, double transactionsCount)
        //{
        //    var frequentItems = new List<Item>();

        //    foreach (var item in candidates)
        //    {
        //        if (item.Value / transactionsCount >= minSupport)
        //        {
        //            frequentItems.Add(new Item { Name = item.Key, Support = item.Value });
        //        }
        //    }

        //    return frequentItems;
        //}

       

    }
}
