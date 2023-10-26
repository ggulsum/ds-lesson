using System;
using System.Reflection.Emit;

namespace Aritmetik
{
    public class pnode
    {
        public int katsayi, us;
        public pnode ileri;
        public pnode(int katsayi, int us)
        {
            this.katsayi = katsayi;
            this.us = us;
            ileri = null;
        }
    }
    public class liste
    {
        pnode bas;
        pnode son;
        public liste()
        {
            bas = null;
            son = null;
        }
        public void basaEkle(pnode yeni)
        {
            if (son == null)
                son = yeni;
            yeni.ileri = bas;
            bas = yeni;
        }
        public void sonaEkle(pnode yeni)
        {
            if (bas == null)
                bas = yeni;
            else
                son.ileri = yeni;
            son = yeni;
        }
        public void listele()
        {
            pnode temp = bas;
            while (temp != null)
            {
                Console.Write(temp.katsayi + "*x^" + temp.us + " ");
                temp = temp.ileri;
            }
            Console.WriteLine("");
        }
        public liste topla(liste l1, liste l2)
        {
            pnode temp1 = l1.bas;
            pnode temp2 = l2.bas;
            pnode node;
            int katsayi, us;
            liste yeniListe = new liste();
            while (temp1 != null && temp2 != null)
            {
                if (temp1.us == temp2.us)
                {
                    katsayi = temp1.katsayi + temp2.katsayi;
                    us = temp1.us;
                    temp1 = temp1.ileri;
                    temp2 = temp2.ileri;
                }
                else
                {
                    if (temp1.us > temp2.us)
                    {
                        katsayi = temp1.katsayi;
                        us = temp1.us;
                        temp1 = temp1.ileri;
                    }
                    else
                    {
                        katsayi = temp2.katsayi;
                        us = temp2.us;
                        temp2 = temp2.ileri;
                    }
                }
                if (katsayi != 0)
                {
                    node = new pnode(katsayi, us);
                    yeniListe.sonaEkle(node);
                }
            }
            pnode temp3;
            if (temp1 == null)
                temp3 = temp2;
            else
                temp3 = temp1;
            while (temp3 != null)
            {
                node = new pnode(temp3.katsayi, temp3.us);
                yeniListe.sonaEkle(node);
                temp3 = temp3.ileri;
            }
            return yeniListe;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            pnode n1 = new pnode(5, 2);
            pnode n2 = new pnode(7, 1);
            pnode n3 = new pnode(3, 0);
            liste l1 = new liste();
            l1.sonaEkle(n1);
            l1.sonaEkle(n2);
            l1.sonaEkle(n3);
            liste l2 = new liste();
            pnode n4 = new pnode(8, 2);
            pnode n5 = new pnode(5, 1);
            pnode n6 = new pnode(1, 0);
            l1.listele();
            l2.sonaEkle(n4);
            l2.sonaEkle(n5);
            //l2.sonaEkle(n6);
            l2.listele();
            liste l3 = new liste();
            l3 = l3.topla(l1, l2);
            l3.listele();
        }
    }
}
