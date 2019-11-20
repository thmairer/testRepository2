using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_TreeApp.models
{
    class BinaryTree
    {
        private BinaryTreeItem Root;

        public BinaryTree()
        {
            this.Root = null;
        }

        public BinaryTree(int Zahl)
        {
            this.Root = new BinaryTreeItem(Zahl,null,null);
        }

        public BinaryTree(BinaryTree bt)
        {
            this.Root = bt.Root;
        }


        
        public void Add(int? itemToAdd)
        {

            if (itemToAdd == null)
            {
                return;
            }

            if (this.Root == null)
            {
                this.Root = new BinaryTreeItem(itemToAdd, null, null);
                return;
            }

            BinaryTreeItem tmp = this.Root;
            while (tmp != null)
            {
                if (tmp.Number.Equals(itemToAdd))
                {
                    tmp.Counter++;
                    return;
                }

                if (itemToAdd > tmp.Number)
                {
                    if (tmp.RightItem == null)
                    {
                        tmp.RightItem = new BinaryTreeItem(itemToAdd, null, null);
                        return;
                    }
                    tmp = tmp.RightItem;

                }

                if (itemToAdd < tmp.Number)
                {
                    if (tmp.LeftItem == null)
                    {
                        tmp.LeftItem = new BinaryTreeItem(itemToAdd, null, null);
                        return;
                    }

                    tmp = tmp.LeftItem;
                }



            }
        }
        
        public BinaryTreeItem FindItem(int? itemToFind)
        {
            //1.Fall
            if (this.Root == null)
            {
                return null;
            }
            //2.Fall
            BinaryTreeItem tmp = this.Root;

            while (tmp != null)
            {


                if (tmp.Number > itemToFind)
                {
                    tmp = tmp.LeftItem;
                }
                if (tmp.Number < itemToFind)
                {
                    tmp = tmp.RightItem;

                }
                if (tmp.Number == itemToFind)
                {

                    return tmp;
                }

            }
            return null;
        }
       
        public BinaryTreeItem Minimum(int? itemToFind)
        {
            if (this.Root == null)
            {
                return null;
            }

            BinaryTreeItem foundItem = FindItem(itemToFind);
            if (foundItem == null)
            {
                return null;
            }
            while (foundItem != null)
            {
                if (foundItem.Number.Equals(itemToFind))
                {
                    if (foundItem.LeftItem != null)
                        foundItem = foundItem.LeftItem;
                }

                return foundItem;
            }
            return null;
        }
        
        public BinaryTreeItem Maximum()
        {
            if (this.Root == null)
            {
                return null;
            }

            BinaryTreeItem tmp = this.Root;
            while (tmp != null)
            {
                if (tmp.Number != null)
                {
                    tmp = tmp.RightItem;
                }

                return tmp;

            }

            return null;
        }

        public BinaryTreeItem Maximum_rekursiv(BinaryTreeItem itemToCheck, int? startValue = null)
        {
            if (this.Root == null)
            {
                return null;
            }

            if (itemToCheck == null)
            {
                itemToCheck = this.Root;
            }

            if (itemToCheck.RightItem == null)
            {
                return itemToCheck;
            }

            return Maximum_rekursiv(itemToCheck.RightItem, startValue);

        }

        public BinaryTreeItem Minimum_rekusiv(int? startvalue = null)
        {
            return Minimum_rekursivIntern();
        }

        public BinaryTreeItem Minimum_rekursivIntern(int? startValue = null,BinaryTreeItem actItem = null)
        {
            //bei ersten Aufruf ist actItem null
            if (actItem == null)
            {
                //falls startValue != null ist, suchen wir das Element im Baum und setzten das actItem
                if (startValue != null)
                {
                    actItem = FindItem(startValue.Value);
                }
                //ansonsten starten wir bei Root
                else
                {
                    actItem = this.Root;
                }
            }
            else
            {
                actItem = actItem.LeftItem;
            }


            if (actItem == null)
            {
                return null;
            }

            //Minimum wurde gefunden
            if (actItem.LeftItem == null)
            {
                return actItem;
            }
            else
            {
                return Minimum_rekursivIntern(startValue, actItem);
            }
        }

        public void Add_Rekursiv(int? itemToAdd, BinaryTreeItem nextValue)
        {
            AddRecursiveIntern(itemToAdd, Root);
        }

        private void AddRecursiveIntern(int? itemToAdd, BinaryTreeItem nextValue)
        {
            if (this.Root == null)
            {
                this.Root = new BinaryTreeItem(itemToAdd, null, null); 
                return;
            }
            if (itemToAdd == nextValue.Number)
            {
                nextValue.Counter ++;
                return;
            }
            if (itemToAdd < nextValue.Number)
            {
                if (nextValue.LeftItem == null)
                {
                    nextValue.LeftItem = new BinaryTreeItem(itemToAdd, null, null); 
                    return;
                }
                AddRecursiveIntern(itemToAdd, nextValue.LeftItem);
            }
            else if (itemToAdd > nextValue.Number)
            {
                if (nextValue.RightItem == null)
                {
                    nextValue.RightItem = new BinaryTreeItem(itemToAdd, null, null);
                }
            }
            AddRecursiveIntern(itemToAdd, nextValue.RightItem);
        }

        public BinaryTreeItem Find_Rekursiv(double itemToFind, BinaryTreeItem currentValue)
        {
            if (this.Root == null)
            {
                return null;
            }

            return FindRecursiveIntern(itemToFind, Root);
        }

        private BinaryTreeItem FindRecursiveIntern(double itemToFind, BinaryTreeItem currentValue)
        {
            if (this.Root == null)
            {
                return null;
            }
            if (itemToFind == currentValue.Number)
            {
                return currentValue;
            }

            else if (itemToFind < currentValue.Number)
            {
                return FindRecursiveIntern(itemToFind, currentValue.RightItem);
            }

            else if (itemToFind > currentValue.Number)
            {
                return FindRecursiveIntern(itemToFind, currentValue.LeftItem);
            }

            return null;
        }

        public BinaryTreeItem FindItemBefore(int? itemToFind)
        {
            BinaryTreeItem itemBefore = null;
            if (itemToFind == null)
            {
                return null;
            }

            if (this.Root == null)
            {
                return null;
            }
            if (this.Root.Number == itemToFind)
            {
                return null;
            }

            BinaryTreeItem actItem = this.Root;

            while (actItem != null)
            {
                if (itemToFind > actItem.Number)
                {
                    if (actItem.RightItem.Number == itemToFind)
                    {
                        itemBefore = actItem;
                        return itemBefore;
                    }
                    else
                    {
                        actItem = actItem.RightItem;
                    }
                    if (itemToFind < actItem.Number)
                    {
                        if (actItem.LeftItem.Number == itemToFind)
                        {
                            itemBefore = actItem;
                            return itemBefore;
                        }
                        else
                        {
                            actItem = actItem.LeftItem;
                        }
                    }
                    if (actItem.LeftItem == null || actItem.RightItem == null)
                    {
                        return null;
                    }


                }


            }
            return null;
        }

        public bool Remove(int? itemToRemove)
        {
            if ((this.Root == null) || (itemToRemove == null))
            {
                return false;
            }

            BinaryTreeItem treeItemToRemove = FindItem(itemToRemove);
            BinaryTreeItem itemBefore = FindItemBefore(itemToRemove);

            if ((itemBefore == null) || (treeItemToRemove == null))
            {
                return false;
            }

            if (treeItemToRemove.Counter > 1)
            {
                treeItemToRemove.Counter--;
                return true;
            }
            else
            {
                //1.Fall:
                if ((treeItemToRemove.LeftItem == null) && (treeItemToRemove.RightItem != null))
                {
                    if (itemBefore.RightItem == treeItemToRemove)
                    {
                        itemBefore.RightItem = treeItemToRemove.RightItem;
                        return true;
                    }
                    else
                    {
                        itemBefore.LeftItem = treeItemToRemove.RightItem;
                        return true;
                    }
                }  
            }

            //2.Fall
            if( (treeItemToRemove.RightItem==null)&&(treeItemToRemove.LeftItem!=null))
            {
                if (itemBefore.LeftItem == treeItemToRemove)
                {
                    itemBefore.LeftItem = treeItemToRemove.LeftItem;
                    return true;
                }
                else
                {
                    itemBefore.RightItem = treeItemToRemove.LeftItem;
                    return true;
                }
            }

            //3.Fall
            if(treeItemToRemove.RightItem.LeftItem == null)
            {
                if(treeItemToRemove.Number < itemBefore.Number)
                {
                    itemBefore.LeftItem = treeItemToRemove.LeftItem;
                    return true;
                }
            }

            //4.Fall


            return false;
        }


    }
}
