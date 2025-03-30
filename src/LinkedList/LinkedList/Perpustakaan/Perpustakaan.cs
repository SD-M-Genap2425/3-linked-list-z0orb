using System;

namespace LinkedList.Perpustakaan;

public class Buku
{
    public string Judul {get; set;}
    public string Penulis {get; set;}
    public int Tahun {get; set;}

    public Buku(string judul, string penulis, int tahun)
    {
        Judul = judul;
        Penulis = penulis;
        Tahun = tahun;
    }
}

public class BukuNode
{
    public Buku Data {get; set;}
    public BukuNode Next {get; set;}

    public BukuNode(Buku data)
    {
        Data = data;
        Next = null;
    }
}

public class KoleksiPerpustakaan
{
    private BukuNode head;

    public KoleksiPerpustakaan()
    {
        head = null;
    }

    public void TambahBuku(Buku buku)
    {
        BukuNode newNode = new BukuNode(buku);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            BukuNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public bool HapusBuku(string judul)
    {
        if (head == null)
        {
            return false; // Koleksi kosong
        }

        if (head.Data.Judul == judul)
        {
            head = head.Next;
            return true; // Buku berhasil dihapus
        }

        BukuNode current = head;
        while (current.Next != null && current.Next.Data.Judul != judul)
        {
            current = current.Next;
        }

        if (current.Next == null)
        {
            return false; // Buku tidak ditemukan
        }

        current.Next = current.Next.Next;
        return true; // Buku berhasil dihapus
    }

    public Buku[] CariBuku(string kataKunci)
    {
        if (head == null)
        {
            Console.WriteLine("Koleksi perpustakaan kosong.");
            return Array.Empty<Buku>();
        }

        List<Buku> hasilPencarian = new List<Buku>();
        BukuNode current = head;

        while (current != null)
        {
            if (current.Data.Judul.Contains(kataKunci, StringComparison.OrdinalIgnoreCase))
            {
                hasilPencarian.Add(current.Data);
            }
            current = current.Next;
        }

        return hasilPencarian.ToArray();
    }


    public string TampilkanKoleksi()
    {
        if (head == null)
        {
            return string.Empty; // Mengembalikan string kosong jika koleksi kosong
        }

        var result = new System.Text.StringBuilder();
        BukuNode current = head;
        while (current != null)
        {
            result.AppendLine($"\"{current.Data.Judul}\"; {current.Data.Penulis}; {current.Data.Tahun}");
            current = current.Next;
        }

        return result.ToString().TrimEnd(); // Mengembalikan daftar buku sebagai string
    }
}