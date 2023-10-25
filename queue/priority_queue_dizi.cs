using System;
//büyükten kücüge öncelikli sıralar
namespace PriorityQueue
{
    public class Priority
    {
        private int max;
        private int[] dizi;
        private int item;
        public Priority(int kapasite)
        {
            max = kapasite;
            dizi = new int[kapasite];
            item = 0;
        }

        public void Enqueue(int data)
        {
            int i;
            if (item == 0)
            {
                dizi[0] = data;
                item++;
                return;
            }
            for(i = item-1; i >= 0; i--)
            {
                if(data > dizi[i])
                {
                    dizi[i+1] = dizi[i];
                }
                else
                    break;
            }
            dizi[i + 1] = data;
            item++;
        }

        public int Dequeue()
        {
            if (item == 0)
            {
                Console.WriteLine("Queue boş");
                return -1;
            }

            int silinen = dizi[0];

            for (int i = 1; i < item; i++)
            {
                dizi[i - 1] = dizi[i];
            }

            item--;

            return silinen;
        }

        public void Yazdir()
        {
            for(int i = 0; i <item; i++)
                Console.Write(dizi[i] +"-");
            Console.WriteLine();
        }

        public Boolean DoluMu()
        {
            return item == max;
        }

        public Boolean BosMu()
        {
            return item == 0;
        }

        public static void Main(string[] args)
        {
            Priority p = new Priority(10);
            p.Enqueue(70);
            p.Enqueue(25);
            p.Enqueue(65);
            p.Enqueue(120);
            p.Enqueue(31);
            p.Enqueue(57);
            p.Enqueue(24);
            p.Enqueue(86);
            p.Enqueue(12);
            p.Enqueue(45);
            p.Yazdir();

            Console.WriteLine(p.DoluMu());
            Console.WriteLine(p.BosMu());

            p.Dequeue();
            p.Yazdir();
        }

    }
}