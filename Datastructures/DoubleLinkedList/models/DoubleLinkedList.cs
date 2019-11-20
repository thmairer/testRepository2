using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedList.models
{
    class DoubleLinkedList<T> where T : class
    {
        private DoubleLinkedListItem<T> _firstItem;
        private DoubleLinkedListItem<T> _lastItem;

        public DoubleLinkedList()
        {
            this._firstItem = null;
            this._lastItem = null;
        }

        public DoubleLinkedList(T item)
        {
            this._firstItem = new DoubleLinkedListItem<T>(item, null, null);
            this._lastItem = _firstItem;
        }

        public DoubleLinkedList(DoubleLinkedList<T> dll)
        {
            this._firstItem = dll._firstItem;
            this._lastItem = dll._lastItem;
        }


        public bool Add(T itemToAdd)
        {
            if (itemToAdd == null)
            {
                return false;
            }

            if (this._firstItem == null)
            {
                this._firstItem = new DoubleLinkedListItem<T>(itemToAdd, null, null);
                _lastItem = _firstItem;
            }

            else
            {
                this._lastItem.NextItem = new DoubleLinkedListItem<T>(itemToAdd, null, this._lastItem);
                this._lastItem = this._lastItem.NextItem;
            }
            return true;

        }

        public bool Remove(T itemToFind, T itemToRemove)
        {
            if ((itemToRemove == null) || (this._firstItem == null) ||(itemToFind == null))
            {
                return false;
            }

            DoubleLinkedListItem<T> foundItem = Find(itemToFind);

            if (foundItem.Equals(this._firstItem))
            {
                this._firstItem = this._firstItem.NextItem;
                return true;
            }

            if (foundItem.Equals(this._lastItem))
            {
                this._lastItem = this._lastItem.ItemBefore;
                return true;
            }



            if(foundItem == null)
            {
                return false;
            }
            else
            {
                foundItem.ItemBefore.NextItem = foundItem.NextItem;
                foundItem.NextItem.ItemBefore = foundItem.ItemBefore;
                return true; 
            }

        }

        public DoubleLinkedListItem<T> Find(T itemToFind)
        {
            DoubleLinkedListItem<T> pointer = this._firstItem;

            if ((_firstItem == null) || (itemToFind == null))
            {
                return null;
            }


            while (pointer != null)
            {
                if (pointer.Item.Equals(itemToFind))
                {
                    return pointer;
                }
                pointer = pointer.NextItem;
            }
            return null;



        }

        public bool AddAfter(T itemToFind, T itemToAdd)
        {

            if ((itemToAdd == null) || (itemToFind == null))
            {
                return false;
            }

            if (this._firstItem == null)
            {
                return Add(itemToAdd);
            }

            DoubleLinkedListItem<T> foundItem = Find(itemToFind);


            if (foundItem == null)
            {
                return Add(itemToAdd);
            }

            if(foundItem == this._lastItem)
            {
                this._lastItem.NextItem = new DoubleLinkedListItem<T>(itemToAdd, null, this._lastItem);
                this._lastItem = this._lastItem.NextItem;
            }

            else
            {
                DoubleLinkedListItem<T> newItem = new DoubleLinkedListItem<T>(itemToAdd, foundItem.NextItem, foundItem);
                foundItem.NextItem = newItem;
                newItem.NextItem.ItemBefore = newItem;
            }

            return true;

        }

        public bool Change(T itemToChange, T itemNewData)
        {
            if( (itemToChange == null)||(itemNewData == null)||(this._firstItem == null))
            {
                return false;
            }

            DoubleLinkedListItem<T> foundItem = Find(itemToChange);

            if(foundItem == null)
            {
                return false;
            }
            else
            {
                foundItem.Item = itemNewData;
                return true;
            }

        }

        public DoubleLinkedListItem<T> FindRecursiv(T itemToFind, DoubleLinkedListItem<T> actItem = null)
        {
            if (itemToFind == null)
            {
                return null;
            }

            // ist die DLL leer
            if(this._firstItem == null)
            {
                return null;
            }

            //actItem == null bedeuted, dass FindRecursiv am Beginn der DLL starten soll
            if (actItem == null)
            {
                actItem = this._firstItem;
            }

            //ansonsten, soll der Zeiger auf das nächste Element gesetzt werden
            else
            {
                actItem = actItem.NextItem;
            }

            //actItem wird normalerweise auf ActItem.NextItem gesetzt
            //  ->actItem könnte Null sein (Ende der Liste)
            if (actItem == null)
            {
                return null;
            }

            //ist das aktuelle Element das gesuchte Element
            else if (actItem.Item.Equals(itemToFind))
            {
                return actItem;
            }

            //ansonsten wurde das Element noch nicht gefunden und das Ende der Liste wurde noch nicht erreicht
            //  Ende der Liste wurde noch nicht erreicht
            else
            {
                //rekursiver Aufruf
                return FindRecursiv(itemToFind, actItem);
            }


        }



        public override string ToString()
        {
            string s = "";
            if (this._firstItem != null)
            {
                DoubleLinkedListItem<T> actItem = this._firstItem;
                while (actItem != null)
                {
                    s += actItem.Item.ToString() + "\n";
                    actItem = actItem.NextItem;
                }
            }

            if (s == "")
            {
                return "no item!";
            }

            return s;
        }

    }
}

