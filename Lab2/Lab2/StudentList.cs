using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    /// <summary>
    /// Stores a orders in a linked list
    /// </summary>
    public class StudentList : IEnumerable<StudentM>
    {
        class StudentNode
        {
            public StudentM Data { get; set; }
            public StudentNode Next { get; set; }

            public StudentNode(StudentM data = null, StudentNode next = null)
            {
                Data = data;
                Next = next;
            }
        }

        private StudentNode head;
        private StudentNode tail;

        /// <summary>
        /// Append a value to the end of the linked list
        /// </summary>
        /// <param name="student"></param>
        public void AddToEnd(StudentM student)
        {
            StudentNode node = new StudentNode(student);
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
        public void AddToStart(StudentM student)
        {
            StudentNode node = new StudentNode(student);
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
            StudentNode current = head;
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
        /*public void Sort()
        {
            for (StudentNode nodeA = head; nodeA != null; nodeA = nodeA.Next)
            {
                StudentNode min = nodeA;
                for (StudentNode nodeB = nodeA.Next; nodeB != null; nodeB = nodeB.Next)
                {
                    if (nodeB.Data < min.Data)
                    {
                        min = nodeB;
                    }
                }

                StudentM tmp = nodeA.Data;
                nodeA.Data = min.Data;
                min.Data = tmp;
            }
        }*/

        public override string ToString()
        {
            return String.Format("OrderList{ Count = '{0}' }", Count());
        }

        public IEnumerator<StudentM> GetEnumerator()
        {
            StudentNode current = head;
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