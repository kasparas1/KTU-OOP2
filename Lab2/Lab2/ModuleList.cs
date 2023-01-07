using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    /// <summary>
    /// Stores multiple products in a linked list
    /// </summary>
    public class ModuleList : IEnumerable<ModuleInfo>
    {
        class ModuleNode
        {
            public ModuleInfo Data { get; set; }
            public ModuleNode Next { get; set; }

            public ModuleNode(ModuleInfo data = null, ModuleNode next = null)
            {
                Data = data;
                Next = next;
            }
        }

        private ModuleNode head;
        private ModuleNode tail;

        /// <summary>
        /// Append a value to the end of the linked list
        /// </summary>
        /// <param name="module"></param>
        public void AddToEnd(ModuleInfo module)
        {
            ModuleNode node = new ModuleNode(module);
            if (tail != null && head != null)
            {
                tail.Next = node;
                tail = node;
            }
            else
            {
                tail = node;
                head = node;
            }
        }

        /// <summary>
        /// Inserts a value to the start of the linked list
        /// </summary>
        /// <param name="product"></param>
        public void AddToStart(ModuleInfo module)
        {
            ModuleNode node = new ModuleNode(module);
            if (tail != null && head != null)
            {
                node.Next = head;
                head = node;
            }
            else
            {
                tail = node;
                head = node;
            }
        }

        /// <summary>
        /// Get the number of values stored in the linked list
        /// </summary>
        /// <returns>A count</returns>
        public int Count(string lecturerLName)
        {
            int count = 0;
            ModuleNode current = head;
            while (current != null)
            {
                current = current.Next;
                count++;
            }
            return count;
        }

        

        public IEnumerator<ModuleInfo> GetEnumerator()
        {
            ModuleNode current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
       
    }
}