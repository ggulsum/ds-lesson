using System;
using System.Security;
namespace odev
{
    //dugumu tasarimi ve olusturulmasi
    public class node
    {
        public int veri;
        public node ileri;
        public node(int veri)
        {
            this.veri = veri;
            ileri = null;
        }
    }
    public class queue
    {
        public node bas;
        public queue()
        {
            bas = null;
        }
        /*listeye elemanları kucukten buyuge eklenecek sekilde metot yazildi*/
        public void enqueue(node dugum)
        {
            if (bas == null || bas.veri > dugum.veri)
            /*bu kisimda listenin bos halde oldugunda ya da yeni gelen dugumun 
            verisi bas degerinden kucuk oldugunda; yeni gelen dugumumuz bas 
           degerine esit olur.*/
            {
                dugum.ileri = bas;
                bas = dugum;
            }
            else
            {
                node temp = bas;
                while (temp.ileri != null && temp.ileri.veri <= dugum.veri)
                /*temp degerinin ilerisi null olmadıgı sürece ve temp.ileri.veri 
               dugumun verisinden kucuk esit oldugu kosulda temp degerini ilerletiriz*/
                {
                    temp = temp.ileri;
                }
                dugum.ileri = temp.ileri;
                temp.ileri = dugum;
            }
        }

        public void dequeue()
        {
            if (bas == null)
                Console.WriteLine("Silinecek eleman yok");
            else
            {
                bas = bas.ileri;
            }
        }

        public void yazdir()
        {
            node temp = bas;
            while (temp != null)
            {
                Console.Write(temp.veri + "-");
                temp = temp.ileri;
            }
        }
    }
    public class Odev
    {
        static void Main(string[] args)
        {
            node n1 = new node(10);
            node n2 = new node(50);
            node n3 = new node(40);
            node n4 = new node(15);
            node n5 = new node(50);
            node n6 = new node(35);
            node n7 = new node(5);
            node n8 = new node(21);
            node n9 = new node(65);
            queue kuyruk = new queue();
            kuyruk.enqueue(n1);
            kuyruk.enqueue(n2);
            kuyruk.enqueue(n3);
            kuyruk.enqueue(n4);
            kuyruk.enqueue(n5);
            kuyruk.enqueue(n6);
            kuyruk.enqueue(n7);
            kuyruk.enqueue(n8);
            kuyruk.enqueue(n9);
            Console.WriteLine("Kucukten buyuge oncelikli siralanmis hali:");
            kuyruk.yazdir();
            kuyruk.dequeue();
            kuyruk.dequeue();
            Console.WriteLine("\nListeden silinmis hali:");
            kuyruk.yazdir();
        }
    }
}