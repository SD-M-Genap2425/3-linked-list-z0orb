using System;

namespace LinkedList.Inventori;

public class Item
{
    public string Nama { get; set; }
    public int Kuantitas { get; set; }

    public Item(string nama, int kuantitas)
    {
        Nama = nama;
        Kuantitas = kuantitas;
    }
}

public class ManajemenInventori
{
    private LinkedList<Item> inventori;

    public ManajemenInventori()
    {
        inventori = new LinkedList<Item>();
    }

    public void TambahItem(Item item)
    {
        inventori.AddLast(item);
    }

    public bool HapusItem(string nama)
    {
        var current = inventori.First;
        while (current != null)
        {
            if (current.Value.Nama.Equals(nama, StringComparison.OrdinalIgnoreCase))
            {
                inventori.Remove(current);
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public string TampilkanInventori()
    {
        if (inventori.Count == 0)
        {
            return string.Empty;
        }

        var result = new System.Text.StringBuilder();
        foreach (var item in inventori)
        {
            result.AppendLine($"{item.Nama}; {item.Kuantitas}");
        }

        return result.ToString().TrimEnd();
    }
}
