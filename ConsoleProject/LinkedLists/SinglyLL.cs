using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.LinkedLists
{
    internal class SinglyLL
    {
        public class SinglyLinkedList
        {
            public class Node(int data)
            {
                public int Data = data;
                public Node Next = null;
            }

            private Node head;

            public void AddFirst(int data)
            {
                Node newNode = new Node(data);

                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    newNode.Next = head;
                    head = newNode;
                }
            }

            public void AddLast(int data)
            {
                Node newNode = new Node(data);

                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    Node temp = head;

                    while(temp.Next != null)
                    {
                        temp = temp.Next;

                    }
                    temp.Next = newNode;
                }
            }

            public void AddAtPosition(int data, int position)
            {
                if(position == 1)
                {
                    AddFirst(data);

                }

                Node newNode = new Node(data);
                Node temp = head;

                for (int i = 1; temp != null && i < position - 1; i++)
                    temp = temp.Next;

                if (temp == null)
                {
                    Console.WriteLine("Position out of range");
                    return;
                }

                newNode.Next = temp.Next;
                temp.Next = newNode;

            }

            public void DeleteFirst()
            {
                if (head == null) return;
                head = head.Next;
            }

            public void DeleteLast()
            {
                if (head == null) return;
                if (head.Next == null)
                {
                    head = null;
                    return;
                }

                Node temp = head;
                while (temp.Next.Next != null)
                    temp = temp.Next;

                temp.Next = null;
            }

            public void Display()
            {
                Node temp = head;
                while(temp != null)
                {
                    Console.Write(temp.Data + " -> ");
                    temp = temp.Next;
                }
            }
        }

        public static void Main(string[] args)
        {
            SinglyLinkedList ll1 = new SinglyLinkedList();

            ll1.AddFirst(10);
            ll1.AddLast(20);
            ll1.AddLast(30);
            ll1.AddAtPosition(50, 2);

            ll1.DeleteFirst();

            ll1.Display();
        }
    }
}
