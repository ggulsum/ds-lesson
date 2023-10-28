using System;
namespace Stack
{
    public class Ornek
    {
        public int icerik;
        public Ornek(int icerik)
        {
            this.icerik = icerik;
        }
    }

    public class Stack
    {
        Ornek[] dizi;
        int ustEleman;
        int n;
        public Stack(int n)
        {
            dizi = new Ornek[n];
            this.n = n;
            ustEleman = -1;

        }
        public Ornek Ust()
        {
            return dizi[ustEleman];
        }
        public Boolean StackDolu()
        {
            if (ustEleman == n - 1)
                return true;
            else
                return false;
        }

        public void StackEkle(Ornek yeni)
        {
            if (!StackDolu())
            {
                ustEleman++;
                dizi[ustEleman] = yeni;
            }
        }

        public Ornek StackSil()
        {
            if (StackDolu())
            {
                ustEleman--;
                return dizi[ustEleman + 1];
            }
            return null;
        }

        public void StackYazdir()
        {
            for (int i = ustEleman; i >= 0; i--)
            {
                Console.Write(dizi[i].icerik + "-");
            }
            Console.WriteLine();
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack s = new Stack(5);

            Ornek o1 = new Ornek(1);
            Ornek o2 = new Ornek(2);
            Ornek o3 = new Ornek(3);

            s.StackEkle(o1);
            s.StackEkle(o2);
            s.StackEkle(o3);
            s.StackYazdir();

            Console.WriteLine(s.StackDolu()); // false
            Console.WriteLine(s.Ust().icerik); // 3

            Ornek o4 = new Ornek(4);
            Ornek o5 = new Ornek(5);

            s.StackEkle(o4);
            s.StackEkle(o5);
            s.StackYazdir();
            Console.WriteLine(s.StackDolu()); // true

            Ornek silinen = s.StackSil();
            Console.WriteLine(silinen.icerik); // 5

            Console.WriteLine(s.StackDolu()); // false
            s.StackYazdir();
        }
    }


}