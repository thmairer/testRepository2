using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedList.models
{

    //generic
    class SingleLinkedListItem<T> where T : class
    {
        public T Item { get; set; }

        //Refernz auf das nächste Item
        public SingleLinkedListItem<T> NextItem { get; set; }



        public SingleLinkedListItem() : this(null, null) { }
        public SingleLinkedListItem(T item, SingleLinkedListItem<T> nextItem)
        {
            this.Item = item;
            this.NextItem = nextItem;
        }


        public override string ToString()
        {
            return this.Item.ToString();
        }

    }
}
