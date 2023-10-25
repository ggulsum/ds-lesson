
using System;
namespace QueueDizi
{
    public class Eleman
    {
        public int veri;
        public Eleman(int veri)
        {
            this.veri = veri;
        }
    }

    public class Queue
    {
        public Eleman[] dizi;
        public int bas;
        public int son;
        int boyut;
        public Queue(int boyut)
        {
            dizi = new Eleman[boyut];
            this.boyut = boyut;
            bas = 0;
            son = 0;
        }

        Boolean QueueBos()
        {
            if (bas == son)
                return true;
            else
                return false;
        }

        Boolean QueueDolu()
        {
            if (bas == (son + 1) % boyut)
                return true;
            else
                return false;
        }

        public void Enqueue(Eleman yeni)
        {
            if (QueueDolu())
            {
                Console.WriteLine("Queue dolu...");
            }
            else
            {
                dizi[son] = yeni;
                son = (son + 1) % boyut;

                if (QueueBos())
                {
                    bas = son;
                }
            }
        }


        public Eleman Dequeue()
        {
            if (QueueBos())
                Console.WriteLine("Queue boş oldugu icin eleman silinemez...");
            else
            {
                Eleman sonuc = dizi[bas];
                bas = (bas + 1) % boyut;
                return sonuc;
            }
            return null;
        }

        public void Yazdir()
        {
            if (QueueBos())
            {
                Console.WriteLine("Queue boş");
                return;
            }

            int i = bas;
            while (i != son)
            {
                Console.Write(dizi[i].veri + "-");
                i = (i + 1) % boyut;
            }
            Console.WriteLine();
        }

    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue q = new Queue(5);

            Eleman e1 = new Eleman(25);
            Eleman e2 = new Eleman(85);
            Eleman e3 = new Eleman(114);

            q.Enqueue(e1);
            q.Enqueue(e2);
            q.Enqueue(e3);
            q.Yazdir();

            Eleman e4 = new Eleman(7);
            Eleman e5 = new Eleman(39);
            q.Enqueue(e4);
            q.Enqueue(e5);
            q.Yazdir();

            q.Dequeue();
            q.Dequeue();
            q.Yazdir();
        }
    }
}