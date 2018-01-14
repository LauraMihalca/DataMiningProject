using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMiningProject
{
    public class ItemsDictionary: KeyedCollection<string, Item>
    {
         protected override string GetKeyForItem(Item item)
         {
                return item.Name;
         }

         public void ConcatItems(IList<Item> frequentItems)
         {
               foreach (var item in frequentItems)
               {
                    this.Add(item);
               }
         }

        
    }
}
