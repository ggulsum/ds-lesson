using System;

namespace TekYonluListe
{
    public class node
    {
        public int data;
        public node ileri;
        public node(int data)
        {
            this.data = data;
            ileri = null;
        }
    }

    public class tekYonlu
    {
        node bas;
        node son;
        public tekYonlu()
        {
            bas = null;
            son = null;
        }

        public void basinaEkle(node yeni)
        {
            if (son == null)
                son = yeni;
            yeni.ileri = bas;
            bas = yeni;
        }

        public void sonunaEkle(node yeni)
        {
            if (bas == null)
                bas = yeni;
            else
                son.ileri = yeni;
            son = yeni;
        }

        public void ortasinaEkle(node yeni)
        {
            if (bas == null)
            {
                bas = yeni;
                return;
            }
            int boyut = elemanSayisi();
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
                once.ileri = yeni;
            }
            else
            {
                yeni.ileri = temp.ileri;
                temp.ileri = yeni;
            }

        }


        public void istenilenYereEkle(node yeni, int index) //istenilen indexe ekler
        {
            node temp = bas;
            for (int i = 0; i < index - 1; i++)
            {
                temp = temp.ileri;
            }
            yeni.ileri = temp.ileri;
            temp.ileri = yeni;
        }

        public void bastanSil()
        {
            if (bas != null)
                bas = bas.ileri;
            else
                son = null;
        }

        public void sondanSil()
        {
            node temp, once;
            temp = bas;
            once = null;
            while (temp != son)
            {
                once = temp;
                temp = temp.ileri;
            }
            if (once == null)
                bas = null;
            else
                once.ileri = null;
            son = once;
        }

        public void ortadanSil()
        {
            node temp, once;
            temp = bas;
            once = null;
            int orta = elemanSayisi() / 2;
            for (int i = 0; i < orta; i++)
            {
                once = temp;
                temp = temp.ileri;
            }
            once.ileri = temp.ileri;
        }

        public void istenilenYerdenSil(int index)
        {
            if (index < 0 || index >= elemanSayisi())
            {
                Console.WriteLine("Geçersiz indeks");
                return;
            }
            node temp, once;
            temp = bas;
            once = null;
            if (index == 0)
            {
                bas = temp.ileri;
            }

            else
            {
                for (int i = 0; i < index; i++)
                {
                    once = temp;
                    temp = temp.ileri;
                }
                once.ileri = temp.ileri;
            }
        }


        public node elemanAra(int value)
        {
            node temp = bas;
            while (temp.ileri != null)
            {
                if (temp.ileri.data == value)
                {
                    Console.WriteLine("deger bulundu");
                    return temp;
                }
                temp = temp.ileri;
            }
            Console.WriteLine("deger bulunamadı");
            return null;
        }


        public int elemanSayisi()
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
                Console.Write(temp.data + " - ");
                temp = temp.ileri;
            }
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            node n1 = new node(12);
            node n2 = new node(58);
            node n3 = new node(14);
            node n4 = new node(87);
            node n5 = new node(24);
            node n6 = new node(47);
            node n7 = new node(4);
            node n8 = new node(44);
            tekYonlu Liste = new tekYonlu();
            Liste.basinaEkle(n1);
            Liste.sonunaEkle(n2);
            Liste.basinaEkle(n3);
            Liste.basinaEkle(n4);
            Liste.basinaEkle(n5);
            Liste.ortasinaEkle(n6);
            Liste.ortasinaEkle(n7);
            //Liste.istenilenYereEkle(n8, 3);
            //Liste.bastanSil();
            //Liste.sondanSil();
            //Liste.ortadanSil();
            //Liste.ortadanSil();
            //Liste.ortadanSil();
            //Liste.istenilenYerdenSil(5);
            //Liste.elemanAra(60);
            //Liste.elemanAra(44);

            Console.WriteLine();
            Liste.yaz();
        }
    }

}


