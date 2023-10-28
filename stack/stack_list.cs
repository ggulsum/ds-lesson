using System;
namespace StackBagliListe
{
    public class StackBagli
    {
        public class Node
        {
            public Node ileri;   //gösterici
            public int eleman;

            public Node(int eleman)
            {
                this.eleman = eleman;
                this.ileri = null;
            }
        }

        public class Stack
        {
            Node top;
            public Stack()
            {
                top = null;
            }

            public Boolean StackBos()
            {
                if (top == null)
                    return true;
                else
                    return false;
            }

            public void push(int eleman)
            {
                Node data = new Node(eleman);
                if (StackBos())
                {
                    top = data;
                }
                else
                {
                    data.ileri = top;
                    top = data;
                }
            }

            public void pop()
            {
                if (StackBos())
                    Console.WriteLine("Stack boş...");
                else
                {
                    int sayi = top.eleman;
                    top = top.ileri;
                }
            }

            public void Yazdir()
            {
                Node temp = top;
                if (temp == null)
                    Console.WriteLine("stack bos");
                else
                {
                    while (temp != null)
                    {
                        Console.Write(temp.eleman + "-");
                        temp = temp.ileri;
                    }
                }
            }

        }

        static void Main(string[] args)
        {
            Stack s = new Stack();
            s.push(10);
            s.push(20);
            s.push(30);
            s.push(40);
            s.push(50);
            s.Yazdir();
            Console.WriteLine();
            s.pop();
            s.pop();
            s.Yazdir();
            Console.ReadKey();
        }


    }
}