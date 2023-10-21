using System;
using System.Reflection.Emit;

namespace DaireselListe
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

    public class daireListe
    {
        node bas;
        public daireListe()
        {
            bas = null;
        }

        public void ekle(node yeni)
        {
            if (bas != null)
            {
                yeni.ileri = bas;
                yeni.geri = bas.geri;
                bas.geri.ileri = yeni;
                bas.geri = yeni;
                bas = yeni;
            }
            else
            {
                bas = yeni;
                yeni.ileri = yeni;
                yeni.geri = yeni;
            }
        }

        public void sil()
        {
            if (bas.ileri == bas)
            {
                bas = null;
            }
            else
            {
                bas.geri.ileri = bas.ileri;
                bas.ileri.geri = bas.geri;
                bas = bas.ileri;
            }
        }

        public void yaz()
        {
            node temp = bas;
            while (temp != null)
            {
                Console.Write(temp.veri + " - ");
                temp = temp.ileri;
                if (temp == bas)
                    break;
            }
        }

        public int say()
        {
            node temp = bas;
            int sayac = 1;
            while (temp.ileri != bas)
            {
                sayac++;
                temp = temp.ileri;
            }
            return sayac;
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

            daireListe dliste1 = new daireListe();
            dliste1.ekle(n1);
            dliste1.ekle(n2);
            dliste1.ekle(n3);
            dliste1.ekle(n4);
            dliste1.ekle(n5);
            //dliste1.sil();
            dliste1.yaz();
            Console.WriteLine();
            //Console.WriteLine(dliste1.say());

            Console.ReadKey();

        }
    }
}
