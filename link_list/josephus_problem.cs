
/*Josephus probleminin tek yönlü dairesel bağlı liste ile C# dilinde gerçekleştiriniz.*/

using System;
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
            yeni.ileri = bas.ileri;
            bas.ileri = yeni;
            bas = yeni;
        }
        else
        {
            bas = yeni;
            yeni.ileri = yeni;
        }
    }
    public static int josephus(int n, int k)
    {
        daireListe liste = new daireListe();
        for (int i = 1; i <= n; i++)
        {
            node yeni = new node(i);
            liste.ekle(yeni);
        }
        node simdiki = liste.bas;
        while (n > 1)
        {
            for (int i = 1; i < k; i++)
            {
                simdiki = simdiki.ileri;
            }
            simdiki.ileri = simdiki.ileri.ileri;
            n--;
        }
        return simdiki.veri;
    }
    public static void Main()
    {
        int n, k;
        Console.WriteLine("Kac kisi olacak:");
        n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Kacinci kisiden baslayacak: ");
        k = Convert.ToInt32(Console.ReadLine());
        int hayattaKalan = josephus(n, k);
        Console.WriteLine("Hayatta kalan kişi: " + hayattaKalan);
        /*ORNEK CİKTİLAR
        n=5,k=2 ->3
        n=14,k=2 ->13
        n=7,k=3 ->4
        */
    }
}