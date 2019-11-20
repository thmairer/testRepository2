using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_TreeApp.models
{
    class BinaryTreeItem
    {
        private int _counter { get; set; }
        public int? Number { get; set; }

        public BinaryTreeItem LeftItem { get; set; }
        public BinaryTreeItem RightItem { get; set; }

        public int Counter
        {
            get
            {
                return this._counter;
            }
            set
            {
                if(value > 0)
                {
                    this._counter = value;
                }
            }
        }



        public BinaryTreeItem() : this(null, null,null) { }
        public BinaryTreeItem( int? number, BinaryTreeItem leftItem, BinaryTreeItem rightItem)
        {
            this.Number = number;
            this.LeftItem = leftItem;
            this.RightItem = rightItem;
            if(number == null)
            {
                this.Counter = 0;
            }
            else
            {
                this.Counter = 1;
            }
        }



        public override string ToString()
        {
            if(this.Number == 0)
            {
                return "Leerer Eintrag" + " (" + this.Counter + ") ";
            }
            else
            {
                return this.Number + " (" + this.Counter + ") ";
            }

        }

    }
}
