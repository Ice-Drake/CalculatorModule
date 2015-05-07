using System;
using System.Collections.Generic;
using System.Text;
using Library;
using PluginSDK;
using DDay.iCal;

namespace MultiDesktop
{
    public class ITodoTree : AVLTree<AVLDateListElement<ITodo>>
    {
        public ITodoTree()
        {
        }

        /**
         * Insert into the tree; duplicates are ignored.
         * @param x the item to insert.
         */
        public void insert(ITodo x)
        {
            AVLDateListElement<ITodo> found = find(x.Start.Date.Date);
            if (found != null)
            {
                found.list.Add(x);
            }
            else
            {
                AVLDateListElement<ITodo> node = new AVLDateListElement<ITodo>(x.Start.Date.Date);
                node.list.Add(x);
                base.insert(node);
            }
        }

        /**
         * Remove from the tree. Nothing is done if x is not found.
         * @param x the item to remove.
         * @return true if removed successfully, false otherwise.
         */
        public bool remove(ITodo x)
        {
            AVLDateListElement<ITodo> found = find(x.Start.Date.Date);
            if (found != null)
            {
                if (found.list.Count > 1)
                {
                    found.list.Remove(x);
                    return true;
                }
                else
                    return base.remove(found);
            }
            else
                return false;
        }

        /**
        * Internal method to print a subtree in sorted order.
        * @param t the node that roots the tree.
        */
        private void getTreeContent(AVLNode<AVLDateListElement<ITodo>> t, AVLNode<AVLDateListElement<ITodo>> x, List<ITodo> list)
        {
            if (t != null)
            {
                getTreeContent(t.left, x, list);
                if (x.element.CompareTo(t.element) >= 0)
                    list.AddRange(CompletePrerequisite(t.element));
                if (t.right != null && x.element.CompareTo(t.right.element) >= 0)
                    getTreeContent(t.right, x, list);
            }
        }

        private List<ITodo> CompletePrerequisite(AVLDateListElement<ITodo> element)
        {
            List<ITodo> list = new List<ITodo>();
            foreach (ITodo task in element.list)
            {
                if (task.Status != TodoStatus.Completed)
                    list.Add(task);
            }
            return list;
        }

        public List<ITodo> GetDateInfo(DateTime date)
        {
            List<ITodo> tasks = new List<ITodo>();
            AVLDateListElement<ITodo> search = new AVLDateListElement<ITodo>(date.Date);
            getTreeContent(root, new AVLNode<AVLDateListElement<ITodo>>(search), tasks);
            return tasks;
        }

        /**
         * Find an item in the tree.
         * @param x the item to search for.
         * @return the matching item or null if not found.
         */
        public AVLDateListElement<ITodo> find(DateTime date)
        {
            AVLDateListElement<ITodo> search = new AVLDateListElement<ITodo>(date.Date);
            AVLDateListElement<ITodo> found = base.find(search);
            return found;
        }
    }
}
