using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.LinkedLists
{
    internal class DoublyLL
    {
        public class DoublyLinkedList
        {
            public class DNode
            {
                public int Data;
                public DNode Prev;
                public DNode Next;

                public DNode(int data)
                {
                    Data = data;
                    Prev = null;
                    Next = null;
                }
            }

            public class DoublyLinkedList
            {
                private DNode head;

                public void AddFirst(int data)
                {
                    DNode newNode = new DNode(data);

                    if (head != null)
                    {
                        newNode.Next = head;
                        head.Prev = newNode;
                    }

                    head = newNode;
                }

                public void AddLast(int data)
                {
                    DNode newNode = new DNode(data);

                    if (head == null)
                    {
                        head = newNode;
                        return;
                    }

                    DNode temp = head;
                    while (temp.Next != null)
                        temp = temp.Next;

                    temp.Next = newNode;
                    newNode.Prev = temp;
                }

                public void AddAtPosition(int data, int position)
                {
                    if (position <= 1)
                    {
                        AddFirst(data);
                        return;
                    }

                    DNode newNode = new DNode(data);
                    DNode temp = head;

                    for (int i = 1; temp != null && i < position - 1; i++)
                    {
                        temp = temp.Next;
                    }

                    if (temp == null)
                    {
                        AddLast(data);
                        return;
                    }

                    newNode.Next = temp.Next;
                    newNode.Prev = temp;

                    if (temp.Next != null)
                        temp.Next.Prev = newNode;

                    temp.Next = newNode;
                }

                public void DeleteFirst()
                {
                    if (head == null) return;

                    head = head.Next;

                    if (head != null)
                        head.Prev = null;
                }

                public void DeleteLast()
                {
                    if (head == null) return;

                    if (head.Next == null)
                    {
                        head = null;
                        return;
                    }

                    DNode temp = head;
                    while (temp.Next != null)
                        temp = temp.Next;

                    temp.Prev.Next = null;
                }

                public void Delete(int value)
                {
                    if (head == null) return;

                    if (head.Data == value)
                    {
                        DeleteFirst();
                        return;
                    }

                    DNode temp = head;

                    while (temp != null && temp.Data != value)
                        temp = temp.Next;

                    if (temp == null) return;

                    if (temp.Next != null)
                        temp.Next.Prev = temp.Prev;

                    temp.Prev.Next = temp.Next;
                }

                public void PrintForward()
                {
                    DNode temp = head;
                    while (temp != null)
                    {
                        Console.Write(temp.Data + " ");
                        temp = temp.Next;
                    }
                    Console.WriteLine();
                }

                public void PrintReverse()
                {
                    if (head == null) return;

                    DNode temp = head;


                    while (temp.Next != null)
                        temp = temp.Next;


                    while (temp != null)
                    {
                        Console.Write(temp.Data + " ");
                        temp = temp.Prev;
                    }
                    Console.WriteLine();
                }
            }


        }
    }
}
