using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD_24.Code
{
    /// <summary>
    /// Stores a orders in a linked list
    /// </summary>
    public class OrderList : IEnumerable<Order>
    {
        class OrderNode
        {
            public Order Data { get; set; }
            public OrderNode Next { get; set; }

            public OrderNode(Order data = null, OrderNode next = null)
            {
                Data = data;
                Next = next;
            }
        }

        private OrderNode head;
        private OrderNode tail;

        /// <summary>
        /// Append a value to the end of the linked list
        /// </summary>
        /// <param name="customer"></param>
        public void AddToEnd(Order customer)
        {
            OrderNode node = new OrderNode(customer);
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
        /// Insert a value to the start of the linked list
        /// </summary>
        /// <param name="customer"></param>
        public void AddToStart(Order customer)
        {
            OrderNode node = new OrderNode(customer);
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
        /// Get the number of values stored in linked list
        /// </summary>
        /// <returns>A count</returns>
        public int Count()
        {
            int count = 0;
            OrderNode current = head;
            while (current != null)
            {
                current = current.Next;
                count++;
            }
            return count;
        }

        /// <summary>
        /// Sorts the linked list
        /// </summary>
        public void Sort()
        {
            for (OrderNode nodeA = head; nodeA != null; nodeA = nodeA.Next)
            {
                OrderNode min = nodeA;
                for (OrderNode nodeB = nodeA.Next; nodeB != null; nodeB = nodeB.Next)
                {
                    if (nodeB.Data < min.Data)
                    {
                        min = nodeB;
                    }
                }

                Order tmp = nodeA.Data;
                nodeA.Data = min.Data;
                min.Data = tmp;
            }
        }

        public override string ToString()
        {
            return String.Format("OrderList{ Count = '{0}' }", Count());
        }

        public IEnumerator<Order> GetEnumerator()
        {
            OrderNode current = head;
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