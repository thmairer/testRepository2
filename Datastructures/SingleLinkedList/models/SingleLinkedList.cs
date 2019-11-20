using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedList.models
{

    //generic
    class SingleLinkedList<T> where T : class
    {
        private SingleLinkedListItem<T> _firstItem;
        private SingleLinkedListItem<T> _lastItem;

        public SingleLinkedList() 
        {
            this._firstItem = null;
            this._lastItem = null;
        }

        public SingleLinkedList(T item)
        {
            this._firstItem = new SingleLinkedListItem<T>(item,null);
            this._lastItem = _firstItem;
        }

        public SingleLinkedList(SingleLinkedList<T> sll)
        {
            this._firstItem = sll._firstItem;
            this._lastItem = sll._lastItem;
        }






        public bool Add(T itemToAdd)
        {
            //Parameter überprüfen
            if (itemToAdd==null)
            {
                return false;
            }

            //1. Fall: SLL ist leer
            if (this._firstItem==null)
            {
                _firstItem = new SingleLinkedListItem<T>(itemToAdd, null);
                _lastItem = _firstItem;
            }

            //2. Fall: SLL beinhaltet Elemente
            else
            {
                this._lastItem.NextItem = new SingleLinkedListItem<T>(itemToAdd, null);
                this._lastItem = this._lastItem.NextItem;
            }
            return true;
        }

        public bool Remove(T itemToRemove)
        {
            if (itemToRemove == null)
            {
                return false;
            }
            //es existiert noch kein Eintrag in der Liste
            if (this._firstItem == null)
            {
                return false;
            }

            bool isFirstItem;
            SingleLinkedListItem<T> itemBeforeItemToRemove = this.FindItemBeforeItem(itemToRemove, out isFirstItem);

            //Item ist nicht vorhanden
            if( (itemBeforeItemToRemove == null) && (!isFirstItem))
            {
                return false;
            }

            //1ter Fall
            //1ter Eintrag ist der gesuchte Eintrag 
            if (isFirstItem)
            {
                this._firstItem = this._firstItem.NextItem;
                return true;
            }

            //2ter Fall : irgendwo zw firstItem und LastItem
            if(itemBeforeItemToRemove.NextItem.NextItem == null)
            {
                this._lastItem = itemBeforeItemToRemove;
                this._lastItem.NextItem = null;
                return true;
            }

            //3ter Fall: es handelt sich um de letzten Eintrag
            if(itemBeforeItemToRemove.NextItem == itemToRemove)
            {
                itemBeforeItemToRemove.NextItem = itemBeforeItemToRemove.NextItem.NextItem;
                return true;
            }

            return false;



            //1ter Fall : 1ter Eintrag
            //1ter Eintrag ist der gesuchte Eintrag
            /*if (itemToRemove.Equals(this._firstItem.Item))
            {
                this._firstItem = this._firstItem.NextItem;
                return true;
            }

            //2ter Fall : irgendwo zw _firstItem und _lastItem

            SingleLinkedListItem<T> actItem = this._firstItem;
            while(actItem != null)
            {
                if (actItem.NextItem != null)
                {
                    if (actItem.NextItem.Item.Equals(itemToRemove))
                    {
                        actItem.NextItem = actItem.NextItem.NextItem;
                        return true;
                    }
                }
                actItem = actItem.NextItem;
            }


            //3ter Fall: es handelt sich um den letzten Eintrag
            actItem = this._firstItem;
       
            
            
            while (actItem.NextItem != this._lastItem)
            {
                actItem = actItem.NextItem;
            }
                if (actItem.NextItem.Item.Equals(itemToRemove))
                {
                    this._lastItem = actItem;
                    this._lastItem.NextItem = null;
                    return true;
                }
                return false;
            */
        }

        public SingleLinkedListItem<T> Find(T itemToFind)
        {

            SingleLinkedListItem<T> pointer = this._firstItem;

            if( (_firstItem == null) || (itemToFind == null) )
            {
                return null;
            }


            while(pointer != null)
            {
                if(pointer.Item.Equals(itemToFind))
                {
                    return pointer;
                }
                pointer = pointer.NextItem;
            }
            return null;


        }

        public SingleLinkedListItem<T> FindItemBeforeItem(T itemToFind, out bool isStartItem)
        {
            isStartItem = false;
            if(itemToFind == null)
            {
                return null;
            }

            if (this._firstItem == null)
            {
                return null;
            }

            if (this._firstItem.Item.Equals(itemToFind))
            {
                isStartItem = true;
                return null;
            }

            SingleLinkedListItem<T> pointer = this._firstItem;

            while (pointer != null)
            {
                if ( (pointer.NextItem != null)&&(pointer.NextItem.Item.Equals(itemToFind)) )
                {
                    return pointer;
                }
                pointer = pointer.NextItem;
            }
            return null;

        }
         
        public bool AddAfterItem(T itemToFind, T itemToAdd)
        {
            SingleLinkedListItem<T> foundItem = new SingleLinkedListItem<T>();


            //Parameter überprüfen
            if (itemToAdd == null)
            {
                return false;
            }

            if (this._firstItem != null)
            {
                SingleLinkedListItem<T> actItem = this._firstItem;
                while (actItem != null)
                {
                    if (actItem.Equals(itemToFind))
                    {
                        foundItem = actItem;
                        actItem = null;
                    }
                }
            }

            if (foundItem != null)
            {
                foundItem.NextItem = new SingleLinkedListItem<T>(itemToAdd, foundItem.NextItem);
            }
            else
            {
                this._lastItem.NextItem = new SingleLinkedListItem<T>(itemToAdd, null);
                this._lastItem = this._lastItem.NextItem;
            }

            return true;
        }

        public bool Change(T itemToReplace, T itemNewData)
        {
            //Parameter überprüfen 
            if( (itemToReplace == null) || (itemNewData == null) || (this._firstItem == null))
            {
                return false;
            }


            SingleLinkedListItem<T> itemToChange = Find(itemToReplace);

            if (itemToChange == null)
            {
                return false;
            }
            else
            {
                itemToChange.Item = itemNewData;
                return true;
            }

        }







        public override string ToString()
        {
            string s = "";
            if (this._firstItem!=null)
            {
                SingleLinkedListItem<T> actItem = this._firstItem;
                while (actItem != null)
                {
                    s += actItem.Item.ToString() + "\n";
                    actItem = actItem.NextItem;
                }
            }

            if (s=="")
            {
                return "no item!";
            }

            return s;
        }

       
    }
}
