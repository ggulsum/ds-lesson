using System;
namespace QueueList
{
    public class  Node
    {
        public int veri;
        public Node ileri;
        public Node(int veri)
        {
            this.veri = veri;
            this.ileri = null;
        }
    }

    public class Queue
    {
        Node bas;
        Node son;
        public Queue()
        {
            this.bas = null;
            this.son = null;
        }

        public void Enqueue(int veri)
        {
            Node node = new Node(veri); //düğüm hazır
            if (bas == null)
                son = bas = node; //ekleme sona
            else
            {
                son.ileri = node;
                son = node;
            }
        }

        public int Dequeue()
        {
            if (bas == null)
            {
                Console.WriteLine("Kuyruk boş");
                return 0;
            }    
            else
            {
                bas = bas.ileri;
                return bas.veri;
            }
        }

        public void Yazdir()
        {           
            if (bas != null)
            {
                Node temp = bas;
                while( temp != null)
                {
                    Console.Write(temp.veri + "-");
                    temp = temp.ileri;
                }
            }
            else
                Console.WriteLine("Kuyruk boş");
            Console.WriteLine();
        }
        

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Queue q = new Queue();
            q.Enqueue(18);
            q.Enqueue(57);
            q.Enqueue(21);
            q.Enqueue(5);
            q.Enqueue(410);
            q.Yazdir();

            q.Dequeue();
            q.Dequeue();
            q.Yazdir();

        }
    }

} 