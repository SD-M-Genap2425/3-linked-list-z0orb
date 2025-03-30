using LinkedList.Perpustakaan;
using LinkedList.ManajemenKaryawan;
using LinkedList.Inventori;

namespace LinkedList;

class Program
{
    static void Main(string[] args)
    {
        // Soal Perpustakaan
        KoleksiPerpustakaan koleksi = new KoleksiPerpustakaan();

        koleksi.TambahBuku(new Buku("The Hobbit", "J.R.R. Tolkien", 1937));
        koleksi.TambahBuku(new Buku("1984", "George Orwell", 1949));
        koleksi.TambahBuku(new Buku("The Catcher in the Rye", "J.D. Salinger", 1951));
        koleksi.TambahBuku(new Buku("To Kill a Mockingbird", "Harper Lee", 1960));
        koleksi.TambahBuku(new Buku("1984 Revisi 2012", "Harper Lee Jr.", 2012));

        Console.WriteLine("Koleksi Buku:");
        Console.WriteLine(koleksi.TampilkanKoleksi());

        Buku[] hasilPencarian = koleksi.CariBuku("1984");
        Console.WriteLine("\nHasil Pencarian Buku dengan kata kunci '1984':");
        foreach (var buku in hasilPencarian)
        {
            Console.WriteLine($"\"{buku.Judul}\"; {buku.Penulis}; {buku.Tahun}");
        }

        // Soal ManajemenKaryawan
        DaftarKaryawan daftar = new DaftarKaryawan();
        daftar.TambahKaryawan(new Karyawan("001", "John Doe", "Manager"));
        daftar.TambahKaryawan(new Karyawan("002", "Jane Doe", "HR"));
        daftar.TambahKaryawan(new Karyawan("003", "Bob Smith", "IT"));
        daftar.TambahKaryawan(new Karyawan("004", "Alice", "Manager"));
        daftar.TambahKaryawan(new Karyawan("005", "Bob", "Senior Developer"));
        daftar.TambahKaryawan(new Karyawan("006", "Charlie", "Designer"));
        daftar.TambahKaryawan(new Karyawan("007", "Nathan", "Junior Developer"));

        Console.WriteLine("\nDaftar Karyawan:");
        Console.WriteLine(daftar.TampilkanDaftar());

        Karyawan[] hasilCari = daftar.CariKaryawan("Dev");
        Console.WriteLine("\nHasil Pencarian Karyawan dengan kata kunci 'Dev':");
        foreach (var karyawan in hasilCari)
        {
            Console.WriteLine($"Nomor: {karyawan.NomorKaryawan}, Nama: {karyawan.Nama}, Posisi: {karyawan.Posisi}");
        }

        bool berhasilHapus = daftar.HapusKaryawan("002");
        Console.WriteLine(berhasilHapus ? "\nKaryawan berhasil dihapus." : "\nKaryawan tidak ditemukan.");

        Console.WriteLine("\nDaftar Karyawan Setelah Penghapusan:");
        Console.WriteLine(daftar.TampilkanDaftar());

        // Soal Inventori
        ManajemenInventori inventori = new ManajemenInventori();
        inventori.TambahItem(new Item("Apple", 50));
        inventori.TambahItem(new Item("Orange", 30));
        inventori.TambahItem(new Item("Banana", 20));

        Console.WriteLine("\nInventori:");
        Console.WriteLine(inventori.TampilkanInventori());

        bool sudahDihapus = inventori.HapusItem("Orange");
        Console.WriteLine(sudahDihapus ? "\nItem berhasil dihapus." : "\nItem tidak ditemukan.");

        Console.WriteLine("\nInventori Setelah Penghapusan:");
        Console.WriteLine(inventori.TampilkanInventori());
    }
}