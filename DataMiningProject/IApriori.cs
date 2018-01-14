using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMiningProject
{
    interface IApriori
    {
        Output ProcessTransaction(double minSupport, double minConfidence, IEnumerable<string> items, string[] transactions);
    }
}
