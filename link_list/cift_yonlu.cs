using System;
using System.Reflection.Emit;

namespace CiftYonluListe
{
    public class node
    {
        public int veri;
        public node ileri;
        public node geri;
        public node(int veri)
        {
            this.veri = veri;
            ileri = null;
            geri = null;
        }
    }

    public class ciftbListe
    {
        public node bas;
        public node son;
        public ciftbListe()
        {
            bas = null;
            son = null;
        }

        public void basaEkle(node yeni)
        {
            if (son == null)
                son = yeni;
            else
                bas.geri = yeni;
            yeni.ileri = bas;
            yeni.geri = null;
            bas = yeni;
        }

        public void sonaEkle(node yeni)
        {
            if (bas == null)
                bas = yeni;
            else
                son.ileri = yeni;
            yeni.geri = son;
            son = yeni;
        }

        public void ortayaEkle(node yeni)
        {
            if (bas == null)
            {
                bas = yeni;
                return;
            }

            int boyut = say();
            int orta = boyut / 2;
            node temp = bas;
            node once = null;
            for (int i = 0; i < orta; i++)
            {
                once = temp;
                temp = temp.ileri;
            }
            if (boyut % 2 == 0)
            {
                yeni.ileri = temp;
                yeni.geri = temp.geri;
                temp.geri.ileri = yeni;
                temp.geri = yeni;
            }
            else
            {
                yeni.ileri = temp.ileri;
                if (temp.ileri != null)
                {
                    temp.ileri.geri = yeni;
                }
                yeni.geri = temp;
                temp.ileri = yeni;
            }
        }

        public void istenilenYereEkle(node yeni, node once)
        {
            if (once == null || once == bas) basaEkle(yeni);
            else
            {
                yeni.ileri = once;
                yeni.geri = once.geri;
                once.geri.ileri = yeni;
                once.geri = yeni;
            }
        }



        public void bastanSil()
        {
            bas = bas.ileri;
            if (bas == null)
                son = null;
            else
                bas.geri = null;
        }

        public void sondanSil()
        {
            son = son.geri;
            if (son == null)
                bas = null;
            else
                son.ileri = null;
        }
        public void ortadanSil()
        {
            int sayac = say() / 2;
            node temp = bas;
            for (int i = 0; i < sayac - 1; i++)
                temp = temp.ileri;
            temp.ileri.geri = temp;
            temp.ileri = temp.ileri.ileri;
        }

        public void istenilenYerdenSil(node d)
        {
            if (d == null) return;
            if (d == bas) bastanSil();
            else if (d == son) sondanSil();
            else
            {
                d.geri.ileri = d.ileri;
                d.ileri.geri = d.geri;
            }
        }

        public int say()
        {
            node temp = bas;
            int sayac = 0;
            while (temp != null)
            {
                sayac++;
                temp = temp.ileri;
            }
            return sayac;
        }

        public void yaz()
        {
            node temp = bas;
            while (temp != null)
            {
                Console.Write(temp.veri + " - ");
                temp = temp.ileri;
            }

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            node n1 = new node(10);
            node n2 = new node(20);
            node n3 = new node(30);
            node n4 = new node(40);
            node n5 = new node(50);
            node n6 = new node(60);

            ciftbListe l1 = new ciftbListe();
            l1.basaEkle(n1);
            l1.basaEkle(n2);
            l1.sonaEkle(n3);
            l1.sonaEkle(n4);
            l1.ortayaEkle(n5);
            l1.ortayaEkle(n6);

            //l1.istenilenYereEkle(n5, n6); //bastaki dugumu ikinci parametrede verilen dugumun önüne ekliyor
            //l1.bastanSil();
            //l1.sondanSil();
            //l1.ortadanSil();
            //l1.ortadanSil();
            //l1.istenilenYerdenSil(n4);
            //Console.WriteLine(l1.say());
            l1.yaz();

        }
    }
}

