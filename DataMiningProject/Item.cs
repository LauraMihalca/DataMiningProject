using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMiningProject
{
    public class Item: IComparable<Item>
    {

        public string Name { get; set; }
        public double Support { get; set; }


        public int CompareTo(Item other)
        {
            return Name.CompareTo(other.Name);
        }

    }
}
